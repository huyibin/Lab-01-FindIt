//===================================================================================
// $$
//
// Coder: Code Milker v1.0
// 0 - EntityName
// 1 - lower
//===================================================================================

namespace FindIt.Data {
    using System;
    using System.Collections.Generic;
    using FindIt.Model;
    using FindIt.Infrastructure;

    public interface IDigestRepository {
        void Create(Digest digest);
        Digest GetDigest(Guid digestId);
        void Update(Digest digest);
        void Delete(Guid digestId);
        IEnumerable<Digest> Find(int pageIndex);

        IPagedList<Digest> GetAll(int pageIndex,int pageSize);
	
    }
}
