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

    public interface ICategoryRepository {
        void Create(Category category);
        Category GetCategory(Guid categoryId);
        void Update(Category category);
        void Delete(Guid categoryId);
        IEnumerable<Category> Find();

        IEnumerable<Category> GetAll();
	
    }
}
