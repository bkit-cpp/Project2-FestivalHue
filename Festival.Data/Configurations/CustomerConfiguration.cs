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
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(x => x.IdCustomer);
            builder.Property(x => x.IdCustomer).UseIdentityColumn();
            builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
            builder.Property(x => x.City).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Address).HasMaxLength(200).IsRequired();
            builder.HasOne(x => x.AppUser).WithMany(x => x.Customers).HasForeignKey(x => x.UserId);

        }
    }
}
