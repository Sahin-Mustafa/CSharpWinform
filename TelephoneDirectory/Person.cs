using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneDirectory
{
    internal class Person
    {
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Category { get; set; }

        public string EnlisghLevel { get; set; }

        public string SocialLinkedln { get; set; }
        public string SocialGitHub { get; set; }
        public string SocialTwiter { get; set; }

        public bool ProgramSkilC { get; set; }
        public bool ProgramSkilPython { get; set; }
        public bool ProgramSkilJava { get; set; }
        public bool ProgramSkilJs { get; set; }

        public override string ToString()
        {
            return $"{this.Fullname} {this.Email} {this.Username} {this.PhoneNumber} {this.Category}  ";
        }

        
    }
}
