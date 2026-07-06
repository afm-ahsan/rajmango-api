using FluentAssertions;
using RajMango.Shared;
using Xunit;

namespace RajMango.Tests.Authorization
{
    public class PaymentRefundPermissionTests
    {
        [Fact]
        public void AdminPermissions_IncludesPaymentAdminRefund()
        {
            Permissions.AdminPermissions.Should().Contain(Permissions.Payments.AdminRefund);
        }

        [Fact]
        public void GeneralPermissions_DoesNotIncludePaymentAdminRefund()
        {
            // Customer (self_register) role must never be granted refund access.
            Permissions.GeneralPermissions.Should().NotContain(Permissions.Payments.AdminRefund);
        }

        [Fact]
        public void AdminPermissions_IncludesPaymentAdminReconcile()
        {
            Permissions.AdminPermissions.Should().Contain(Permissions.Payments.AdminReconcile);
        }

        [Fact]
        public void GeneralPermissions_DoesNotIncludePaymentAdminReconcile()
        {
            // Customer (self_register) role must never be able to Query/Search/Reconcile bKash payments.
            Permissions.GeneralPermissions.Should().NotContain(Permissions.Payments.AdminReconcile);
        }
    }
}
