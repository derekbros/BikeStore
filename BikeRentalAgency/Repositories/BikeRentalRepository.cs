using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using BikeStoreApi.Repositories;
using BikeAgencyLibrary;
using System.Net.Http.Json;

namespace BikeRentalAgency.Repositories
{
    public class BikeRentalRepository : IBikeRentalRepository
    {
        private string baseUrl = "https://localhost:44305/api/";
        public BikeRentalRepository()
        {
            this.GetAllBikes();
        }
        public List<Bike> Bikes { get; set; }
        public async void GetAllBikes()
        {
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(baseUrl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetPosts using HttpClient  
                HttpResponseMessage res = await client.GetAsync("Bike/GetBikes");

                //Checking the response is successful or not which is sent using HttpClient  
                if (res.IsSuccessStatusCode)
                {
                    //Storing the response details received from web api   
                    var response = res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response received from web api and storing into the Post list  
                    this.Bikes = JsonConvert.DeserializeObject<List<Bike>>(response);

                }

            }
        }

        //add methods to get bikes, customers, and rentals.
        public async Task<List<Bike>> GetBikes()
        {
            List<Bike> bikes = new List<Bike>();
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(baseUrl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetPosts using HttpClient  
                HttpResponseMessage res = await client.GetAsync("Bike/GetBikes");

                //Checking the response is successful or not which is sent using HttpClient  
                if (res.IsSuccessStatusCode)
                {
                    //Storing the response details received from web api   
                    var response = res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response received from web api and storing into the Post list  
                    bikes = JsonConvert.DeserializeObject<List<Bike>>(response);

                }
                //returning the bikes list to view 
                return bikes;
            }
        }
        public async Task<List<Rental>> GetRentals()
        {
            List<Rental> rentals = new List<Rental>();
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(baseUrl);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("Rental/GetRentals");

                if (res.IsSuccessStatusCode)
                {
                    var response = res.Content.ReadAsStringAsync().Result;


                    rentals = JsonConvert.DeserializeObject<List<Rental>>(response);

                }

                return rentals;
            }
        }
        public async Task<List<Customer>> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(baseUrl);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("Customer/GetCustomers");

                if (res.IsSuccessStatusCode)
                {
                    var response = res.Content.ReadAsStringAsync().Result;


                    customers = JsonConvert.DeserializeObject<List<Customer>>(response);

                }
                return customers;
            }
        }

        public async Task<Bike> GetBikeByID(int? bikeId)
        {
            Bike bike = new Bike();
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(baseUrl);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync($"Bike/GetBikeByID?bikeId={bikeId}");

                if (res.IsSuccessStatusCode)
                {
                    var response = res.Content.ReadAsStringAsync().Result;

                    bike = JsonConvert.DeserializeObject<Bike>(response);

                }
            }
            return bike;
        }
        public async Task<Customer> GetCustomerByID(int? custId)
        {
            Customer customer = new Customer();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync($"Customer/GetCustomerByID?CustId={custId}");

                if (res.IsSuccessStatusCode)
                {
                    var response = res.Content.ReadAsStringAsync().Result;

                    customer = JsonConvert.DeserializeObject<Customer>(response);

                }
            }
            return customer;
        }

        public async Task<Rental> GetRentalByID(int? rentalId)
        {
            Rental rental = new Rental();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync($"Rental/GetRentalsByID?rentalId={rentalId}");

                if (res.IsSuccessStatusCode)
                {
                    var response = res.Content.ReadAsStringAsync().Result;

                    rental = JsonConvert.DeserializeObject<Rental>(response);

                }
            }
            return rental;
        }
        public async Task<bool> AddCustomer(Customer customer)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(baseUrl);

                HttpResponseMessage res = await client.PostAsJsonAsync(
                    "customer/AddCustomer", customer);
                return res.IsSuccessStatusCode;

            }
        }
        public async Task<bool> AddRental(Rental rental)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(baseUrl);

                HttpResponseMessage res = await client.PostAsJsonAsync(
                    "rental/AddRental", rental);
                return res.IsSuccessStatusCode;

            }
        }
        public async Task<bool> AddBike(Bike bike)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(baseUrl);

                HttpResponseMessage res = await client.PostAsJsonAsync(
                    "Bike/Addbike", bike);
                return res.IsSuccessStatusCode;

            }
        }
        public async Task<bool> AddEmployee(Employee employee)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(baseUrl);

                HttpResponseMessage res = await client.PostAsJsonAsync(
                    "Employee/AddEmployee", employee);
                return res.IsSuccessStatusCode;
            }
        }
        public async Task<bool> DeleteCustomer(int? custId)
        {
            bool succeeded = false;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                HttpResponseMessage res = await client.DeleteAsync(
                    $"customer/DeleteCustomer?custId={custId}");
                succeeded = res.IsSuccessStatusCode;
            }
            return succeeded;
        }
        public async Task<bool> DeleteBike(int? BikeId)
        {
            bool succeeded = false;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                HttpResponseMessage res = await client.DeleteAsync(
                    $"bike/DeleteBike?bikeId={BikeId}");
                succeeded = res.IsSuccessStatusCode;
            }
            return succeeded;
        }
        public async Task<bool> DeleteEmployee(int? EmployeeId)
        {
            bool succeeded = false;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                HttpResponseMessage res = await client.DeleteAsync(
                    $"employee/DeleteEmployee?EmployeeId={EmployeeId}");
                succeeded = res.IsSuccessStatusCode;
            }
            return succeeded;
        }
        public async Task<bool> DeleteRental(int? RentalId)
        {
            bool succeeded = false;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                HttpResponseMessage res = await client.DeleteAsync(
                    $"rental/DeleteRental?RentalId={RentalId}");
                succeeded = res.IsSuccessStatusCode;
            }
            return succeeded;
        }
        public async Task<bool> SaveCustomer(Customer customer)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                HttpResponseMessage res = await client.PutAsJsonAsync(
                    "customer/SaveCustomer", customer);
                return res.IsSuccessStatusCode;

            }
        }
        public async Task<bool> SaveRental(Rental rental)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                HttpResponseMessage res = await client.PutAsJsonAsync(
                    "rental/SaveRental", rental);
                return res.IsSuccessStatusCode;

            }
        }
        public async Task<bool> SaveEmployee(Employee employee)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                HttpResponseMessage res = await client.PutAsJsonAsync(
                    "employee/SaveEmployee", employee);
                return res.IsSuccessStatusCode;
            }
        }
        public async Task<bool> SaveBike(Bike bike)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                HttpResponseMessage res = await client.PutAsJsonAsync(
                    "bike/SaveBike", bike);
                return res.IsSuccessStatusCode;

            }
        }

    }
}


