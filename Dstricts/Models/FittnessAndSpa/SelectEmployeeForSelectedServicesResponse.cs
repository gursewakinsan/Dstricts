using Xamarin.Forms;

namespace Dstricts.Models
{
	public class SelectEmployeeForSelectedServicesResponse : BaseModel
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "passport_image")]
		public string PassportImage { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "services_available")]
		public string ServicesAvailable { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "email")]
		public string Email { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "user_image")]
		public string UserImage { get; set; }

		private Color userImageBorderColor = Color.Transparent;
		public Color UserImageBorderColor
		{
			get => userImageBorderColor;
			set
			{
				userImageBorderColor = value;
				OnPropertyChanged("UserImageBorderColor");
			}
		}
	}
}
