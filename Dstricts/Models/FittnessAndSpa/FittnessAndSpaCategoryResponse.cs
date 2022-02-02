using System;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Dstricts.Models
{
	public class FittnessAndSpaCategoryResponse : INotifyPropertyChanged
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "service_category_name")]
		public string ServiceCategoryName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "image_path")]
		public string ImagePath { get; set; }

		private Color buttonBg = Color.FromHex("#2A2A31");
		public Color ButtonBg
		{
			get => buttonBg;
			set
			{
				buttonBg = value;
				OnPropertyChanged("ButtonBg");
			}
		}

		#region On Property Changed.
		public event PropertyChangedEventHandler PropertyChanged;
		public virtual void OnPropertyChanged([CallerMemberName] string name = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
		#endregion
	}
}
