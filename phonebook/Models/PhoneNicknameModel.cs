using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using phonebook.core.Data;

namespace phonebook.Models
{
    public class PhoneNicknameModel
    {


        public PhoneNicknameModel(Contact contact, string inputParameter)
        {
            

            InputParameter = inputParameter;

            Result = string.Empty;
            if (contact != null)
            {
                Result = contact.Nickname == inputParameter ? contact.MobilePhone : contact.Nickname;
            }
        }

        public string InputParameter { get; set; }

        public string Result { get; set; }
    }

    
}
