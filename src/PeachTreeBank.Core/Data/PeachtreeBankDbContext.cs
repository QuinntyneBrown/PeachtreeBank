using Microsoft.EntityFrameworkCore;
using PeachTreeBank.Core.Models;

namespace PeachTreeBank.Core.Data
{
    public class PeachtreeBankDbContext: DbContext, IPeachtreeBankDbContext
    {
        public PeachtreeBankDbContext(DbContextOptions options)
            : base(options) { }
        public DbSet<Transaction> Transactions { get; private set; }
    }
}
