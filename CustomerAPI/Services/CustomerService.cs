using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerAPI.Interfaces;

namespace CustomerAPI.Services
{
    public class CustomerService : ICustomerService
    {

        public static List<Customer> _customers;
        public Customer GetCustomerById(int customerId)
        {
            return _customers.FirstOrDefault(p => p.CustomerID == customerId);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            if(_customers!=null)
            {
                return _customers;
            }
            _customers =new List<Customer>();

            for (int i = 1; i <= 20; i++)
            {
                _customers.Add(new Customer { CustomerID = i, 
                                            FirstName = "FirstName" + i, 
                                            MiddleName = "MiddleName" + i ,
                                            LastName = "LastName" + i,
                                            City = "City" + i,
                                            Country = "Country" + i,
                                            Address = "Address" + i 
                });
            }

            return _customers;
        }
        public void AddCustomer(Customer customer)
        {
            _customers.Add(customer);
        }
        public void UpdateCustomer(Customer customer, Customer updatedCustomer)
        {
            _customers.Remove(customer);
            _customers.Add(updatedCustomer);
        }
        public void DeletCustomer(Customer customer)
        {
            _customers.Remove(customer);
        }

    }
}
