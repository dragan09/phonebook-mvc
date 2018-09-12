using phonebook.core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace phonebook.service
{
    public interface IContactService
    {
        IQueryable<Contact> GetContacts(Expression<Func<Contact, bool>> filter = null,
            Func<IQueryable<Contact>, IOrderedQueryable<Contact>> orderBy = null, string includeProperties = "");
        void SaveContact(Contact contact);
        void AddContacts(List<Contact> contacts);
        void UpdateContact(Contact contact);
        void DeleteContact(Contact contact);

    }
}
