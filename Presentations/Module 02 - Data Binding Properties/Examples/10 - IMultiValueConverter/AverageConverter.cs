using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Wincubate.DataBindingPropertiesExamples.Slide10
{
   public class AverageConverter : IMultiValueConverter
   {
      public object Convert( object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture )
      {
         double sum = 0.0;
         foreach( double db in values )
         {
            sum += db;
         }

         return sum / ( values.Length > 0 ? values.Length : 1 );
      }

      public object[] ConvertBack( object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture )
      {
         throw new NotImplementedException();
      }
   }
}
