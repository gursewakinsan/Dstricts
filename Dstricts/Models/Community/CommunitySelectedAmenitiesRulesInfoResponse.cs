using Xamarin.Forms;
using System.Collections.Generic;

namespace Dstricts.Models
{
    public class CommunitySelectedAmenitiesRulesInfoResponse : BaseModel
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "community_amenity_id")]
        public int CommunityAmenityId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "rule_heading")]
        public string RuleHeading { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "rules")]
        public List<CommunitySelectedAmenitiesRules> SubRules { get; set; }

        public bool isShowSubRules = false;
        public bool IsShowSubRules
        {
            get => isShowSubRules;
            set
            {
                isShowSubRules = value;
                OnPropertyChanged("IsShowSubRules");
            }
        }

        public Color ruleBg = Color.FromHex("#181A1F");
        public Color RuleBg
        {
            get => ruleBg;
            set
            {
                ruleBg = value;
                OnPropertyChanged("RuleBg");
            }
        }
    }

    public class CommunitySelectedAmenitiesRules
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "community_rule")]
        public string CommunityRule { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "is_available")]
        public bool IsAvailable { get; set; }
    }
}
