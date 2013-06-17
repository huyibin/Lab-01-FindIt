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

    public interface IContributorRepository {
        void Create(Contributor contributor);
        Contributor GetContributor(Guid contributorId);
        void Update(Contributor contributor);
        void Delete(Guid contributorId);
        IEnumerable<Contributor> Find();

        IEnumerable<Contributor> GetAll();
	
    }
}
