using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.SqlClient;

namespace FindIt.SqlServer.Initializers {
    internal abstract class SqlServerInitializer<T> : IDatabaseInitializer<T> where T : DbContext {
        public abstract void InitializeDatabase(T context);

        #region Helpers

        /// <summary>
        /// Returns a new DbContext with the same SqlCe connection string, but with the |DataDirectory| expanded
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        protected static DbContext ReplaceSqlCeConnection(DbContext context) {
            if (context.Database.Connection is SqlConnection) {
                SqlConnectionStringBuilder builder = 
                    new SqlConnectionStringBuilder(context.Database.Connection.ConnectionString);
                return new DbContext(builder.ConnectionString);
            }
            return context;
        }

        #endregion
    }
}
