using System;

namespace Domain.Core.DTO
{
    [Serializable]
    public class PromotionOrderEntryConsumedWsDTO
    {
        public long serialVersionUID { get; set; }
        public string code { get; set; }
        public int adjustedUnitPrice { get; set; }
        public int orderEntryNumber { get; set; }
        public int quantity { get; set; }
    }
}