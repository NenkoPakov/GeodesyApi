using GeodesyApi.Data.Common.Repositories;
using GeodesyApi.Data.Models;
using GeodesyApi.Services.Mapping;
using GeodesyApi.Web.ViewModels;
using GeodesyApi.Web.ViewModels.Contacts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GeodesyApi.Services
{
   public class ContactsService: IContactsService
    {
        public ContactsService(IRepository<Contact> contactsRepository)
        {
            this.ContactRepository = contactsRepository;
        }

        public IRepository<Contact> ContactRepository { get; }

        public async Task SaveContactMasageAsync(ContactViewModel input)
        {
            var contact = AutoMapperConfig.MapperInstance.Map<Contact>(input);

            await this.ContactRepository.AddAsync(contact);
            await this.ContactRepository.SaveChangesAsync();
        }

    }
}
