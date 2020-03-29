using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeodesyApi.Web.Controllers
{
    public class GISController:BaseController
    {
        public IActionResult Map()
        {
            return this.View();
        }
    }
}
