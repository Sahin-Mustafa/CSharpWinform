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
        public Address Address { get; set; }
        public Experience Company { get; set; }
        public override string ToString()
        {
            return $"{Fullname} {Tc}";
        }
    }
}
