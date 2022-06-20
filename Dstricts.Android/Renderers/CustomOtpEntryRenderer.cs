using Xamarin.Forms;
using Android.Content;
using Dstricts.Controls;
using Dstricts.Droid.Renderers;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomOtpEntry), typeof(CustomOtpEntryRenderer))]
namespace Dstricts.Droid.Renderers
{
	public class CustomOtpEntryRenderer : EditorRenderer
	{
		public CustomOtpEntryRenderer(Context context) : base(context)
		{
		}
		protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
		{
			base.OnElementChanged(e);
			if (Control != null)
			{
				Control.SetCursorVisible(false);
				Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
			}
		}
	}
}