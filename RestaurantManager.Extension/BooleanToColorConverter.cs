using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace RestaurantManager.Extension
{
    public class BooleanToColorConverter : IValueConverter
    {
        public Color ColorTrue { get; set; }
        public Color ColorFalse { get; set; }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is bool)
            {
                return (bool)value ? this.ColorTrue : ColorFalse;
            }

            else
            {
                return Colors.Transparent;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value is Color)
            {
                if ((Color)value == ColorTrue) return true;
                else if ((Color)value == ColorFalse) return false;
            }

            return null;
        }
    }
}
