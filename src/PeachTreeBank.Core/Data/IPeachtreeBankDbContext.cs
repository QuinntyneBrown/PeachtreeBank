using Microsoft.EntityFrameworkCore;
using PeachtreeBank.Core.Models;

namespace PeachtreeBank.Core.Data
{
    public interface IPeachtreeBankDbContext
    {
        DbSet<Transaction> Transactions { get; }
    }
}
