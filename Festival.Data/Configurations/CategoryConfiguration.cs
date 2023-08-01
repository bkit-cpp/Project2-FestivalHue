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
    public class CategoryConfiguration : IEntityTypeConfiguration<CategoryOfEvent>
    {
        public void Configure(EntityTypeBuilder<CategoryOfEvent> builder)
        {

            builder.ToTable("Categories");

            builder.HasKey(x => x.CategoryId);

            builder.Property(x => x.CategoryId).UseIdentityColumn();
        }
    }
}
