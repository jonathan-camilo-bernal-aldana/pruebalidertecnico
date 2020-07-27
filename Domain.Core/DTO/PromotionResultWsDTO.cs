using System;
using System.Collections.Generic;

namespace Domain.Core.DTO
{
    [Serializable]
    public class PromotionResultWsDTO
    {
        public long serialVersionUID { get; set; }
        public string description { get; set; }
        public PromotionWsDTO promotion {get; set;}
        public List<PromotionOrderEntryConsumedWsDTO> consumedEntries { get; set; }
    }

    
}