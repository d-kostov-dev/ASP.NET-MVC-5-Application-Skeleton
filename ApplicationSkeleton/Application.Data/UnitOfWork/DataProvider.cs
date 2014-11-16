namespace Application.Data.UnitOfWork
{
    using System;
    using System.Collections.Generic;

    using Application.Data.Contracts;
    using Application.Data.Repositories;
    using Application.Models;
    using Application.Models.Base;

    public class DataProvider : IDataProvider
    {
        private IDbContext databaseContext;
        private IDictionary<Type, object> createdRepositories;

        public DataProvider(IDbContext context)
        {
            this.databaseContext = context;
            this.createdRepositories = new Dictionary<Type, object>();
        }

        public IRepository<ApplicationUser> ApplicationUsers
        {
            get { return this.GetRepository<ApplicationUser>(); }
        }

        public IRepository<InfoPage> InfoPages
        {
            get { return this.GetRepository<InfoPage>(); }
        }

        public IRepository<Category> Categories
        {
            get { return this.GetRepository<Category>(); }
        }

        public IRepository<Image> Images
        {
            get { return this.GetRepository<Image>(); }
        }

        public IRepository<Country> Countries
        {
            get { return this.GetRepository<Country>(); }
        }

        public IRepository<Town> Towns
        {
            get { return this.GetRepository<Town>(); }
        }

        public int SaveChanges()
        {
            return this.databaseContext.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class, IAuditInfo
        {
            var typeOfRepository = typeof(T);

            if (!this.createdRepositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(GenericRepository<T>), this.databaseContext);
                this.createdRepositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.createdRepositories[typeOfRepository];
        }
    }
}
