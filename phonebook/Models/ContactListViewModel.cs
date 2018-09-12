using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace phonebook.Models
{
    public class ContactListViewModel
    {
        private List<ContactViewModel> list;

       

        public ContactListViewModel(int numberOfContacts, short orderChoice, List<ContactViewModel> list)
        {
            
            Order = PopulateOrderSelectList();


            ContactList = list;
            NumberOfContacts = numberOfContacts;
            OrderChoice = orderChoice;
            this.list = list;

            NumberOfContacts = null;
            if (numberOfContacts != int.MaxValue)
                NumberOfContacts = NumberOfContacts;

            OrderChoice = orderChoice;
        }

        public List<ContactViewModel> ContactList { get; set; }

        public int? NumberOfContacts { get; set; }

        public short OrderChoice { get; set; }

        public SelectList Order { get; set; }

        private SelectList PopulateOrderSelectList()
        {
            return new SelectList(new List<SelectListItem>() {
                new SelectListItem{ Text="Ascending",Value="1"},
                new SelectListItem{ Text="Descending",Value="2"}
            }, "Value", "Text");
        }

        
    }
}