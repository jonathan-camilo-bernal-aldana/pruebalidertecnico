using System;
namespace Domain.Core.DTO
{
    [Serializable]
    public class PrincipalWsDTO
    {
        public long serialVersionUID { get; set; }
        public string uid { get; set; }
        public string name { get; set; }

    }
}