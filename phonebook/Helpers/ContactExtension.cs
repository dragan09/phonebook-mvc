using phonebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

namespace phonebook.Helpers
{
    public static class ContactExtension
    {
        public static string FormatContactList(this List<ContactViewModel> contactViewModelList)
        {
            StringBuilder strBuilder = new StringBuilder();
            bool newLine = false;

            var properties = typeof(ContactViewModel).GetProperties().ToList();
            properties = properties.Where(x => x.Name.ToLower() != nameof(ContactViewModel.HiddenNickname).ToLower()).ToList();

            foreach (var contacts in contactViewModelList) {

                
                foreach (PropertyInfo property in properties)
                {
                    if (property.GetValue(contacts) == null)
                        continue;

                    if (strBuilder.Length==0 || newLine)
                    {
                        strBuilder.Append(property.GetValue(contacts).ToString());
                        newLine = false;
                    }
                    else {
                        strBuilder.Append(", " + property.GetValue(contacts).ToString());
                    }
                }
                strBuilder.Append(Environment.NewLine);
                newLine = true;
            }

            return strBuilder.ToString();
        }
    }
}