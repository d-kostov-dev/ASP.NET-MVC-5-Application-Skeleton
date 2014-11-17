namespace Application.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Web.Mvc;

    using Application.Data.Contracts;
    using Application.Web.Areas.Administration.Controllers.Base;

    using Kendo.Mvc.UI;

    using Model = Application.Models.Category;
    using ViewModel = Application.Web.Areas.Administration.Models.Categories.CategoriesViewModel;
    using System;

    public class CategoriesController : KendoGridAdministrationController
    {
        public CategoriesController(IDataProvider data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        protected override IEnumerable GetData()
        {
            return this.Data.Categories.All();
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.Categories.Find(id) as T;
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            model.CreatedOn = DateTime.Now;
            var dbModel = base.Create<Model>(model);

            if (dbModel != null)
            {
                model.Id = dbModel.Id;
            }

            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            base.Update<Model, ViewModel>(model, model.Id);
            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                this.Data.Categories.Delete(model.Id.Value);
                this.Data.SaveChanges();
            }

            return this.GridOperation(model, request);
        }
    }
}