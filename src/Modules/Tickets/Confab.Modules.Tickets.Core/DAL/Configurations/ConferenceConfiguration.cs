using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Confab.Modules.Tickets.Core.Entities;

namespace Confab.Modules.Tickets.Core.DAL.Configurations
{
    internal class ConferenceConfiguration : IEntityTypeConfiguration<Conference>
    {
        public void Configure(EntityTypeBuilder<Conference> builder)
        {
        }
    }
}