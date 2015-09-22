using System;
using Xamarin.Forms;

namespace MyContacts
{
	public class ImageResourceConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
            var uri = new Uri(value + "");
			return ImageSource.FromUri(uri);
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}

