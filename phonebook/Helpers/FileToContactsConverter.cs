using phonebook.core.Data;
using phonebook.Helpers.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace phonebook.Helpers
{
    public class FileToContactsConverter
    {
        private readonly IContactConverter converter;

        public FileToContactsConverter(IContactConverter Converter) {
            converter = Converter;
        }

        public List<Contact> Convert(HttpPostedFileBase file) {
            List<Contact> contactsToAdd = new List<Contact>();
            using (StreamReader reader = new StreamReader(file.InputStream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Contact contact = converter.ConvertToContact(line);
                    if (contact != null)
                        contactsToAdd.Add(contact);
                }
            }

            return contactsToAdd;
        }

      
    }
}