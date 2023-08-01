using FestivalHue.Data.Entities;
using FestivalHue.Data.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalHue.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData(
              new AppConfig() { Key = "HomeTitle", Value = "This is home page of eShopSolution" },
              new AppConfig() { Key = "HomeKeyword", Value = "This is keyword of eShopSolution" },
              new AppConfig() { Key = "HomeDescription", Value = "This is description of eShopSolution" }
              );
            modelBuilder.Entity<CategoryOfEvent>().HasData(
               new CategoryOfEvent()
               {
                   CategoryId = 1,
                   Name= "Le Hoi Duong Pho",
                  CreatedDate=DateTime.Now,
                  status=Status.Active
               },
                new CategoryOfEvent()
                {
                    CategoryId = 2,
                    Name = "Kinh Do Am Thuc",
                    CreatedDate = DateTime.Now,
                    status = Status.Active
                });
            modelBuilder.Entity<Ticket>().HasData(
                new Ticket()
                {
                    Id = 1,
                    Name = "GheA1",
                    SeoDescription="Đây là vé hạng thương gia",
                    Price=300000,
                    Quantity=5,
                    IsBooked=true
                    
                }
                ,new Ticket(
                )
                {
                    Id=2,
                    Name="GheA2",
                    SeoDescription="Đây là vé hạng phổ thông ",
                    Price=500000,
                    Quantity=6,
                    IsBooked=true
                }
                );
            modelBuilder.Entity<NewsOfSchedule>().HasData(
             new NewsOfSchedule()
             {
                 Id = 1,
                TicketId=1,
                 EndedDate = DateTime.Now,
                 CreatedDate = DateTime.Now,
                 TripType = "QuyNhon-TPHCM",
                 Content="Day la Mot Chuyen Di thu Vi"

             }
             , new NewsOfSchedule(
             )
             {
                 Id = 2,
                 TicketId=2,
                 EndedDate=DateTime.Now,
                 CreatedDate=DateTime.Now,
                 TripType="Hue-DaNang",
                 Content = "Day la Mot Chuyen Di Tuyet Voi"

             }
             );
       
            modelBuilder.Entity<TicketInCategory>().HasData(
                new TicketInCategory() { TicketId = 1, CategoryId = 1 }
                );

            // any guid
            var roleId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            var adminId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "bakhaipth@gmail.com",
                NormalizedEmail = "bakhaipth@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "admin123"),
                SecurityStamp = string.Empty,
                FirstName = "Le",
                LastName = "BaKhai",
                Dob = new DateTime(2020, 01, 31)
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });
            modelBuilder.Entity<Customer>().HasData(
    new Customer()
    {
        IdCustomer = 1,
        UserId = adminId,
        Name="LebaKhai",
        Address="Quan 12",
        City="HCMC",

    }
    
    );

        }
    }
}
