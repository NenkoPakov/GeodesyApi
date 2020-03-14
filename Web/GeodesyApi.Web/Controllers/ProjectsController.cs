using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeodesyApi.Web.Controllers
{
    public class ProjectsController:BaseController
    {
        public IActionResult All()
        {
            return this.View();
        }

        public IActionResult New()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult New(int a)
        {
            return this.View();
        }
    }
}
