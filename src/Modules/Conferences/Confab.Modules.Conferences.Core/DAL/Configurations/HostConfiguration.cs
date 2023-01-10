using Confab.Modules.Conferences.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Confab.Modules.Conferences.Core.DAL.Configurations
{
    internal class HostConfiguration : IEntityTypeConfiguration<Host>
    {
        public void Configure(EntityTypeBuilder<Host> builder)
        {
            // for example

            //builder.Property(x =>x.Name).IsRequired().HasMaxLength(100);
        }
    }
}
