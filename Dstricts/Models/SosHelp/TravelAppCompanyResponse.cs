using Xamarin.Forms;

namespace Dstricts.Models
{
    public class TravelAppCompanyResponse : BaseModel
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "tab_type")]
        public int TabType { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "front_display_name")]
        public string FrontDisplayName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "emergency_name")]
        public string EmergencyName { get; set; }

        private bool isSelected;
        public bool IsSelected
        {
            get => isSelected;
            set
            {
                isSelected = value;
                if (isSelected)
                    ButtonBg = Color.FromHex("#F40000");
                else
                    ButtonBg = Color.FromHex("#242A37");
                OnPropertyChanged("IsSelected");
            }
        }

        private Color buttonBg;
        public Color ButtonBg
        {
            get => buttonBg;
            set
            {
                buttonBg = value;
                OnPropertyChanged("ButtonBg");
            }
        }
    }
}
