using System;

namespace Domain.Core.DTO
{
    [Serializable]
    public class VoucherWsDTO
    {
        public long serialVersionUID { get; set; }
        public string code { get; set; }
        public string voucherCode { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int value { get; set; }
        public string valueFormatted { get; set; }
        public string valueString { get; set; }
        public bool freeShipping { get; set; }
        public CurrencyWsDTO currency { get; set; }
        public PriceWsDTO appliedValue { get; set; }
    }
}