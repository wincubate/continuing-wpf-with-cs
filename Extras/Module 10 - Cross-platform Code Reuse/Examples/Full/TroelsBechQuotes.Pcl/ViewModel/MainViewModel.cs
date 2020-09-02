using GalaSoft.MvvmLight;
using TroelsBechQuotes.Pcl.Model;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using TroelsBechQuotes.Pcl.Services;

namespace TroelsBechQuotes.Pcl.ViewModel
{
   /// <summary>
   /// This class contains properties that a View can data bind to.
   /// <para>
   /// See http://www.galasoft.ch/mvvm
   /// </para>
   /// </summary>
   public class MainViewModel : ViewModelBase
   {
      #region Properties

      /// <summary>
      /// The <see cref="RandomQuote" /> property's name.
      /// </summary>
      public const string RandomQuotePropertyName = "RandomQuote";

      private Quote _randomQuote;

      /// <summary>
      /// Sets and gets the RandomQuote property.
      /// Changes to that property's value raise the PropertyChanged event. 
      /// </summary>
      public Quote RandomQuote
      {
         get
         {
            return _randomQuote;
         }

         set
         {
            if ( _randomQuote == value )
            {
               return;
            }

            _randomQuote = value;
            RaisePropertyChanged( RandomQuotePropertyName );
         }
      }

      #endregion

      #region Commands

      private RelayCommand _RefreshCommand;

      /// <summary>
      /// Gets the Refresh.
      /// </summary>
      public RelayCommand RefreshCommand
      {
         get
         {
            return _RefreshCommand
                ?? ( _RefreshCommand = new RelayCommand(
                                      async
                                      () =>
                                      {
                                         var dialog = SimpleIoc.Default.GetInstance<IDialogService>();
                                         DialogResult result = await dialog.ShowAsync( "Are you sure?", "Get new quote?", DialogButtons.OKCancel );
                                         if( result == DialogResult.OK )
                                         {
                                            GetNewQuote();
                                         }
                                      } ) );
         }
      }

      #endregion

      private IQuoteDataService _dataService;

      /// <summary>
      /// Initializes a new instance of the MainViewModel class.
      /// </summary>
      public MainViewModel( IQuoteDataService dataService )
      {
         _dataService = dataService;

         GetNewQuote();
      }

      private void GetNewQuote()
      {
         RandomQuote = _dataService.GetRandomQuote();
      }
   }
}