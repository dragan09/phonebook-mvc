using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace phonebook.Models
{
    public class ContactViewModel
    {
        public ContactViewModel()
        {
        }

        public ContactViewModel(string nickName,string mobilePhone) {
            Nickname = nickName;
            HiddenNickname = nickName;
            MobilePhone = mobilePhone;
        }


        [RegularExpression("^(?:^[A-Z][a-zA-Z]{1,14})$")]
        public string Name { get; set; }

        [RegularExpression("^(?:^[A-Z][a-zA-Z]{1,14})$")]
        public string Surname { get; set; }
        
        [Required]
        [RegularExpression("^(?:.{1,8})$")]
        public string Nickname { get; set; }

        [HiddenInput]
        public string HiddenNickname { get; set; }

        [Display(Name ="Mobile Phone")]
        [Required]
        [RegularExpression(@"^(?:\+[0-9]{11}|[0-9]{13}|[0-9]{9})$")]
        public string MobilePhone { get; set; }

        [Display(Name = "Group Name")]
        [RegularExpression("^(?:.{1,10})$")]
        public string GroupName { get; set; }
    }
}