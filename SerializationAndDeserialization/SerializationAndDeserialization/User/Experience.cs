using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationAndDeserialization
{
    public class Experience
    {
        public string CompanyName { get; set; }
        public ExperiencesAddress CompanyAdress { get; set; }
        public string ExperienceDesc { get; set; }
    }
    public class ExperiencesAddress
    {
        public string Country { get; set; }
        public string City { get; set; }
    }
}
