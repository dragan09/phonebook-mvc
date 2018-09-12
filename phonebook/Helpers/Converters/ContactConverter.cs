using phonebook.core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace phonebook.Helpers.Converters
{
    public class ContactConverter: IContactConverter
    {
        private const string regexMatchLine = @"^(?:^[A-Z][a-zA-Z]{1,14},[\w\s])?(?:[A-Z][a-zA-Z]{1,14},[\w\s])?(?:.{1,8},[\w\s])(?:\+[0-9]{11}|[0-9]{13}|[0-9]{9})(?:,[\w\s].{1,10})?$";

        private const string regexMatchMobilePhone = @"^(?:\+[0-9]{11}|[0-9]{13}|[0-9]{9})$";

        List<ContactPosition> ContactPositions { get; set; }

        public ContactConverter()
        {
            ContactPositions = new List<ContactPosition>() {
                new ContactPosition(){Property="Name",Position=-3 },
                new ContactPosition(){Property="Surname",Position=-2 },
                new ContactPosition(){Property="Nickname",Position=-1 },
                new ContactPosition(){Property="MobilePhone",Position=0 },
                new ContactPosition(){Property="GroupName",Position=1 },
            };
        }

        public Contact ConvertToContact(string textLine) {

            if (Regex.IsMatch(textLine, regexMatchLine)) {
                textLine = textLine.Replace(",", string.Empty);

                string[] contactString = textLine.Trim().Split(' ');

                int mobilePhonePosition = GetPhoneNumberPosition(contactString);

                if (mobilePhonePosition == -1)
                    return null;

                foreach (var cnt in ContactPositions) {
                    cnt.Value = GetContactPropertyValue(contactString, cnt.Position + mobilePhonePosition);
                }

                //ContactPositions.Select(x => x.Value = GetContactPropertyValue(contactString, x.Position+mobilePhonePosition));

                //string mobilePhone = GetContactPropertyValue(contactString, mobilePhonePosition);
                //string groupName = GetContactPropertyValue(contactString, ++mobilePhonePosition);
                //mobilePhonePosition -= 2;
                //string nickName = GetContactPropertyValue(contactString, mobilePhonePosition);
                //string surName = GetContactPropertyValue(contactString, --mobilePhonePosition);
                //string firstName = GetContactPropertyValue(contactString, --mobilePhonePosition);

                Contact contact = new Contact();
                var properties = typeof(Contact).GetProperties().ToList().Where(x=>x.Name!="ID").ToList();
                foreach (var property in properties) {
                    property.SetValue(contact, ContactPositions.Where(x => x.Property == property.Name).FirstOrDefault().Value);
                }
                
                return contact;

            }

            return null;
        }

        private int GetPhoneNumberPosition(string[] stringContact) {

            for (int i = 0; i < stringContact.Length; i++) {

                if (Regex.IsMatch(stringContact[i], regexMatchMobilePhone))
                    return i;
            }

            return -1;
        }

        private string GetContactPropertyValue(string[] stringContact,int position ) {
            if (position >= 0 && position < stringContact.Length) {
                return stringContact[position];
            }
            return null;
        }

        internal class ContactPosition {
            public string Property { get; set; }

            public int Position { get; set; }

            public string Value { get; set; }
        }
    }
}