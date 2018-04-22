using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Wincubate.DataBindingPropertiesExamples.Slide09
{
    [ValueConversion( typeof( double ), typeof( string ) )]
    public class CurrencyConverter : IValueConverter
    {
        public object Convert( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture )
        {
            if( targetType != typeof( string ) )
            {
                throw new InvalidOperationException( "The target must be a string!" );
            }

            double a = double.Parse( value.ToString() );
            return a.ToString( "c", culture.NumberFormat );
        }

        public object ConvertBack( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture )
        {
            string a = value.ToString();

            double result;
            if( double.TryParse( a, System.Globalization.NumberStyles.Any, culture.NumberFormat, out result ) )
            {
                return result;
            }
            else
            {
                // Implement code to determine or return a default value here
                return 0;
            }
        }
    }
}
