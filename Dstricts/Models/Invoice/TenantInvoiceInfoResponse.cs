using System.Collections.Generic;

namespace Dstricts.Models
{
    public class TenantInvoiceInfoResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "paid")]
        public List<PaidUnpaid> Paid { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "unpaid")]
        public List<PaidUnpaid> UnPaid { get; set; }
    }

    public class PaidUnpaid
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "invoice_generated_date")]
        public string InvoiceGeneratedDate { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "total_amount")]
        public int TotalAmount { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "payment_due")]
        public string PaymentDue { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "is_paid")]
        public bool IsPaid { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "latest")]
        public string Latest { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "invoice_month")]
        public string InvoiceMonth { get; set; }
    }
}
