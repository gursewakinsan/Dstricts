using Xamarin.Forms;

namespace Dstricts.Models
{
	public class InvitedVisitorsMeetingListResponse : BaseModel
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "visiting_date")]
		public string VisitingDate { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "visiting_time")]
		public string VisitingTime { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "visiting_address")]
		public string VisitingAddress { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "d_port_number")]
		public int DPortNumber { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "address")]
		public string Address { get; set; }

		public bool IsSelectedVisitors { get; set; }

		private Color visitorsCardBorderColor = Color.FromHex("#525388");
		public Color VisitorsCardBorderColor
		{
			get => visitorsCardBorderColor;
			set
			{
				visitorsCardBorderColor = value;
				OnPropertyChanged("VisitorsCardBorderColor");
			}
		}

		private double visitorsNameTextOpacity;
		public double VisitorsNameTextOpacity
		{
			get => visitorsNameTextOpacity;
			set
			{
				visitorsNameTextOpacity = value;
				OnPropertyChanged("VisitorsNameTextOpacity");
			}
		}
	}
}