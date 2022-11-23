using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationAndDeserialization
{
    public class Person
    {
        public string Fullname { get; set; }
        public string Tc { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Gender { get; set; }
        public string Country { get; set; }
        public string RegionCode { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string CompanyName { get; set; }
        public string CompanyCountry { get; set; }
        public string CompanyCity { get; set; }
        public string ExperienceDesc { get; set; }

        public override string ToString()
        {
            return $"{this.Fullname} {this.Tc}";
        }
    }
}
