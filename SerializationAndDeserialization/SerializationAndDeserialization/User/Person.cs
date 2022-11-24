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
        public List<Address> Addresses { get; set; } = new List<Address>();
        public List<Experience> Experiences { get; set; } = new List<Experience>();
        public override string ToString()
        {
            return $"{Fullname} {Tc}";
        }
        //
    }
}
