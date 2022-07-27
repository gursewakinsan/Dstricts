namespace Dstricts.Models
{
    public class TicketTitleInfoResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "ticket_title")]
        public string TicketTitle { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "ticket_type")]
        public int TicketType { get; set; }
    }
}
