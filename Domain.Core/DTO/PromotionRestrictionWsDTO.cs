using System;

namespace Domain.Core.DTO
{
    [Serializable]
    public class PromotionRestrictionWsDTO
    {
        public long serialVersionUID { get; set; }
        public string restrictionType { get; set; }
        public string description { get; set; }

    }
}