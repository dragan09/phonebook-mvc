using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace phonebook.Models
{
    public class UploadContactModel
    {
        [Required]
        public HttpPostedFileBase File { get; set; }
        public string FirstName { get; set; }
    }
}