namespace Application.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Application.Data.Contracts;
    using Application.Web.Models.Pages;

    using AutoMapper.QueryableExtensions;
    
    public class PagesController : BaseController
    {
        public PagesController(IDataProvider provider)
            : base(provider)
        {
        }

        public ActionResult Details(string pageSeoUrl)
        {
            var page =
                this.Data.InfoPages.All()
                .Where(x => x.SeoUrl == pageSeoUrl)
                .Project().To<PageDetailsViewModel>()
                .FirstOrDefault();

            return this.View(page);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 10 * 60)]
        public ActionResult GetPages()
        {
            var pages =
                this.Data.InfoPages.All()
                .Project().To<PagesFooterViewModel>();

            return this.PartialView("_PagesFooterPartial", pages);
        }
    }
}