namespace GeodesyApi.Web.Areas.Administration.Controllers
{
    using GeodesyApi.Common;
    using GeodesyApi.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
