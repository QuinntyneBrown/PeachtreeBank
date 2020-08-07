using Microsoft.EntityFrameworkCore;
using PeachtreeBank.Core.Models;

namespace PeachtreeBank.Core.Data
{
    public class PeachtreeBankDbContext: DbContext, IPeachtreeBankDbContext
    {
        public PeachtreeBankDbContext()
        {

        }
        public PeachtreeBankDbContext(DbContextOptions options)
            : base(options) { }
        public DbSet<Transaction> Transactions { get; private set; }
    }
}
