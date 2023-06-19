using FestivalHue.Data.Entities;
using FestivalHue.Data.Enums;
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
            modelBuilder.Entity<Category>().HasData(
               new Category()
               {
                   CategoryId = 1,
                   Name= "Le Hoi Duong Pho",
                  CreatedDate=DateTime.Now,
                  status=Status.Active
               },
                new Category()
                {
                    CategoryId = 2,
                    Name = "Kinh Do Am Thuc",
                    CreatedDate = DateTime.Now,
                    status = Status.Active
                });
            modelBuilder.Entity<Ticket>().HasData(
                new Ticket()
                {
                    IdVe = 1,
                    Name = "GheA1",
                    SeoDescription="Đây là vé hạng thương gia",
                    Price=300000
                }
                ,new Ticket(
                )
                {
                    IdVe=2,
                    Name="GheA2",
                    SeoDescription="Đây là vé hạng phổ thông ",
                    Price=500000
                }
                );
            modelBuilder.Entity<TicketInCategory>().HasData(
                new TicketInCategory() { TicketId = 1, CategoryId = 1 }
                );
            modelBuilder.Entity<Schedule>().HasData(
                new Schedule()
                {
                    IdSchedule=1,
                    Name="Star Hotel-Le Hoi Duong Pho",
                    Description="Ok",
                    CreatedDate=DateTime.Now,
                    TicketId=1
                }
                );

        }
    }
}
