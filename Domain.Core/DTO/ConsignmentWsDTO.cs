using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core.DTO
{
    [Serializable]
    public class ConsignmentWsDTO
    {
      
        public string ConsignmentWsDTO_MDB_Id { get; set; }
        public long serialVersionUID { get; set; }
        public string code { get; set; }
        public string trackingID { get; set; }
        public string status { get; set; }
        public string statusDate { get; set; }

        public List<OrderEntryWsDTO> entries { get; set; }

        public AddressWsDTO shippingAddress { get; set; }

        public DeliveryModeWsDTO deliveryPointOfService { get; set; }
        public string orderCode { get; set; }
        public string shippingDate { get; set; }
        public object deliveryMode { get; set; }
        public string warehouseCode { get; set; }
        public object packagingInfo { get; set; }




    }
}
