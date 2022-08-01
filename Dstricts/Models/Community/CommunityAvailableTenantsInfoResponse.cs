using System.Collections.Generic;

namespace Dstricts.Models
{
    public class CommunityAvailableTenantsInfoResponse : BaseModel
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "port_number")]
        public string PortNumber { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "tenants")]
        public List<Tenant> TenantsList { get; set; }

        private Xamarin.Forms.Color portNumberTextColor;
        public Xamarin.Forms.Color PortNumberTextColor
        {
            get => portNumberTextColor;
            set
            {
                portNumberTextColor = value;
                OnPropertyChanged("PortNumberTextColor");
            }
        }
        private Xamarin.Forms.Color portNumberBg;
        public Xamarin.Forms.Color PortNumberBg
        {
            get => portNumberBg;
            set
            {
                portNumberBg = value;
                OnPropertyChanged("PortNumberBg");
            }
        }
        private Xamarin.Forms.Color portNumberBorder;
        public Xamarin.Forms.Color PortNumberBorder
        {
            get => portNumberBorder;
            set
            {
                portNumberBorder = value;
                OnPropertyChanged("PortNumberBorder");
            }
        }
        public bool IsSelected { get; set; }
    }

    public class Tenant
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "image_path")]
        public string ImagePath { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "floor_number")]
        public int FloorNumber { get; set; }


        /*
        [Newtonsoft.Json.JsonProperty(PropertyName = "community_id")]
        public string tenant_email { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "community_id")]
        public int mobile_country { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "community_id")]
        public string mobile_number { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "community_id")]
        public int fixed_phone_country { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "community_id")]
        public string landline_number { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "community_id")]
        public string street_address { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "community_id")]
        public string port_number { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "community_id")]
        public string zipcode { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "community_id")]
        public string city { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "community_id")]
        public int country_of_residence { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "community_id")]
        public int nationality { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "community_id")]
        public string passport_number { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "community_id")]
        public int issue_month { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "community_id")]
        public int issue_year { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "community_id")]
        public int expiry_month { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "community_id")]
        public int expiry_year { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "community_id")]
        public string passport_front_image { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "community_id")]
        public string passport_back_image { get; set; }
        */
    }
}
