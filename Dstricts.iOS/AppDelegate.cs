using UIKit;
using Foundation;

namespace Dstricts.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			Xamarin.Forms.Forms.SetFlags(new string[]
			{
				"CarouselView_Experimental",
				"IndicatorView_Experimental",
				"Brush_Experimental"
			});
			global::Xamarin.Forms.Forms.Init();
			ZXing.Net.Mobile.Forms.iOS.Platform.Init();
			App.ScreenHeight = (int)UIScreen.MainScreen.Bounds.Height;
			App.ScreenWidth = (int)UIScreen.MainScreen.Bounds.Width;
			LoadApplication(new App());
			return base.FinishedLaunching(app, options);
		}

		public override bool OpenUrl(UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
		{
			var App = (App)Xamarin.Forms.Application.Current;
			App.LoginWithSession(url.PathComponents[1]);
			return false;
		}
	}
}
