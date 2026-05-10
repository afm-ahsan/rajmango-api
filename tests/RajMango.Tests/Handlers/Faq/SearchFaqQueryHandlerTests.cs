using FluentAssertions;
using RajMango.Application.Features.Faq;
using RajMango.Domain.Entities;
using RajMango.Tests.Helpers;
using Xunit;

namespace RajMango.Tests.Handlers.Faq
{
    public class SearchFaqQueryHandlerTests
    {
        [Fact]
        public async Task Handle_EmptyKeyword_ReturnsAllActiveItems()
        {
            using var db = TestDbContextFactory.Create();
            SeedFaqItems(db);
            var handler = new SearchFaqQueryHandler(db);

            var result = await handler.Handle(new SearchFaqQuery(""), CancellationToken.None);

            result.Succeeded.Should().BeTrue();
            result.Data.Should().HaveCount(2); // 2 active, 1 inactive
        }

        [Fact]
        public async Task Handle_KeywordMatch_ReturnsFilteredItems()
        {
            using var db = TestDbContextFactory.Create();
            SeedFaqItems(db);
            var handler = new SearchFaqQueryHandler(db);

            var result = await handler.Handle(new SearchFaqQuery("delivery"), CancellationToken.None);

            result.Succeeded.Should().BeTrue();
            result.Data.Should().HaveCount(1);
            result.Data[0].Question.Should().Contain("delivery");
        }

        [Fact]
        public async Task Handle_KeywordMatchesAnswer_ReturnsItem()
        {
            using var db = TestDbContextFactory.Create();
            SeedFaqItems(db);
            var handler = new SearchFaqQueryHandler(db);

            var result = await handler.Handle(new SearchFaqQuery("within 7 days"), CancellationToken.None);

            result.Succeeded.Should().BeTrue();
            result.Data.Should().HaveCount(1);
        }

        [Fact]
        public async Task Handle_NullKeyword_ReturnsAllActiveItems()
        {
            using var db = TestDbContextFactory.Create();
            SeedFaqItems(db);
            var handler = new SearchFaqQueryHandler(db);

            var result = await handler.Handle(new SearchFaqQuery(null), CancellationToken.None);

            result.Succeeded.Should().BeTrue();
            result.Data.Should().HaveCount(2);
        }

        private static void SeedFaqItems(RajMango.DataAccess.Contexts.AppDbContext db)
        {
            db.Get<FaqItem>().AddRange(
                new FaqItem { Question = "How does delivery work?", Answer = "We ship within 7 days.", Category = "Delivery", SortOrder = 1, IsActive = true, CreatedAt = DateTime.UtcNow },
                new FaqItem { Question = "How do I pay?", Answer = "bKash or cash.", Category = "Payment", SortOrder = 2, IsActive = true, CreatedAt = DateTime.UtcNow },
                new FaqItem { Question = "Old question", Answer = "Old answer.", Category = "Other", SortOrder = 3, IsActive = false, CreatedAt = DateTime.UtcNow }
            );
            db.SaveChanges();
        }
    }
}
