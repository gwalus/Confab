using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Confab.Modules.Tickets.Core.Entities;

namespace Confab.Modules.Tickets.Core.DAL.Configurations
{
    internal class TicketSaleConfiguration : IEntityTypeConfiguration<TicketSale>
    {
        public void Configure(EntityTypeBuilder<TicketSale> builder)
        {
        }
    }
}