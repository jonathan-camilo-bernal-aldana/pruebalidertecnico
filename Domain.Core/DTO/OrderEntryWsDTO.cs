using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core.DTO
{
    [Serializable]
    public class OrderEntryWsDTO
    {
        public long serialVersionUID { get; set; }
        public int entryNumber { get; set; }
        public int quantity { get; set; }
        public object basePrice { get; set; }
        public object totalPrice { get; set; }
        public object product { get; set; }
        public bool updateable { get; set; }
        public object deliveryMode { get; set; }
        public object deliveryPointOfService { get; set; }
        public string url { get; set; }
        public int quantityAllocated { get; set; }
        public int quantityUnallocated { get; set; }
        public int quantityCancelled { get; set; }
        public int quantityPending { get; set; }
        public int quantityShipped { get; set; }
        public int quantityReturned { get; set; }
    }
}
