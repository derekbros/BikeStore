using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeAgencyLibrary;

namespace BikeRentalAgency.Repositories
{
    public interface IBikeRentalRepository
    {
        Task<bool> AddCustomer(Customer customer);
        Task<bool> DeleteCustomer(int? CustId);
        Task SaveCustomer(Customer customer);

        //Bike Methods
        Task<bool> AddBike(Bike bike);
        Task<bool> DeleteBike(int? BikeId);
        Task SaveBike(Bike bike);

        //Rental Methods
        Task<bool> AddRental(Rental rental);
        Task SaveRental(Rental rental);
        Task<bool> DeleteRental(int? rentalID);

        //Employee Methods  

        Task<bool> AddEmployee(Employee employee);
        Task<bool> DeleteEmployee(int? EmployeeId);
        Task SaveEmployee(Employee employee);

        Task<List<Bike>> GetBikes();

        Task<List<Customer>> GetCustomers();

        Task<List<Rental>> GetRentals();


        Task<Bike> GetBikeByID(int? bikeId);
        Task<Rental> GetRentalByID(int? rentalId);
        Task<Customer> GetCustomerByID(int? customerId);



        ////rentaldetail
        //IQueryable<Bike> Bike { get; }
        ////what types of things will be needed in a list
        //IQueryable<Customer> Customers { get; }

        //IQueryable<Rental> Rentals { get; }
    }
}
