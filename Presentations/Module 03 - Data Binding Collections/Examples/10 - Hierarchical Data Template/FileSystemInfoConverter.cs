using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.IO;

namespace Wincubate.DataBindingCollectionsExamples.Slide10
{
    public class FileSystemInfoConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture )
        {
            try
            {
                DirectoryInfo di = value as DirectoryInfo;
                if( di != null )
                {
                    return di.GetFileSystemInfos();
                }
            }
            catch( UnauthorizedAccessException )
            {
            }

            return null;
        }

        public object ConvertBack( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture )
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
