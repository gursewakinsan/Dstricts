namespace Dstricts.Models
{
    public class ReportPersonFoundRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "missing_person_id")]
        public int MissingPersonId { get; set; }
    }
}
