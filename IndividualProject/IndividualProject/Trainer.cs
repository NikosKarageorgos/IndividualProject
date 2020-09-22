using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    public class Trainer
    {
        public string subject;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        
        public Trainer() { }
        public Trainer(string name, string surname)
        {
            FirstName = name;
            LastName = surname;
        }
    }
}
