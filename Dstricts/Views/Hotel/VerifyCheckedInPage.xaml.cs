﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;
using Dstricts.Controls;
using System.Collections.Generic;

namespace Dstricts.Views.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VerifyCheckedInPage : ContentPage
	{
		VerifyCheckedInPageViewModel viewModel;
		List<Label> steps;
		public VerifyCheckedInPage(int hotelPropertyType, string verifyCheckinId)
		{
			InitializeComponent();
			steps = new List<Label>();
			steps.Add(step1);
			steps.Add(step2);
			steps.Add(step3);
			steps.Add(step4);
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new VerifyCheckedInPageViewModel(this.Navigation);
			viewModel.HotelPropertyType = hotelPropertyType;
			viewModel.VerifyCheckinId = verifyCheckinId;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.UserDetailsDstrictsCommand.Execute(null);
		}

		private void Editor_TextChanged(object sender, TextChangedEventArgs e)
		{
			var oldText = e.OldTextValue;
			var newText = e.NewTextValue;
			if (string.IsNullOrWhiteSpace(oldText) && string.IsNullOrWhiteSpace(newText))
				return;

			CustomOtpEntry editor = sender as CustomOtpEntry;

			string editorStr = editor.Text;
			if (editorStr.Length > 4)
			{
				editor.Text = editorStr.Substring(0, 4);
			}

			if (editorStr.Length >= 4)
			{
				editor.Unfocus();
			}

			for (int i = 0; i < steps.Count; i++)
			{
				Label lb = steps[i];

				if (i < editorStr.Length)
				{
					lb.Text = editorStr.Substring(i, 1);
				}
				else
				{
					lb.Text = "";
				}
				OnFocused(editorStr.Length);
			}
		}

		void OnFocused(int num)
		{
			switch (num)
			{
				case 0:
					frame1.BorderColor = Color.FromHex("#6263ED");
					frame2.BorderColor = Color.FromHex("#2A2A31");
					frame3.BorderColor = Color.FromHex("#2A2A31");
					frame4.BorderColor = Color.FromHex("#2A2A31");
					break;
				case 1:
					frame1.BorderColor = Color.FromHex("#2A2A31");
					frame2.BorderColor = Color.FromHex("#6263ED");
					frame3.BorderColor = Color.FromHex("#2A2A31");
					frame4.BorderColor = Color.FromHex("#2A2A31");
					break;
				case 2:
					frame1.BorderColor = Color.FromHex("#2A2A31");
					frame2.BorderColor = Color.FromHex("#2A2A31");
					frame3.BorderColor = Color.FromHex("#6263ED");
					frame4.BorderColor = Color.FromHex("#2A2A31");
					break;
				case 3:
					frame1.BorderColor = Color.FromHex("#2A2A31");
					frame2.BorderColor = Color.FromHex("#2A2A31");
					frame3.BorderColor = Color.FromHex("#2A2A31");
					frame4.BorderColor = Color.FromHex("#6263ED");
					break;
				default:
					frame1.BorderColor = Color.FromHex("#2A2A31");
					frame2.BorderColor = Color.FromHex("#2A2A31");
					frame3.BorderColor = Color.FromHex("#2A2A31");
					frame4.BorderColor = Color.FromHex("#2A2A31");
					break;
			}
		}
	}
}