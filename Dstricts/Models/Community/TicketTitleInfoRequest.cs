namespace Dstricts.Models
{
    public class TicketTitleInfoRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "ticket_type")]
        public string TicketType { get; set; }
    }
}
