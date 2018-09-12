
using phonebook.core.Data;
using phonebook.Helpers;
using phonebook.Helpers.Converters;
using phonebook.Models;
using phonebook.service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace phonebook.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly ContactModelFactory cl;

        public ContactController(IContactService contactService) {

            _contactService = contactService;
            cl = new ContactModelFactory();
        }

        // GET: Contact
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult GetContacts(int NumberOfContacts=int.MaxValue,short OrderChoice=1) {
            

            var contacts = _contactService.GetContacts(null, OrderByOption.MapOrderByNickName(OrderChoice)).Take(NumberOfContacts).ToList();

            var model = new ContactListViewModel(NumberOfContacts,OrderChoice, cl.GetContactViewModelList(contacts));
         
            return PartialView(model);
        }

        public FileStreamResult ExportContacts(int NumberOfContacts = int.MaxValue, short OrderChoice = 1)
        {

            var contacts = _contactService.GetContacts(null, OrderByOption.MapOrderByNickName(OrderChoice)).Take(NumberOfContacts).ToList();

            var model=cl.GetContactViewModelList(contacts);

            return File(new MemoryStream(Encoding.ASCII.GetBytes(model.FormatContactList())), "text/plain", "Contacts.txt");

            
        }

        public ActionResult EditByNickName(string nickName) {

            
            var contact = _contactService.GetContacts(x=>x.Nickname==nickName).FirstOrDefault();
             
            ContactViewModel model = cl.GetContactViewModel(contact);

            return View(model);
        }

        [HttpPost]
        public ActionResult EditByNickName(ContactViewModel model)
        {
            if (ModelState.IsValid) {
                var contact = _contactService.GetContacts(x=>x.Nickname== model.HiddenNickname).FirstOrDefault();

                 cl.UpdateContactByNickName(contact,model);

                _contactService.UpdateContact(contact);

                return RedirectToAction("Index", "Contact");
            }

            return View(model);
        }

        public ActionResult DeleteByNickName(string nickName)
        {
            
            var contact = _contactService.GetContacts(x=>x.Nickname==nickName).FirstOrDefault();

            _contactService.DeleteContact(contact);

            return RedirectToAction("Index","Contact");
        }

        public ActionResult UploadFile() {

            UploadContactModel model = new UploadContactModel();
            return View(model);
        }
        
        [HttpPost]
        public ActionResult UploadFile(UploadContactModel model)
        {

            if (ModelState.IsValid) {
                
                List<Contact> contactsToAdd = new List<Contact>();

                FileToContactsConverter fileToContactsConverter = new FileToContactsConverter(new ContactConverter());

                _contactService.AddContacts(fileToContactsConverter.Convert(model.File));

                return RedirectToAction("Index","Contact");
            }
            return View(model);
        }

        public ActionResult AddContact() {

            ContactViewModel model = new ContactViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult AddContact(ContactViewModel model)
        {

            if (ModelState.IsValid)
            {
                Contact contact =cl.GetContact(model);
                _contactService.SaveContact(contact);
                return RedirectToAction("Index", "Contact");
            }

            return View(model);
        }

        
        public ActionResult GetPhoneByNickNameAndReverse(string InputParameter = null) {

            var contact = _contactService.GetContacts(x => x.Nickname == InputParameter 
            || x.MobilePhone == InputParameter).FirstOrDefault();

            PhoneNicknameModel model = new PhoneNicknameModel(contact,InputParameter);

            

            return PartialView(model);
        }
    }
}