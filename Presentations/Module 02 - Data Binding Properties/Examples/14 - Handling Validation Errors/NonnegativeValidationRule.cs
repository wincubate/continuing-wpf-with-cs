using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Globalization;

namespace Wincubate.DataBindingPropertiesExamples.Slide14
{
   public class NonnegativeValidationRule : ValidationRule
   {
      public override ValidationResult Validate( object value, CultureInfo cultureInfo )
      {
         string s = value as string;
         if( string.IsNullOrEmpty( s ) == false )
         {
            double db;
            if( double.TryParse( s, NumberStyles.Any, cultureInfo.NumberFormat, out db ) )
            {
               if( db >= 0.0 )
               {
                  return new ValidationResult( true, null );
               }
               else
               {
                  return new ValidationResult( false, "String corresponds to a negative value" );
               }
            }
            else
            {
               return new ValidationResult( false, "String does not correspond to a double value" );
            }
         }

         return new ValidationResult( false, "Empty string entered" );
      }
   }
}
