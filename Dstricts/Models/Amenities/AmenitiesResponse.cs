using System;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Dstricts.Models
{
	public class AmenitiesResponse : INotifyPropertyChanged
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "amenity_name")]
		public string AmenityName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "is_order")]
		public int IsOrder { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "enc")]
		public string Enc { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "quantity")]
		public int quantity;
		public int Quantity
		{
			get => quantity;
			set
			{
				quantity = value;
				OnPropertyChanged("Quantity");
			}
		}

		private Color quantityBg;
		public Color QuantityBg
		{
			get => quantityBg;
			set
			{
				quantityBg = value;
				OnPropertyChanged("QuantityBg");
			}
		}

		private Color quantityText;
		public Color QuantityText
		{
			get => quantityText;
			set
			{
				quantityText = value;
				OnPropertyChanged("QuantityText");
			}
		}

		private Color cardBoarder;
		public Color CardBoarder
		{
			get => cardBoarder;
			set
			{
				cardBoarder = value;
				OnPropertyChanged("CardBoarder");
			}
		}

		private double cardBoarderOpacity;
		public double CardBoarderOpacity
		{
			get => cardBoarderOpacity;
			set
			{
				cardBoarderOpacity = value;
				OnPropertyChanged("CardBoarderOpacity");
			}
		}
		public Action CallBack { get; set; }

		#region On Property Changed.
		public event PropertyChangedEventHandler PropertyChanged;
		public virtual void OnPropertyChanged([CallerMemberName] string name = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
		#endregion
	}
}
