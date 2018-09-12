using phonebook.core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace phonebook.Helpers
{
    public static class OrderByOption
    {
        public static Func<IQueryable<Contact>, IOrderedQueryable<Contact>>MapOrderByNickName(int option)
        {
            if (option == 1)
                return x => x.OrderBy(y=>y.Nickname);

            return x => x.OrderByDescending(y => y.Nickname);
        }
    }
}