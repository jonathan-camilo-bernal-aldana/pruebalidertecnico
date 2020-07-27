using System.Collections.Generic;
using System;
namespace Domain.Core.DTO
{
    [Serializable]
    public class PointOfServiceWsDTO
    {
        public long serialVersionUID { get; set; }
        public string name { get; set; }
        public string displayName { get; set; }
        public string url { get; set; }
        public string description { get; set; }
        public object openingHours { get; set; }
        public string storeContent { get; set; }
        public object features { get; set; }
        public object geoPoint { get; set; }
        public string formattedDistance { get; set; }
        public int distanceKm { get; set; }
        public ImageWsDTO mapIcon { get; set; }
        public AddressWsDTO address { get; set; }
        public List<ImageWsDTO> storeImages { get; set; }

    }
}