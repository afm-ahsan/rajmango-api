using FluentAssertions;
using RajMango.Application.DTOs.Order;
using RajMango.Application.Features.Commands;
using RajMango.Application.Features.Services;
using RajMango.Shared.Enums;
using Xunit;

namespace RajMango.Tests.Handlers.Order
{
    public class OrderRuleTests
    {
        [Fact]
        public void Validate_TotalWeightBelowMinimum_ReturnsError()
        {
            var validator = new CreateOrderCommandValidator();
            var command = new CreateOrderCommand
            {
                OrderDetails = new[]
                {
                    new OrderDetailInputDto
                    {
                        MangoTypeId = 1,
                        CrateType = CrateType.None,
                        Quantity = 1,
                    }
                }
            };

            var result = validator.Validate(command);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(e => e.ErrorMessage.Contains("Minimum order is 10 kg"));
        }

        [Fact]
        public void CalculateTotals_MultipleCrates_ReturnsExpectedQuantityAndAmount()
        {
            var details = new[]
            {
                new OrderDetailInputDto
                {
                    MangoTypeId = 1,
                    CrateType = CrateType.Crate10Kg,
                    Quantity = 1,
                },
                new OrderDetailInputDto
                {
                    MangoTypeId = 2,
                    CrateType = CrateType.Crate20Kg,
                    Quantity = 2,
                },
            };

            var result = OrderCalculator.CalculateTotals(details, new Dictionary<int, decimal>
            {
                [1] = 100,
                [2] = 150,
            });

            result.TotalQuantity.Should().Be(50);
            result.TotalAmount.Should().Be(7000);
        }
    }
}
