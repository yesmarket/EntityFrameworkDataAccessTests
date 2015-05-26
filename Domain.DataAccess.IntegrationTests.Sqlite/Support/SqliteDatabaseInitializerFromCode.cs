using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Infrastructure;
using Domain.DataAccess.Support;

namespace Domain.DataAccess.IntegrationTests.Sqlite.Support
{
    public class SqliteDatabaseInitializerFromCode : IDatabaseInitializer<BrgDbContext>
    {
        private static string _script;

        public void InitializeDatabase(BrgDbContext context)
        {
            //this doesn't work for Sqlite :(
            //var databaseScript = ((IObjectContextAdapter)context).ObjectContext.CreateDatabaseScript();

            //and this is realy slow! probably best to use the SqliteDatabaseInitializerFromSql initializer.
            if (string.IsNullOrEmpty(_script))
            {
                var config = new DbMigrationsConfiguration<BrgDbContext> { AutomaticMigrationsEnabled = true };
                var migrator = new DbMigrator(config);
                var scriptor = new MigratorScriptingDecorator(migrator);
                _script = scriptor.ScriptUpdate(null, null).Replace("[dbo].", string.Empty);
            }

            context.Database.ExecuteSqlCommand(_script);
        }
    }
}