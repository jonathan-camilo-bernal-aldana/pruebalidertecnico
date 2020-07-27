using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core.DTO
{
    [Serializable]
    public class DeliveryModeWsDTO
    {
        public long serialVersionUID { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public PriceWsDTO deliveryCost { get; set; }

    }
}
