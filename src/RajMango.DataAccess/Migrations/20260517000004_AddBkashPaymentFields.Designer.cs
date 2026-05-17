using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using RajMango.DataAccess.Contexts;

#nullable disable

namespace RajMango.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20260517000004_AddBkashPaymentFields")]
    partial class AddBkashPaymentFields
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
        }
    }
}
