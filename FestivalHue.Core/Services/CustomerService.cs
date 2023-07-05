using FestivalHue.Core.Interfaces;
using FestivalHue.Data.EF;
using FestivalHue.Data.Entities;
using FestivalHue.Utilities.Exceptions;
using FestivalHue.ViewModel.Categories;
using FestivalHue.ViewModel.Common;
using FestivalHue.ViewModel.Customer;
using FestivalHue.ViewModel.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalHue.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private FestivalHueDbContext _context;

        public CustomerService(FestivalHueDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(CustomerCreateRequest request)
        {
            var customer = new Customer()
            {
                Name = request.Name,
                 Address=request.Address,
                 City=request.City,
                 
                AppUser =new AppUser()
                {
                    LastName=request.LastName,
                    FirstName=request.FirstName,
                    Dob=DateTime.Now,
                   
                }

            };
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer.IdCustomer;
        }

        public async Task<int> Delete(int customerId)
        {
            var customer = await _context.Customers.FindAsync(customerId);
            if (customer == null)
                throw new FestivalHueException($"Can't find customer with id:{customerId}");
            _context.Customers.Remove(customer);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<CustomerVm>> GetAllAsync()
        {
            var query = from c in _context.Customers
                        join ct in _context.AppUsers on c.UserId equals ct.Id
                        select new { c,ct };//Truy Van LinQ
            return await query.Select(x => new CustomerVm()
            {
                IdCustomer=x.c.IdCustomer,
                Name=x.c.Name,
                Address=x.c.Address,
                City=x.c.City,
               LastName=x.ct.LastName,
               FirstName=x.ct.FirstName,
               Dob=DateTime.Now
            }).ToListAsync();
        }

        public async Task<CustomerVm> GetById(int customerId)
        {
            var query = from c in _context.Customers
                        join ct in _context.AppUsers on c.UserId equals ct.Id
                        where c.IdCustomer == customerId
                        select new { c ,ct};
            return await query.Select(x => new CustomerVm()
            {
                IdCustomer=x.c.IdCustomer,
                Name = x.c.Name,
                Address = x.c.Address,
                City = x.c.City,
                LastName = x.ct.LastName,
                FirstName = x.ct.FirstName,
                Dob = DateTime.Now

            }).FirstOrDefaultAsync();
        }

 
        public async Task<int> Update(CustomerUpdateRequest request)
        {
            var customer = await _context.Customers.FindAsync(request.IdCustomer);
          
            if (customer == null )
                throw new FestivalHueException($"Can't find product with id:{request.IdCustomer}");
            customer.Name = request.Name;
            customer.Address = request.Address;
            customer.City = request.City;
            return await _context.SaveChangesAsync();
        }
        
    }
}
