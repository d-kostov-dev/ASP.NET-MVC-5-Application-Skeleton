using Application.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IDataProvider provider)
            : base (provider)
        {
        }

        public ActionResult Index()
        {
            var pagesTitles = this.Data.InfoPages.All().Select(x => x.Title).ToList();

            return Content(string.Join(", ", pagesTitles));
        }
    }
}