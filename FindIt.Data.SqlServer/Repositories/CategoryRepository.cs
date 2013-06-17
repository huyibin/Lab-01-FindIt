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

    public class CategoryRepository : BaseRepository, ICategoryRepository {
        public CategoryRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork) {
        }
        public void Create(Category category) {
            this.GetDbSet<Category>().Add(category);
            this.UnitOfWork.SaveChanges();
        }

        public Category GetCategory(Guid categoryId) {
            return this.GetDbSet<Category>()
                .Where(c => c.Id == categoryId)
                .Single();
        }

        public void Update(Category updatedCategory) {
            this.GetDbSet<Category>().Attach(updatedCategory);
            this.SetEntityState(updatedCategory, updatedCategory.Id == Guid.Empty
                ? EntityState.Added
                : EntityState.Modified);
            this.UnitOfWork.SaveChanges();
        }

        public void Delete(Guid categoryId) {
            Category CategoryToDelete = this.GetCategory(categoryId);
            this.GetDbSet<Category>().Remove(CategoryToDelete);
            this.UnitOfWork.SaveChanges();
        }

        public IEnumerable<Category> Find() {
            return this.GetDbSet<Category>().Take(100)
                .ToList();
        }

        public IEnumerable<Category> GetAll() {
            return this.GetDbSet<Category>().Take(100)
                .ToList();
        }
    }
}
