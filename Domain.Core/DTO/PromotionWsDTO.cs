using System;
using System.Collections.Generic;

namespace Domain.Core.DTO
{
    [Serializable]
    public class PromotionWsDTO
    {
        public long serialVersionUID { get; set; }
        public string code { get; set; }
        public string title { get; set; }
        public string promotionType { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string description { get; set; }
        public List<string> couldFireMessages { get; set; }
        public List<string> firedMessages { get; set; }
        public ImageWsDTO productBanner { get; set; }
        public bool enabled { get; set; }
        public int priority { get; set; }
        public string promotionGroup { get; set; }
        public PromotionRestrictionWsDTO restrictions { get; set; }

    }
}