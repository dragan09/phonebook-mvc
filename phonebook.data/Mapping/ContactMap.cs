using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using phonebook.core.Data;

namespace phonebook.data.Mapping
{
    public class ContactMap : EntityTypeConfiguration<Contact>
    {
        public ContactMap()
        {
            //key
            HasKey(t => t.ID);
            //properties
            Property(t => t.Name).HasMaxLength(15);
            Property(t => t.Surname).HasMaxLength(15);
            Property(t => t.Nickname).IsRequired().HasMaxLength(8);
            Property(t => t.MobilePhone).IsRequired().HasMaxLength(13);
            Property(t => t.GroupName).HasMaxLength(10);

            //table
            ToTable("Contact");
           
    
        }
    }
}
