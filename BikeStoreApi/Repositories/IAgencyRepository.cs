using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeAgencyLibrary;

namespace BikeStoreApi.Repositories
{
    public interface IAgencyRepository
    {
        //Customer Methods
       Task<int> AddCustomer(Customer customer);
        Task<int> DeleteCustomer(int? CustId);
        Task SaveCustomer(Customer customer);

        //Bike Methods
       Task<int> AddBike(Bike bike);
       Task<int> DeleteBike(int? BikeId);
       Task SaveBike(Bike bike);

        //Rental Methods
        Task<int> AddRental(Rental rental);
        Task SaveRental(Rental rental);
        Task<int> DeleteRental(int? rentalID);
      
      //Employee Methods  
        
        Task<int> AddEmployee(Employee employee);
        Task<int> DeleteEmployee(int? EmployeeId);
        Task SaveEmployee(Employee employee);
       
        //Add more here if needed


        //rentaldetail
        IQueryable<Bike> Bike { get; }
        //what types of things will be needed in a list
        IQueryable<Customer> Customers { get; }

        IQueryable<Rental> Rentals { get; }

        //
     
    }
}