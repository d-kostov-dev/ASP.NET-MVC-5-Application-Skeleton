namespace Application.Web.Controllers
{
    using System.Web.Mvc;

    using Application.Data.Contracts;
    using Application.Models;

    using Microsoft.AspNet.Identity;

    public class BaseController : Controller
    {
        private ApplicationUser currentUser;

        public BaseController(IDataProvider provider)
        {
            this.Data = provider;
        }

        public IDataProvider Data { get; private set; }

        public ApplicationUser CurrentUser
        {
            get
            {
                if (this.currentUser == null)
                {
                    var currentUserId = User.Identity.GetUserId();
                    this.currentUser = this.Data.ApplicationUsers.Find(currentUserId);
                }

                return this.currentUser;
            }
        }
    }
}