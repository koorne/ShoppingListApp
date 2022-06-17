using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace ShoppingListFinal.Converters
{
    public class TextDecorationsConverter : IValueConverter
    {

        public TextDecorations trueObject = TextDecorations.Strikethrough;
        public TextDecorations falseObject = TextDecorations.None;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool result)
                return result ? trueObject : falseObject;

            throw new ArgumentException("Value is not a valid boolean", nameof(value));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
