using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeodesyApi.Web.Controllers
{
    [Authorize]
    public class GISController : BaseController
    {
        public IActionResult Map()
        {

            return this.View();
        }
    }
}
