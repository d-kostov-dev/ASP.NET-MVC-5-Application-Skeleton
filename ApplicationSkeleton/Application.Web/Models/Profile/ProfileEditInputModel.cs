namespace Application.Web.Models.Profile
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    using Application.Models;
    using Application.Web.Infrastructure.Mapping;

    using AutoMapper;
    
    public class ProfileEditInputModel : IMapFrom<ApplicationUser>, IHaveCustomMappings
    {
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Date Of Birth")]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Contact Phone")]
        public string ContactPhone { get; set; }

        [Display(Name = "Country")]
        public int? CountryId { get; set; }

        [Display(Name = "Town")]
        public int? TownId { get; set; }

        public string Address { get; set; }

        [Display(Name = "Profile Photo")]
        public HttpPostedFileBase UploadedImage { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<ApplicationUser, ProfileEditInputModel>()
                .ForMember(m => m.CountryId, opt => opt.MapFrom(u => u.Town.CountryId))
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}