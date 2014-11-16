using Application.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using Application.Web.Models;

namespace Application.Web.Controllers
{
    public class ProfileController : BaseController
    {
        public ProfileController(IDataProvider provider)
            : base(provider)
        {
        }

        public ActionResult Details()
        {
            var profile =
                this.Data.ApplicationUsers.All()
                .Where(x => x.Id == this.CurrentUser.Id)
                .Project().To<ProfileDetailsViewModel>()
                .FirstOrDefault();

            return View(profile);
        }

        public ActionResult GetImage(int id)
        {
            var image = this.Data.Images.Find(id);

            if (image == null)
            {
                throw new HttpException(404, "Image not found");
            }

            return File(image.Content, "image/" + image.FileExtension);
        }
    }
}