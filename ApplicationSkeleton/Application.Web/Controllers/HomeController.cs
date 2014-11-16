namespace Application.Web.Controllers
{
    using System.Web.Mvc;

    using Application.Data.Contracts;

    public class HomeController : BaseController
    {
        public HomeController(IDataProvider provider)
            : base(provider)
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }
    }
}