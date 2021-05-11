using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeAgencyLibrary;
using BikeStoreApi.Models;


namespace BikeStoreApi.Repositories
{
    public class EFAgencyRepository : IAgencyRepository
    {
        BikeRentalContext db;
        public EFAgencyRepository
            (BikeRentalContext _db)
        {
            db = _db;
        }

        //add methods to get bikes, customers, and rentals.
        public async Task<List<Bike>> GetBikes()
        {
            return await this.Bike.ToListAsync();
        }

        public async Task<Bike> GetBikeByID(int? bikeId)
        {
            var list = await GetBikes();
            return list.FirstOrDefault(b => b.BikeId == bikeId);
        }

        public async Task<Customer> GetCustomerByID(int? custId)
        {
            var list = await GetCustomers();
            return list.FirstOrDefault(b => b.CustomerId == custId);
        }

        public async Task<Rental> GetRentalsByID(int? rentalId)
        {
            var list = await GetRentals();
            return list.FirstOrDefault(b => b.RentalId == rentalId);
        }

        public async Task<List<Customer>> GetCustomers()
        {
            return await this.Customers.ToListAsync();
        }
        public async Task<List<Rental>> GetRentals()
        {
            return await this.Rentals.ToListAsync();
        }

        public IQueryable<Bike> Bike => db.Bikes;

        public IQueryable<Customer> Customers => db.Customers;
        public IQueryable<Rental> Rentals => db.Rentals;

        public async Task<int> AddBike(Bike bike)
        {
            if (db != null)
            {
                await db.Bikes.AddAsync(bike);
                await db.SaveChangesAsync();
            }
            return bike.BikeId;
        }

        public async Task<int> AddCustomer(Customer customer)
        {
            if (db != null)
            {
                await db.Customers.AddAsync(customer);
                await db.SaveChangesAsync();
            }
            return customer.CustomerId;
        }

        public async Task SaveBike(Bike bike)
        {
            if (db != null)
                db.Bikes.Update(bike);
            await db.SaveChangesAsync();
        }

        public async Task SaveCustomer(Customer customer)
        {
            if (db != null)
                db.Customers.Update(customer);
            await db.SaveChangesAsync();
        }

        public async Task<int> DeleteBike(int? BikeId)
        {
            int remove = 0;
            Bike bike = new Bike();
            if (db != null)
            {
                bike = await db.Bikes.FirstOrDefaultAsync(x => x.BikeId == BikeId);
            }
            if (db != null)
            {
                db.Bikes.Remove(bike);
                remove = await db.SaveChangesAsync();
            }
            return remove;
        }

        public async Task<int> DeleteCustomer(int? CustID)
        {
            int remove = 0;
            Customer customer = new Customer();
            if (db != null)
            {
                customer = await db.Customers.FirstOrDefaultAsync(x => x.CustomerId == CustID);
            }
            if (db != null)
            {
                db.Customers.Remove(customer);
                remove = await db.SaveChangesAsync();
            }
            return remove;
        }
        public async Task<int> DeleteRental(int? RentalID)
        {
            int remove = 0;
            Rental rental = new Rental();
            if (db != null)
            {
                rental = await db.Rentals.FirstOrDefaultAsync(x => x.RentalId == RentalID);
            }
            if (db != null)
            {
                db.Rentals.Remove(rental);
                remove = await db.SaveChangesAsync();
            }
            return remove;
        }
        public async Task SaveRental(Rental rental)
        {
            if (db != null)
                db.Rentals.Update(rental);
            await db.SaveChangesAsync();
        }
        public async Task<int> AddRental(Rental rental)
        {
            if (db != null)
            {
                await db.Rentals.AddAsync(rental);
                await db.SaveChangesAsync();
            }
            return rental.RentalId;
        }
        public async Task<int> AddEmployee(Employee employee)
        {
            if (db != null)
            {
                await db.Employees.AddAsync(employee);
                await db.SaveChangesAsync();
            }
            return employee.EmployeeId;
        }
        public async Task SaveEmployee(Employee employee)
        {
            if (db != null)
                db.Employees.Update(employee);
            await db.SaveChangesAsync();
        }
        public async Task<int> DeleteEmployee(int? EmployeeID)
        {
            int remove = 0;
            Employee employee = new();
            if (db != null)
            {
                employee = await db.Employees.FirstOrDefaultAsync(x => x.EmployeeId == EmployeeID);
            }
            if (db != null)
            {
                db.Employees.Remove(employee);
                remove = await db.SaveChangesAsync();
            }
            return remove;
        }
    }
}