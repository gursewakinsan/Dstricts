using System.Collections.Generic;

namespace Dstricts.Models
{
    public class SocietyRulesListResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int iId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "rule_name")]
        public string RuleName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "subrules")]
        public List<SubRule> SubRules { get; set; }
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
