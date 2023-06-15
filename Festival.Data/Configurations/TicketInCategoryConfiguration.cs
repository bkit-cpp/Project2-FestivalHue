using FestivalHue.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalHue.Data.Configurations
{
    public class TicketInCategoryConfiguration : IEntityTypeConfiguration<TicketInCategory>
    {
        public void Configure(EntityTypeBuilder<TicketInCategory> builder)
        {
            builder.HasKey(t => new { t.TicketId, t.CategoryId });

            builder.ToTable("TicketInCategories");

            builder.HasOne(t => t.Ticket).WithMany(pc => pc.TicketInCategories)
                .HasForeignKey(pc => pc.TicketId);

            builder.HasOne(t => t.Category).WithMany(pc => pc.TicketInCategories)
              .HasForeignKey(pc => pc.CategoryId);
        }
    }
}
