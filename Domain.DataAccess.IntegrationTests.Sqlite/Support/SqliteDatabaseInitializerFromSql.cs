using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using Domain.DataAccess.Support;

namespace Domain.DataAccess.IntegrationTests.Sqlite.Support
{
    public class SqliteDatabaseInitializerFromSql : IDatabaseInitializer<BrgDbContext>
    {
        public void InitializeDatabase(BrgDbContext context)
        {
            var dataDirectory = (string) AppDomain.CurrentDomain.GetData("DataDirectory");
            var sqlFiles =
                Directory.GetFiles(dataDirectory, "*.sql", SearchOption.AllDirectories)
                    .Where(_ => _.EndsWith("sql"))
                    .ToList();

            foreach (var sqlFile in sqlFiles)
            {
                context.Database.ExecuteSqlCommand(File.ReadAllText(sqlFile));
            }
        }
    }
}