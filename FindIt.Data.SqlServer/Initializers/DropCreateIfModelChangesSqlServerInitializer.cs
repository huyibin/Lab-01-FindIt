﻿

namespace FindIt.Data.SqlServer.Initializers {
    using System;
    using System.Data.Entity;
    using FindIt.SqlServer.Initializers;
    using System.Transactions;

    /// An implementation of IDatabaseInitializer that will <b>DELETE</b>, recreate, and optionally re-seed the
    /// database only if the model has changed since the database was created.  This is achieved by writing a
    /// hash of the store model to the database when it is created and then comparing that hash with one
    /// generated from the current model.
    /// To seed the database, create a derived class and override the Seed method.
    /// </summary>
    internal class DropCreateIfModelChangesSqlServerInitializer<TContext> : SqlServerInitializer<TContext>
        where TContext : DbContext {
        #region Strategy implementation

        /// <summary>
        /// Executes the strategy to initialize the database for the given context.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void InitializeDatabase(TContext context) {
            if (context == null) {
                throw new ArgumentNullException("context");
            }

            var replacedContext = ReplaceSqlCeConnection(context);

            bool databaseExists;
            using (new TransactionScope(TransactionScopeOption.Suppress)) {
                databaseExists = replacedContext.Database.Exists();
            }

            //if (databaseExists) {
            //    if (context.Database.CompatibleWithModel(throwIfNoMetadata: true)) {
            //        return;
            //    }

            //    replacedContext.Database.Delete();
            //}

            //// Database didn't exist or we deleted it, so we now create it again.
            //context.Database.Create();
            //context.SaveChanges();
        }

        #endregion
    }
}