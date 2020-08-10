using Microsoft.EntityFrameworkCore;
using PeachtreeBank.Core.Models;
using System.Threading;
using System.Threading.Tasks;

namespace PeachtreeBank.Core.Data
{
    public interface IPeachtreeBankDbContext
    {
        DbSet<Transaction> Transactions { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
