namespace Application.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using Application.Common;
    using Application.Data.Contracts;
    using Application.Web.Controllers;
    
    [Authorize(Roles = GlobalConstants.AdminRole)]
    public class AdminBaseController : BaseController
    {
        public AdminBaseController(IDataProvider provider)
            : base(provider)
        {
        }
    }
}