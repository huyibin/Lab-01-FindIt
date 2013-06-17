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
    using FindIt.Infrastructure;

    public class DigestRepository : BaseRepository, IDigestRepository {
        public DigestRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork) {
        }
        public void Create(Digest digest) {
            this.GetDbSet<Digest>().Add(digest);
            this.UnitOfWork.SaveChanges();
        }

        public Digest GetDigest(Guid digestId) {
            return this.GetDbSet<Digest>()
                .Where(c => c.Id == digestId)
                .Single();
        }

        public void Update(Digest updatedDigest) {
            this.GetDbSet<Digest>().Attach(updatedDigest);
            this.SetEntityState(updatedDigest, updatedDigest.Id == Guid.Empty
                ? EntityState.Added
                : EntityState.Modified);
            this.UnitOfWork.SaveChanges();
        }

        public void Delete(Guid digestId) {
            Digest DigestToDelete = this.GetDigest(digestId);
            this.GetDbSet<Digest>().Remove(DigestToDelete);
            this.UnitOfWork.SaveChanges();
        }

        public IEnumerable<Digest> Find(int pageIndex) {
            return this.GetDbSet<Digest>().Take(pageIndex)
                .ToList();
            // Test
        }

        public IPagedList<Digest> GetAll(int pageIndex, int pageSize) {
            IQueryable<Digest> query = this.GetDbSet<Digest>().OrderBy(d=>d.Title);

            return new PagedList<Digest>(query, pageIndex, pageSize);

        }
    }
}
