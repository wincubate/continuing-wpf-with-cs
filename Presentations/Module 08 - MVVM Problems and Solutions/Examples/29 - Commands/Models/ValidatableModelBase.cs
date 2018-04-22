using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Wincubate.MvvmSolutions.Slide29
{
   public class ValidatableModelBase : INotifyPropertyChanged, INotifyDataErrorInfo
   {
      private object _syncObject;
      private ConcurrentDictionary<string,List<string>> _errorMap;

      public ValidatableModelBase()
      {
         _syncObject = new object();
         _errorMap = new ConcurrentDictionary<string, List<string>>();
      }

      #region INotifyPropertyChanged Members

      public event PropertyChangedEventHandler PropertyChanged;

      protected void OnPropertyChanged( [CallerMemberName] string propertyName = null )
      {
         PropertyChangedEventHandler del = PropertyChanged;
         if ( del != null )
         {
            del( this, new PropertyChangedEventArgs( propertyName ) );
         }

         ValidateAsync(); // NB!
      }

      #endregion

      #region INotifyDataErrorInfo Members

      public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

      protected void OnErrorsChanged( string propertyName )
      {
         EventHandler<DataErrorsChangedEventArgs> del = ErrorsChanged;
         if ( del != null )
         {
            del( this, new DataErrorsChangedEventArgs( propertyName ) );
         }
      }

      public IEnumerable GetErrors( string propertyName )
      {
         List<string> errors = null;
         _errorMap.TryGetValue( propertyName, out errors );

         return errors;
      }

      public bool HasErrors
      {
         get
         {
            return _errorMap.Any( kvp => kvp.Value.Count() > 0 );
         }
      }

      #endregion

      #region Validation

      public Task ValidateAsync()
      {
         return Task.Run( () => Validate() );
      }

      public void Validate()
      {
         lock ( _syncObject )
         {
            ValidationContext context = new ValidationContext( this );
            List<ValidationResult> results = new List<ValidationResult>();
            Validator.TryValidateObject( this, context, results, true );

            List<KeyValuePair<string,List<string>>> copy = _errorMap.ToList();
            foreach ( KeyValuePair<string,List<string>> kvp in copy )
            {
               if ( results.All( vr => vr.MemberNames.All( name => name != kvp.Key ) ) )
               {
                  // kvp.Key property name came back clean
                  List<string> dummy = null;
                  _errorMap.TryRemove( kvp.Key, out dummy );
                  
                  OnErrorsChanged( kvp.Key );
               }
            }

            var query = from vr in results
                        from name in vr.MemberNames
                        group vr by name;

            foreach ( var group in query )
            {
               var messages = group.Select( vr => vr.ErrorMessage );
               if( _errorMap.ContainsKey( group.Key) )
               {
                  // Remove existing
                  List<string> dummy = null;
                  _errorMap.TryRemove( group.Key, out dummy );
               }

               _errorMap.TryAdd( group.Key, messages.ToList() );
               OnErrorsChanged( group.Key );
            }
         }
      }
      #endregion      
   }
}
