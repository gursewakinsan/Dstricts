namespace Dstricts.Models
{
    public class TicketSubTitleInfoResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "ticket_subtitle")]
        public string TicketSubtitle { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "ticket_id")]
        public int TicketId { get; set; }
    }
}
