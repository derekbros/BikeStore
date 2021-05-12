using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeAgencyLibrary;

namespace BikeRentalAgency.Repositories
{
    public interface IBikeRentalRepository
    {
        //Customer Methods
        Task<bool> AddCustomer(Customer customer);
        Task<bool> DeleteCustomer(int? CustId);
        Task<bool> SaveCustomer(Customer customer);

        //Bike Methods
        Task<bool> AddBike(Bike bike);
        Task<bool> DeleteBike(int? BikeId);
        Task<bool> SaveBike(Bike bike);

        //Rental Methods
        Task<bool> AddRental(Rental rental);
        Task<bool> SaveRental(Rental rental);
        Task<bool> DeleteRental(int? rentalID);

        //Employee Methods  
        Task<bool> AddEmployee(Employee employee);
        Task<bool> DeleteEmployee(int? EmployeeId);
        Task<bool> SaveEmployee(Employee employee);
        //Get Methods
        Task<List<Bike>> GetBikes();
        Task<List<Customer>> GetCustomers();
        Task<List<Rental>> GetRentals();
        Task<Bike> GetBikeByID(int? bikeId);
        Task<Rental> GetRentalByID(int? rentalId);
        Task<Customer> GetCustomerByID(int? customerId);
        List<Bike> Bikes { get; set; }
    }
}
