namespace Application.Models
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Application.Models.Base;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class ApplicationUser : IdentityUser, IAuditInfo
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int ContactPhone { get; set; }

        public int Address { get; set; }

        public int ImageId { get; set; }

        public virtual Image Image { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = 
                await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            return userIdentity;
        }
    }
}
