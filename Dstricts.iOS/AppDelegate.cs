using UIKit;
using Foundation;
using System.Linq;

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
			Rg.Plugins.Popup.Popup.Init();
			global::Xamarin.Forms.Forms.Init();
			ZXing.Net.Mobile.Forms.iOS.Platform.Init();
			App.ScreenHeight = (int)UIScreen.MainScreen.Bounds.Height;
			App.ScreenWidth = (int)UIScreen.MainScreen.Bounds.Width;
			Syncfusion.ListView.XForms.iOS.SfListViewRenderer.Init();
			LoadApplication(new App());
			return base.FinishedLaunching(app, options);
		}

		public override bool OpenUrl(UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
		{
			var App = (App)Xamarin.Forms.Application.Current;
			if (!string.IsNullOrWhiteSpace(url.Path))
			{
				if (url.PathComponents.Count() == 4)
				{
					App.InvitedVisitorsMeetingListCommand.Execute(url.PathComponents[3]);
				}
				if (url.Host.Equals("verify_checkin"))
				{
					App.CheckInFunctionality(url.ResourceSpecifier);
				}
				else
					App.LoginWithSession(url.PathComponents[1]);
			}
			return false;
		}
	}
}
