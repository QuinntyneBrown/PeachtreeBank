using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PeachtreeBank.Core.Models;

namespace PeachtreeBank.Core.Data
{
    public class PeachtreeBankDbContext: DbContext, IPeachtreeBankDbContext
    {
        public PeachtreeBankDbContext() { }

        public PeachtreeBankDbContext(DbContextOptions options)
            : base(options) { }

        public static readonly ILoggerFactory ConsoleLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });
        public DbSet<Transaction> Transactions { get; private set; }
    }
}
