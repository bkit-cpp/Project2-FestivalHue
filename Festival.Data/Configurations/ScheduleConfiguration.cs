﻿using FestivalHue.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FestivalHue.Data.Configurations
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {

        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.ToTable("Schedules");
            builder.HasKey(x => x.IdSchedule);
            builder.Property(x => x.IdSchedule).UseIdentityColumn();
            builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
            builder.Property(x => x.CreatedDate).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(200).IsRequired();
            builder.HasOne(x => x.Ticket).
            WithMany(x => x.Schedules).HasForeignKey(x => x.TicketId);
        }
    }
}
