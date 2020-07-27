using System;
namespace Domain.Core.DTO
{
    [Serializable]
    public class ImageWsDTO
    {
        public long serialVersionUID { get; set; }
        public string imageType { get; set; }
        public string format { get; set; }
        public string url { get; set; }
        public string altText { get; set; }
        public int galleryIndex { get; set; }

    }
}