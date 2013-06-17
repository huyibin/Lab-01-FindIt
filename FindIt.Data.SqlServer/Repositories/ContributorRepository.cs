//===================================================================================
// $$
//
// Coder: Code Milker v1.0
// 0 - EntityName
// 1 - lower
//===================================================================================


namespace FindIt.Data.SqlServer.Repositories {
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using FindIt.Model;

    public class ContributorRepository : BaseRepository, IContributorRepository {
        public ContributorRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork) {
        }
        public void Create(Contributor contributor) {
            this.GetDbSet<Contributor>().Add(contributor);
            this.UnitOfWork.SaveChanges();
        }

        public Contributor GetContributor(Guid contributorId) {
            return this.GetDbSet<Contributor>()
                .Where(c => c.Id == contributorId)
                .Single();
        }

        public void Update(Contributor updatedContributor) {
            this.GetDbSet<Contributor>().Attach(updatedContributor);
            this.SetEntityState(updatedContributor, updatedContributor.Id == Guid.Empty
                ? EntityState.Added
                : EntityState.Modified);
            this.UnitOfWork.SaveChanges();
        }

        public void Delete(Guid contributorId) {
            Contributor ContributorToDelete = this.GetContributor(contributorId);
            this.GetDbSet<Contributor>().Remove(ContributorToDelete);
            this.UnitOfWork.SaveChanges();
        }

        public IEnumerable<Contributor> Find() {
            return this.GetDbSet<Contributor>().Take(100)
                .ToList();
        }

        public IEnumerable<Contributor> GetAll() {
            return this.GetDbSet<Contributor>().Take(100)
                .ToList();
        }
    }
}
