using GeodesyApi.Services;
using GeodesyApi.Web.ViewModels;
using GeodesyApi.Web.ViewModels.Contacts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeodesyApi.Web.Controllers
{
    public class ContactsController:BaseController
    {
        public ContactsController(IContactsService contactsService)
        {
            this.ContactsService = contactsService;
        }

        public IContactsService ContactsService { get; }

        public IActionResult Contact()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(ContactViewModel input)
        {
            await this.ContactsService.SaveContactMasageAsync(input);

            return this.Redirect("/");
        }
    }
}
