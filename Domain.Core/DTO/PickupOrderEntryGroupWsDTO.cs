using System.Collections.Generic;
using System;
namespace Domain.Core.DTO
{
    [Serializable]
    public class PickupOrderEntryGroupWsDTO
    {
        public PointOfServiceWsDTO deliveryPointOfService { get; set; }
        public int distance { get; set; }
        public long serialVersionUID { get; set; }
        public PriceWsDTO totalPriceWithTax { get; set; }
        public List<OrderEntryWsDTO> entries {get;set;}
        public int quantity { get; set; }

    }
}