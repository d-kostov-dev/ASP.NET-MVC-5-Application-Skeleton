namespace Application.Data.Contracts
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Application.Models;

    public interface IDbContext
    {
        IDbSet<InfoPage> InfoPages { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<Image> Images { get; set; }

        IDbSet<Country> Countries { get; set; }

        IDbSet<Town> Towns { get; set; }

        int SaveChanges();

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
