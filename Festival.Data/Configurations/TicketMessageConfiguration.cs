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
    public class TicketMessageConfiguration : IEntityTypeConfiguration<TicketMessage>
    {
        public void Configure(EntityTypeBuilder<TicketMessage> builder)
        {
            builder.ToTable("TicketMessages");
            builder.HasKey(x=>x.Id);
            builder.Property(x => x.Message).HasMaxLength(200).IsRequired();
            builder.HasOne(t => t.Ticket).WithMany(pc => pc.TicketMessages)
               .HasForeignKey(pc => pc.TicketId);


        }
    }
}
