using Microsoft.EntityFrameworkCore;
using PeachTreeBank.Core.Models;

namespace PeachTreeBank.Core.Data
{
    public interface IPeachtreeBankDbContext
    {
        DbSet<Transaction> Transactions { get; }
    }
}
