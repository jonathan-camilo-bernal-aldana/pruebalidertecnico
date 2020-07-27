using System;
namespace Domain.Core.DTO
{
    [Serializable]
    public class PaymentDetailsWsDTO
    {
        public long serialVersionUID { get; set; }
        public string id { get; set; }
        public string accountHolderName { get; set; }
        public object cardType { get; set; }
        public string cardNumber { get; set; }
        public string startMonth { get; set; }
        public string startYear { get; set; }
        public string expiryMonth { get; set; }
        public string expiryYear { get; set; }
        public string issueNumber { get; set; }
        public string subscriptionId { get; set; }
        public bool saved { get; set; }
        public bool defaultPayment { get; set; }
        public AddressWsDTO billingAddress { get; set; }

    }
}