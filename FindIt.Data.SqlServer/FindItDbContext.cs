using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using FindIt.Model;

namespace FindIt.Data.SqlServer {
    public partial class FindItDbContext : DbContext, IUnitOfWork {
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            SetupCategoryEntity(modelBuilder);
            SetupDigestEntity(modelBuilder);           
        }

        private static void SetupCategoryEntity(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Category>().ToTable("fi_category");
            modelBuilder.Entity<Category>().HasKey(c => c.Id);
        }
        public DbSet<Category> Categorys { get; set; }

        private static void SetupDigestEntity(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Digest>().ToTable("fi_digest");
            modelBuilder.Entity<Digest>().HasKey(c => c.Id);
        }
        public DbSet<Digest> Digests { get; set; }      


        /// <summary>
        /// Allows saving changes via the IUnitOfWork interface.
        /// </summary>
        void IUnitOfWork.SaveChanges() {
            base.SaveChanges();
        }
    }
}
