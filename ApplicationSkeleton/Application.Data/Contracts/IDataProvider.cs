namespace Application.Data.Contracts
{
    using Application.Models;

    public interface IDataProvider
    {
        IRepository<ApplicationUser> ApplicationUsers { get; }

        IRepository<InfoPage> InfoPages { get; }

        IRepository<Category> Categories { get; }

        IRepository<Image> Images { get; }

        int SaveChanges();
    }
}