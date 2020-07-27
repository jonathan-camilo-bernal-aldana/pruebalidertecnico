using System;
namespace Domain.Core.DTO
{
    [Serializable]
    public class CurrencyWsDTO
    {
        public long serialVersionUID { get; set; }
        public string isocode { get; set; }
        public string name { get; set; }
        public bool active { get; set; }
        public string symbol { get; set; }

    }
}