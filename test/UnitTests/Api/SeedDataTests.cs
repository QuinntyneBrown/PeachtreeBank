using Microsoft.EntityFrameworkCore;
using PeachtreeBank.Api.Seeding;
using PeachtreeBank.Core.Data;
using System.Linq;
using Xunit;

namespace UnitTests.Api
{
    public class SeedDataTests
    {
        [Fact]
        public void ShouldImport10Transactions()
        {
            var options = new DbContextOptionsBuilder<PeachtreeBankDbContext>()
                .UseInMemoryDatabase($"{nameof(SeedDataTests)}:{nameof(ShouldImport10Transactions)}")
                .Options;

            var context = new PeachtreeBankDbContext(options);

            SeedData.Seed(context);
            
            Assert.Equal(10, context.Transactions.Count());

        }
    }
}
