

namespace FindIt.Data.SqlServer {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using FindIt.Data;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using FindIt.Data.SqlServer;
    using FindIt.Data.SqlServer.Initializers;

    public class RepositoryInitializer : IRepositoryInitializer {
        private IUnitOfWork unitOfWork;

        public RepositoryInitializer(IUnitOfWork unitOfWork) {
            if (unitOfWork == null) {
                throw new ArgumentNullException("unitOfWork");
            }

            this.unitOfWork = unitOfWork;

            Database.DefaultConnectionFactory = new SqlConnectionFactory("System.Data.SqlClient");

            // Sets the default database initialization code for working with Sql Server Compact databases
            Database.SetInitializer(new DropCreateIfModelChangesSqlServerInitializer<FindItDbContext>());
        }

        protected FindItDbContext Context {
            get { return (FindItDbContext)this.unitOfWork; }
        }

        public void Initialize() {
            //this.Context.Set<Country>().ToList().Count();

            //var indexes = this.Context.Database.SqlQuery<string>("SELECT INDEX_NAME FROM INFORMATION_SCHEMA.INDEXES;");

            //if (!indexes.Contains("IDX_FillupEntries_FillupEntryId")) {
            //    this.Context.Database.ExecuteSqlCommand("CREATE UNIQUE INDEX IDX_FillupEntries_FillupEntryId ON FillupEntries (FillupEntryId);");
            //}

            //if (!indexes.Contains("IDX_Reminders_ReminderId")) {
            //    this.Context.Database.ExecuteSqlCommand("CREATE UNIQUE INDEX IDX_Reminders_ReminderId ON Reminders (ReminderId);");
            //}

            //if (!indexes.Contains("IDX_VehiclePhotos_VehiclePhotoId")) {
            //    this.Context.Database.ExecuteSqlCommand("CREATE UNIQUE INDEX IDX_VehiclePhotos_VehiclePhotoId ON VehiclePhotos (VehiclePhotoId);");
            //}
        }
    }
}
