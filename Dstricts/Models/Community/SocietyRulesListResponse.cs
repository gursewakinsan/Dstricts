using Xamarin.Forms;
using System.Collections.Generic;

namespace Dstricts.Models
{
    public class SocietyRulesListResponse : BaseModel
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int iId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "rule_name")]
        public string RuleName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "subrules")]
        public List<SubRule> SubRules { get; set; }

        public bool isShowSubRules = false;
        public bool IsShowSubRules
        {
            get=> isShowSubRules;
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

    public class SubRule
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "subrule_name")]
        public string SubRuleName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "is_applicable")]
        public bool IsApplicable { get; set; }
    }
}
