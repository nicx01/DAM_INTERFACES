using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;

namespace CambioDivisa.Utils
{
    public class FileIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DirectoryInfo)
                return "Icons/folder_icon.png"; // Ruta del icono de carpeta
            else
                return "Icons/file_icon.png"; // Ruta del icono de archivo
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
