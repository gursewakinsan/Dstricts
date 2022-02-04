using System;
using Xamarin.Forms;

namespace Dstricts.Models
{
	public class AvailableDatesForbookingResponse : BaseModel
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "date_id")]
		public int DateId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "date")]
		public DateTime Date { get; set; }

		public int DisplayDate => Date.Day;

		public string DisplayMonth => Date.ToString("MMM");

		private Color pickDateBorderColor = Color.FromHex("#2A2A31");
		public Color PickDateBorderColor
		{
			get => pickDateBorderColor;
			set
			{
				pickDateBorderColor = value;
				OnPropertyChanged("PickDateBorderColor");
			}
		}

		private Color displayDateColor = Color.White;
		public Color DisplayDateColor
		{
			get => displayDateColor;
			set
			{
				displayDateColor = value;
				OnPropertyChanged("DisplayDateColor");
			}
		}

		private Color displayMonthColor = Color.FromHex("#2A2A31");
		public Color DisplayMonthColor
		{
			get => displayMonthColor;
			set
			{
				displayMonthColor = value;
				OnPropertyChanged("DisplayMonthColor");
			}
		}
	}
}
