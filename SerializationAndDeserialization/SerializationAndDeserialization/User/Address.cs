using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationAndDeserialization
{
    public class Address
    {
        public Country Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
    }
    public class Country
    {
        public string Name { get; set; }
        public string RegionCode { get; set; }
    }
}
