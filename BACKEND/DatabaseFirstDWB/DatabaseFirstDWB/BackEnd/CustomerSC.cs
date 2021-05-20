using DatabaseFirstDWB.DataAccess;
using DatabaseFirstDWB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstDWB.BackEnd
{
    public class CustomerSC : BaseSC
    {
        public IQueryable<Customer> GetAllCustomers ()
        {
            return dbContext.Customers.Select(s => s);
        }

        public ICollection<Order> GetOrders()
        {
            return dbContext.Orders.Select(s => s).ToList();
        }
        public ICollection<Order> GetOrdersById(string id )
        {
            return GetOrders().Where(ordenes => ordenes.CustomerId == id).ToList();
        }
        public Customer GetCustomerById (string id)
        {
            return GetAllCustomers().Where(w => w.CustomerId == id).FirstOrDefault();
        }
        public ICollection<OrderDetail> GetOrderDetails()
        {
            return dbContext.OrderDetails.Select(s => s).ToList();
        }
        public ICollection<OrderDetail> GetOrderDetailsById(int id)
        {
            return GetOrderDetails().Where(od => od.OrderId == id).ToList();
        }

        public void RemoveCustomer (string id)
        {
            var customer = (from mCustomer in dbContext.Customers
                            where mCustomer.CustomerId == id
                            select mCustomer).FirstOrDefault();


            dbContext.Customers.Remove(customer);
            dbContext.SaveChanges();
        }

        public void UpdateCustomer (string id, CustomerModel customer)
        {
            Customer currentCustomer = GetCustomerById(id);
            if (currentCustomer == null)
            {
                throw new Exception("No se encontró el cliente con el ID proporcionado");
            }
            currentCustomer.CompanyName = customer.name;
            currentCustomer.City = customer.cityName;
            currentCustomer.Phone = customer.phoneNumber;

            dbContext.SaveChanges();
        }

        public void AddCustomer (CustomerModel newCustomer)
        {
            var newCustomerRegister = new Customer()
            {
                CustomerId = newCustomer.idString,
                CompanyName = newCustomer.name,
                City = newCustomer.cityName,
                Phone = newCustomer.phoneNumber
            };

            dbContext.Customers.Add(newCustomerRegister);
            dbContext.SaveChanges();
        }
    }
}
