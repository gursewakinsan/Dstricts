using System;
using Xamarin.Forms;
using Dstricts.Controls;
using Dstricts.Droid.Renderers;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomDatePicker), typeof(CustomDatePickerRenderer))]
namespace Dstricts.Droid.Renderers
{
	[Obsolete]
	public class CustomDatePickerRenderer : DatePickerRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
		{
			base.OnElementChanged(e);
			if (this.Control != null)
				this.Control.SetBackgroundResource(0);
		}
	}
}