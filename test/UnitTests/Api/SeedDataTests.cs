using Microsoft.EntityFrameworkCore;
using PeachtreeBank.Api.Seeding;
using PeachtreeBank.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace UnitTests.Api
{
    public class SeedDataTests
    {
        [Fact]
        public void Test()
        {
            var options = new DbContextOptionsBuilder<PeachtreeBankDbContext>()
                .UseInMemoryDatabase($"{nameof(SeedDataTests)}:{nameof(Test)}")
                .Options;

            var context = new PeachtreeBankDbContext(options);

            SeedData.Seed(context);

            Assert.Equal(10, context.Transactions.Count());
        }
    }
}
