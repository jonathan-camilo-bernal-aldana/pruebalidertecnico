using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core.DTO
{
    [Serializable]
    public class AddressWsDTO
    {
        public long serialVersionUID { get; set; }
        public string id { get; set; }
        public string title { get; set; }
        public string titleCode { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string companyName { get; set; }
        public string line1 { get; set; }
        public string line2 { get; set; }
        public string town { get; set; }
        public object region { get; set; }
        public string postalCode { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public object country { get; set; }
        public bool shippingAddress { get; set; }
        public bool visibleInAddressBook { get; set; }
        public string formattedAddress { get; set; }


    }
}
