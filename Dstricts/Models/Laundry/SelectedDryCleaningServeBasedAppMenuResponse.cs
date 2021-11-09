using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Dstricts.Models
{
	public class SelectedDryCleaningServeBasedAppMenuResponse : INotifyPropertyChanged
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dish_name")]
		public string DishName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dish_price")]
		public int DishPrice { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dish_detail")]
		public string DishDetail { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "serve_type")]
		public int ServeType { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dish_quantity")]
		public int dishQuantity;
		public int DishQuantity 
		{
			get => dishQuantity;
			set
			{
				dishQuantity = value;
				OnPropertyChanged("DishQuantity");
			}
		}

		private Color dishQuantityBg;
		public Color DishQuantityBg
		{
			get => dishQuantityBg;
			set
			{
				dishQuantityBg = value;
				OnPropertyChanged("DishQuantityBg");
			}
		}

		private Color dishQuantityText;
		public Color DishQuantityText
		{
			get => dishQuantityText;
			set
			{
				dishQuantityText = value;
				OnPropertyChanged("DishQuantityText");
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
		

		#region On Property Changed.
		public event PropertyChangedEventHandler PropertyChanged;
		public virtual void OnPropertyChanged([CallerMemberName] string name = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
		#endregion
	}
}
