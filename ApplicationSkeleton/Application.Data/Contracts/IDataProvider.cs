namespace Application.Data.Contracts
{
    using Application.Models;

    public interface IDataProvider
    {
        IDbContext Context { get; }

        IRepository<ApplicationUser> ApplicationUsers { get; }

        IRepository<InfoPage> InfoPages { get; }

        IRepository<Category> Categories { get; }

        IRepository<Image> Images { get; }

        IRepository<Country> Countries { get; }

        IRepository<Town> Towns { get; }

        int SaveChanges();
    }
}