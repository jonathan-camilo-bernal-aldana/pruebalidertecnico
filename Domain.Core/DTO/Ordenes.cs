using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Domain.Core.DTO
{
    [Serializable]
    public class Ordenes
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Order_MDB_Id { get; set; }
        public string created { get; set; }
        public string status { get; set; }
        public string statusDisplay { get; set; }
        public bool guestCustomer { get; set; }
        public List<ConsignmentWsDTO> consignments { get; set; }
        public string deliveryStatus { get; set; }
        public string deliveryStatusDisplay { get; set; }
        public List<OrderEntryWsDTO> unconsignedEntries { get; set; }
        public AddressWsDTO paymentAddress { get; set; }
        public long serialVersionUID { get; set; }
        public string code { get; set; }
        public bool net { get; set; }
        public PriceWsDTO totalPriceWithTax { get; set; }
        public PriceWsDTO totalPrice { get; set; }
        public PriceWsDTO totalTax { get; set; }
        public PriceWsDTO subTotal { get; set; }
        public PriceWsDTO deliveryCost { get; set; }
        public List<OrderEntryWsDTO> entries { get; set; }
        public int totalItems { get; set; }
        public DeliveryModeWsDTO deliveryMode { get; set; }
        public AddressWsDTO deliveryAddress { get; set; }
        public PaymentDetailsWsDTO paymentInfo { get; set; }
        public List<PromotionResultWsDTO> appliedOrderPromotions { get; set; }
        public List<PromotionResultWsDTO> appliedProductPromotions { get; set; }
        public PriceWsDTO productDiscounts { get; set; }
        public PriceWsDTO orderDiscounts { get; set; }
        public PriceWsDTO totalDiscounts { get; set; }
        public string site { get; set; }
        public string store { get; set; }
        public string guid { get; set; }
        public bool calculated { get; set; }
        public List<VoucherWsDTO> appliedVouchers { get; set; }
        public PrincipalWsDTO user { get; set; }
        public List<PickupOrderEntryGroupWsDTO> pickupOrderGroups { get; set; }
        public List<object> deliveryOrderGroups { get; set; }
        public int pickupItemsQuantity { get; set; }
        public int deliveryItemsQuantity { get; set; }

    }
}
