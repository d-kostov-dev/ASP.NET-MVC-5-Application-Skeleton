namespace Application.Data.Contracts
{
    using Application.Models;

    public interface IDataProvider
    {
        IRepository<ApplicationUser> ApplicationUsers { get; }

        int SaveChanges();
    }
}