using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core.DTO
{
    [Serializable]
    public class PriceWsDTO
    {
        public long serialVersionUID { get; set; }
        public string currencyIso { get; set; }
        public int value { get; set; }
        public string priceType { get; set; }
        public string formattedValue { get; set; }
        public int minQuantity { get; set; }
        public int maxQuantity { get; set; }


    }
}
