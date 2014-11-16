namespace Application.Web.Models
{
    using System;

    using Application.Models;
    using Application.Web.Infrastructure.Mapping;

    using AutoMapper;

    public class ProfileDetailsViewModel : IMapFrom<ApplicationUser>, IHaveCustomMappings
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string ContactPhone { get; set; }

        public string TownName { get; set; }

        public string Address { get; set; }

        public int? ImageId { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<ApplicationUser, ProfileDetailsViewModel>()
                .ForMember(m => m.TownName, opt => opt.MapFrom(u => u.Town.Name));
        }
    }
}