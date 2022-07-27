namespace Dstricts.Models
{
    public class CreateCommunityTicketRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "ticket_type")]
        public int TicketType { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "ticket_id")]
        public int TicketId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "subticket_id")]
        public int SubTicketId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "community_id")]
        public int CommunityId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "check_id")]
        public int CheckId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "problem_description")]
        public string ProblemDescription { get; set; }
    }
}
