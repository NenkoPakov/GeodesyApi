using GeodesyApi.Web.ViewModels;
using GeodesyApi.Web.ViewModels.Contacts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GeodesyApi.Services
{
    public interface IContactsService
    {
        Task SaveContactMasageAsync(ContactViewModel input);
    }
}
