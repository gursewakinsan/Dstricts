using UIKit;
using Xamarin.Forms;
using Dstricts.Controls;
using Dstricts.iOS.Renderers;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRenderer))]
namespace Dstricts.iOS.Renderers
{
	public class CustomPickerRenderer : PickerRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
		{
			base.OnElementChanged(e);
			if (Control != null)
				this.Control.BorderStyle = UITextBorderStyle.None;
		}
	}
}