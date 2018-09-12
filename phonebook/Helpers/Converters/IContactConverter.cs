using phonebook.core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace phonebook.Helpers.Converters
{
    public interface IContactConverter
    {
        Contact ConvertToContact(string textLine);
    }
}