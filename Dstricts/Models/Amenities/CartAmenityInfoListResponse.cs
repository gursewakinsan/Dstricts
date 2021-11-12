using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Dstricts.Models
{
	public class CartAmenityInfoListResponse : INotifyPropertyChanged
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "amenity_id")]
		public string AmenityId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "amenity_name")]
		public string AmenityName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "aminity_quantity")]
		private int aminityQuantity;
		public int AminityQuantity
		{
			get => aminityQuantity;
			set
			{
				aminityQuantity = value;
				OnPropertyChanged("AminityQuantity");
			}
		}

		[Newtonsoft.Json.JsonProperty(PropertyName = "aminity_price")]
		public int AminityPrice { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "amenity_type")]
		public string AmenityType { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "is_order")]
		public int IsOrder { get; set; }

		public bool IsRemoveButton => IsOrder == 2 ? true : false;

		#region On Property Changed.
		public event PropertyChangedEventHandler PropertyChanged;
		public virtual void OnPropertyChanged([CallerMemberName] string name = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
		#endregion

		/*
		 [Newtonsoft.Json.JsonProperty(PropertyName = "qloud_checkout_id")]
		public int QloudCheckoutId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "is_verified")]
		public bool IsVerified { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "hotel_id")]
		public int HotelId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "room_type_id")]
		public int RoomTypeId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "room_id")]
		public int RoomId { get; set; }
		
		[Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
		public int UserId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "created_on")]
		public string CreatedOn { get; set; }
		 */
	}
}
