using GeodesyApi.Data.Models;
using GeodesyApi.Services.Mapping;
using GeodesyApi.Web.ViewModels.Contacts;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;

namespace GeodesyApi.Services.Data.Tests
{
    public class ContactServiceTest : BaseServiceTests
    {
        public ContactServiceTest()
        {
            AutoMapperConfig.RegisterMappings(typeof(ContactViewModel).GetTypeInfo().Assembly);
        }

        private IContactsService ContactServiceMock => this.ServiceProvider.GetRequiredService<IContactsService>();

        [Fact]
        public async Task SaveContactMessageTest()
        {
            var message = new ContactViewModel
            {
                Email = "test@test.test",
                Message = "test",
                Name = "Testov",
            };

           await this.ContactServiceMock.SaveContactMasageAsync(message);

            var savedMessage = this.DbContext.Contacts.FirstOrDefault();

            Assert.Equal(savedMessage.Message, message.Message);
            Assert.Equal(savedMessage.Email, message.Email);
            Assert.Equal(savedMessage.Name, message.Name);
            Assert.IsType<Contact>(savedMessage);
            Assert.Equal(this.DbContext.Contacts.Count(), 1);
        }

    }
}
