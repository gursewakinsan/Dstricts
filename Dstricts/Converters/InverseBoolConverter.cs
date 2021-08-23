﻿using System;
using Xamarin.Forms;
using System.Globalization;

namespace Dstricts.Converters
{
	public class InverseBoolConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return !System.Convert.ToBoolean(value);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
