namespace Application.Web.Controllers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Application.Data.Contracts;
    using Application.Models;
    using Application.Web.Models;
    using Application.Web.Models.Profile;

    using AutoMapper.QueryableExtensions;

    [Authorize]
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

            return this.View(profile);
        }

        public ActionResult Edit()
        {
            this.SetCountries();
            this.SetTowns();

            var profile =
                this.Data.ApplicationUsers.All().Where(x => x.Id == this.CurrentUser.Id)
                .Project().To<ProfileEditInputModel>()
                .FirstOrDefault();

            return this.View(profile);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProfileEditInputModel inputData)
        {
            if (inputData != null && ModelState.IsValid)
            {
                var profileToEdit = this.Data.ApplicationUsers.Find(this.CurrentUser.Id);

                profileToEdit.UserName = inputData.UserName;
                profileToEdit.Email = inputData.Email;
                profileToEdit.FirstName = inputData.FirstName;
                profileToEdit.LastName = inputData.LastName;
                profileToEdit.ContactPhone = inputData.ContactPhone;
                profileToEdit.Address = inputData.Address;
                profileToEdit.TownId = inputData.TownId;
                profileToEdit.DateOfBirth = inputData.DateOfBirth;

                if (inputData.UploadedImage != null)
                {
                    using (var memory = new MemoryStream())
                    {
                        inputData.UploadedImage.InputStream.CopyTo(memory);
                        var content = memory.GetBuffer();

                        profileToEdit.Image = new Image
                        {
                            Content = content,
                            FileExtension = inputData.UploadedImage.FileName.Split(new[] { '.' }).Last(),
                            CreatedOn = DateTime.Now
                        };
                    }
                }

                this.Data.SaveChanges();

                return this.RedirectToAction("Details");
            }

            this.SetCountries();
            this.SetTowns();

            return this.View(inputData);
        }

        public ActionResult GetImage(int id)
        {
            var image = this.Data.Images.Find(id);

            if (image == null)
            {
                throw new HttpException(404, "Image not found");
            }

            return this.File(image.Content, "image/" + image.FileExtension);
        }

        public JsonResult RefreshTowns(int id)
        {
            var items =
                new SelectList(this.Data.Towns.All().Where(x => x.CountryId == id).ToList(), "Id", "Name");

            return this.Json(items, JsonRequestBehavior.AllowGet);
        }

        private void SetCountries()
        {
            var id = this.CurrentUser.Town != null ? this.CurrentUser.Town.CountryId : 1;

            var items = new SelectList(this.Data.Countries.All().Where(x => x.Towns.Count() > 0).ToList(), "Id", "Name", id.ToString());

            this.ViewBag.Countries = items;
        }

        private void SetTowns()
        {
            var countryId = this.CurrentUser.Town != null ? this.CurrentUser.Town.CountryId : 1;
            var id = this.CurrentUser.TownId;

            var items = new SelectList(this.Data.Towns.All().Where(x => x.CountryId == countryId).ToList(), "Id", "Name", id.ToString());

            this.ViewBag.Towns = items;
        }
    }
}