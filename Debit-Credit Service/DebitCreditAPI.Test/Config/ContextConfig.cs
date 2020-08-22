using DebitCreditAPI.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebitCreditAPI.Test.Config
{
    public class ContextConfig
    {
        public SqliteContext MyContext { get; set; }
        public SqliteContext getContext(string dbname)
        {
            if (MyContext == null)
            {
                var optionsBuilder = new DbContextOptionsBuilder<SqliteContext>();
                optionsBuilder.UseInMemoryDatabase(databaseName: dbname)
                    .EnableSensitiveDataLogging()
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                    .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
                MyContext = new SqliteContext(optionsBuilder.Options);
            }
            return MyContext;
        }
    }
}
