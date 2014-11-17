namespace Application.Web.Areas.Administration.Models.Categories
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using Application.Models;
    using Application.Web.Infrastructure.Mapping;

    public class CategoriesViewModel : AdministrationViewModel, IMapFrom<Category>
    {
        [HiddenInput(DisplayValue = false)]
        public int? Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Name { get; set; }
    }
}