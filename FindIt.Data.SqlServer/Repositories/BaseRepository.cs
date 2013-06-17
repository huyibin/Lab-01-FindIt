

namespace FindIt.Data.SqlServer.Repositories {
    using System;
    using System.Data;
    using System.Data.Entity;

    public class BaseRepository {
        protected IUnitOfWork UnitOfWork { get; set; }

        protected FindItDbContext Context {
            get { return (FindItDbContext)this.UnitOfWork; }
        }

        public BaseRepository(IUnitOfWork unitOfWork) {
            if (unitOfWork == null)
                throw new ArgumentNullException("unitOfWork");
            this.UnitOfWork = unitOfWork;
        }

        protected virtual DbSet<TEntity> GetDbSet<TEntity>() where TEntity : class {
            return this.Context.Set<TEntity>();
        }

        protected virtual void SetEntityState(object entity, EntityState entityState) {
            this.Context.Entry(entity).State = entityState;
        }
    }
}
