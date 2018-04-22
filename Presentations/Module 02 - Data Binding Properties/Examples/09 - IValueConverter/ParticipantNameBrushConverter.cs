using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Media;

namespace Wincubate.DataBindingPropertiesExamples.Slide09
{
    [ValueConversion( typeof( string ), typeof( Brush ) )]
    public class ParticipantNameBrushConverter : IValueConverter
    {
        public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
        {
            if( targetType != typeof( Brush ) )
            {
                throw new InvalidOperationException( "The target must be a Brush!" );
            }

            Color baseColor;

            int threshold = 0;
            string stringParameter = parameter as string;
            if( string.IsNullOrEmpty( stringParameter ) == false )
            {
                threshold = int.Parse( stringParameter );
            }

            string name = value as string;

            if( name.Length <= threshold )
            {
                baseColor = Colors.Green;
            }
            else
            {
                baseColor = Colors.White;
            }

            byte colorComponent = (byte) ( 255 - 8 * name.Length );
            baseColor.B = colorComponent;

            return new SolidColorBrush( baseColor );
        }

        public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture )
        {
            throw new NotImplementedException();
        }
   }
}
