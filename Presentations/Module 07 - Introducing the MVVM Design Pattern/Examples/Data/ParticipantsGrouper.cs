using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Wincubate.IntroducingMvvmExamples.Data
{
   public class ParticipantsGrouper : IValueConverter
   {
      public object Convert( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture )
      {
         string s = value as string;
         if( s != null )
         {
            if( s.Contains( "A/S" ) )
            {
               return "A/S";
            }
            else
            {
               return "Anden virksomhedstype";
            }
         }

         throw new NotImplementedException();
      }

      public object ConvertBack( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture )
      {
         throw new NotImplementedException();
      }
   }
}
