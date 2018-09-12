using phonebook.core.Data;
using phonebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace phonebook.Models
{
    public class ContactModelFactory
    {
        public Contact GetContact(ContactViewModel model)
        {
            Contact c = new Contact();
            
            c.Name = model.Name;
            c.Surname = model.Surname;
            c.Nickname = model.Nickname;
            c.MobilePhone = model.MobilePhone;
            c.GroupName = model.GroupName;
            
            return c;
        }

        public ContactViewModel GetContactViewModel(Contact model)
        {
            ContactViewModel c = new ContactViewModel(model.Nickname,model.MobilePhone);
           
            c.Name = model.Name;
            c.Surname = model.Surname;
            c.GroupName = model.GroupName;

            return c;
        }

        public List<ContactViewModel> GetContactViewModelList(List<Contact> models)
        {
            List<ContactViewModel> listContactViewModel = new List<ContactViewModel>();

            foreach (var model in models)
            {
                listContactViewModel.Add(GetContactViewModel(model));
            }

            return listContactViewModel;
        }

        public void UpdateContactByNickName(Contact contact, ContactViewModel model) {
            contact.Name = model.Name;
            contact.Surname = model.Surname;
            contact.Nickname = model.Nickname;
            contact.MobilePhone = model.MobilePhone;
            contact.GroupName = model.GroupName;
        }
    }
}