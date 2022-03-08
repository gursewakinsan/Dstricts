using UIKit;
using Xamarin.Forms;
using Dstricts.Controls;
using Dstricts.iOS.Renderers;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomFloatingLabelEntry), typeof(CustomFloatingLabelEntryRenderer))]
namespace Dstricts.iOS.Renderers
{
	public class CustomFloatingLabelEntryRenderer : EntryRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);
			if (Control != null)
				Control.BorderStyle = UITextBorderStyle.None;
		}
	}
}