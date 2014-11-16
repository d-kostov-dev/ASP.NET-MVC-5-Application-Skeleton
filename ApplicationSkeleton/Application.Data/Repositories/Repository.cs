namespace Application.Data.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Application.Data.Contracts;
    using Application.Models.Base;
    
    public class GenericRepository<T> : IRepository<T> where T : class, IAuditInfo
    {
        private IDbContext databaseContext;
        private IDbSet<T> entitiesSet;

        public GenericRepository(IDbContext context)
        {
            this.databaseContext = context;
            this.entitiesSet = this.databaseContext.Set<T>();
        }

        public IQueryable<T> All()
        {
            return this.entitiesSet.Where(x => x.DeletedOn == null);
        }

        public IQueryable<T> AllWithDeleted()
        {
            return this.entitiesSet;
        }

        public T Find(object id)
        {
            return this.entitiesSet.Find(id);
        }

        public void Add(T entity)
        {
            entity.CreatedOn = DateTime.Now;
            this.ChangeState(entity, EntityState.Added);
        }

        public void Update(T entity)
        {
            entity.ModifiedOn = DateTime.Now;
            this.ChangeState(entity, EntityState.Modified);
        }

        public void Delete(T entity)
        {
            entity.DeletedOn = DateTime.Now;
            this.ChangeState(entity, EntityState.Modified);
        }

        public void Delete(object id)
        {
            var entity = this.Find(id);
            this.Delete(entity);
        }

        public void TotalDelete(T entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
        }

        public int SaveChanges()
        {
            return this.databaseContext.SaveChanges();
        }

        private void ChangeState(T entity, EntityState state)
        {
            var entry = this.databaseContext.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                this.entitiesSet.Attach(entity);
            }

            entry.State = state;
        }
    }
}
