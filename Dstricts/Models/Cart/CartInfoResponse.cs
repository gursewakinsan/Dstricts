using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Dstricts.Models
{
	public class CartInfoResponse : INotifyPropertyChanged
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "qloud_checkout_id")]
		public int QloudCheckOutId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dish_id")]
		public int DishId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dish_name")]
		public string DishName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dish_price")]
		public int DishPrice { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dish_image")]
		public string DishImage { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dish_quantity")]
		private int dishQuantity;
		public int DishQuantity
		{
			get => dishQuantity;
			set
			{
				dishQuantity = value;
				OnPropertyChanged("DishQuantity");
			}
		}

		[Newtonsoft.Json.JsonProperty(PropertyName = "created_on")]
		public string CreatedOn { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "is_verified")]
		public bool IsVerified { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dish_detail")]
		public string DishDetail { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "total_price")]
		public int TotalPrice { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "service_type")]
		public int ServiceType { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "is_paid")]
		public bool IsPaid { get; set; }

		/*[Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
		public int UserId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "company_id")]
		public int CompanyId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "card_id")]
		public int CardId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "charge_id")]
		public int ChargeId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "customer_id")]
		public int CustomerId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "is_user")]
		public bool IsUser { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "enc")]
		public string Enc { get; set; }*/

		#region On Property Changed.
		public event PropertyChangedEventHandler PropertyChanged;
		public virtual void OnPropertyChanged([CallerMemberName] string name = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
		#endregion
	}
}
