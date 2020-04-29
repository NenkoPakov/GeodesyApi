using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeodesyApi.Web.Controllers
{
    public class ViewComponentController:BaseController
    {
        [HttpPost]
        public IActionResult Get(int id)
        {
            var a = ViewComponent("QuestionById", new { id });
            return a;
        }
    }
}
