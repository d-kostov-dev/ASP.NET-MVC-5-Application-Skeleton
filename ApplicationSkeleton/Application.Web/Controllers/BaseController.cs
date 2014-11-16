namespace Application.Web.Controllers
{
    using System.Web.Mvc;

    using Application.Data.Contracts;
    
    public class BaseController : Controller
    {
        public BaseController(IDataProvider provider)
        {
            this.Data = provider;
        }

        public IDataProvider Data { get; private set; }
    }
}