using GeodesyApi.Services;
using GeodesyApi.Web.ViewModels.Contacts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GeodesyApi.Web.Controllers
{
    public class ContactsController : BaseController
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
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.ContactsService.SaveContactMasageAsync(input);

            return this.Redirect("/");
        }
    }
}
