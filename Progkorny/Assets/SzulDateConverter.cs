using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace Progkorny.Assets
{
    public class SzulDateConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }
            DateTime dt = DateTime.Parse(value.ToString());
            Console.WriteLine(dt.ToString("yyyy-MM-dd"));
            return dt.ToString("yyyy-MM-dd");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}