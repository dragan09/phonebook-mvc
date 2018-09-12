using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phonebook.core.Data
{
    public class Contact:BaseEntity
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nickname { get; set; }
        
        public string MobilePhone { get; set; }
  
        public string GroupName { get; set; }
    }
}
