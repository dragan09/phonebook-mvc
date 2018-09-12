using phonebook.core.Data;
using phonebook.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace phonebook.service
{
    public class ContactService : IContactService
    {
        private IRepository<Contact> contactRepository;


        public ContactService(IRepository<Contact> ContactRepository
            )
        {
            this.contactRepository = ContactRepository;

        }

        public void DeleteContact(Contact contact)
        {
            contactRepository.Delete(contact);
            contactRepository.SaveChanges();
        }



        private void InsertContact(Contact contact)
        {
            contactRepository.Insert(contact);

        }

        public void SaveContact(Contact contact)
        {
            try
            {

                InsertContact(contact);
                contactRepository.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public void UpdateContact(Contact contact)
        {
            contactRepository.Update(contact);
            contactRepository.SaveChanges();
        }

        public void AddContacts(List<Contact> contacts)
        {
            foreach (var contact in contacts)
            {
                InsertContact(contact);
            }
            contactRepository.SaveChanges();
        }

        public IQueryable<Contact> GetContacts(Expression<Func<Contact, bool>> filter = null, Func<IQueryable<Contact>, IOrderedQueryable<Contact>> orderBy = null, string includeProperties = "")
        {
            return contactRepository.Get(filter, orderBy, includeProperties);
        }


    }
}
