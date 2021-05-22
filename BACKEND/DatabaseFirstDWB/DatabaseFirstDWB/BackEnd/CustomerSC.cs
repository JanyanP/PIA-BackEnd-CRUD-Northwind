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
        //EN ESTE METODO SE MANDA TRAER TODA LA LISTA DE CLIENTES 
        public IQueryable<Customer> GetAllCustomers ()
        {
            return dbContext.Customers.Select(s => s);
        }
        //EN ESTE METODO SE MANDA TRAER TODA LA LISTA DE ORDENES
        public ICollection<Order> GetOrders()
        {
            return dbContext.Orders.Select(s => s).ToList();
        }
        //EN ESTE METODO SE MANDA TRAER TODA LA LISTA DE ORDENES MEDIANTE ALGUN ID 
        public ICollection<Order> GetOrdersById(string id )
        {
            return GetOrders().Where(ordenes => ordenes.CustomerId == id).ToList();
        }
        //EN ESTE METODO SE MANDA TRAER TODA LA LISTA DE CLIENTES MEDIANTE ALGUN ID 
        public Customer GetCustomerById (string id)
        {
            return GetAllCustomers().Where(w => w.CustomerId == id).FirstOrDefault();
        }
        //EN ESTE METODO SE MANDA TRAER TODA LA LISTA DE DETALLE DE ORDEN
        public ICollection<OrderDetail> GetOrderDetails()
        {
            return dbContext.OrderDetails.Select(s => s).ToList();
        }
        //EN ESTE METODO SE MANDA TRAER TODA LA LISTA DE DETALLE DE ORDEN MEDIANTE ALGUN ID 
        public ICollection<OrderDetail> GetOrderDetailsById(int id)
        {
            return GetOrderDetails().Where(od => od.OrderId == id).ToList();
        }
        // MÉTODO PARA ELIMINAR UN CLIENTE
        public void RemoveCustomer(string id)
        {
            //SE GUARDAN TODAS LAS ORDENES QUE TENGAN EL ID DEL CLIENTE EN UNA LISTA 
            var ordersbyid = GetOrdersById(id);
            foreach (Order or in ordersbyid)
            {
                //SE GUARDAN TODOS LOS DETALLES DE ORDEN QUE TENGAN EL ID DE CADA ORDER DEL CLIENTE QUE SE ELIMINARA 
                var orderdetails = GetOrderDetailsById(or.OrderId);
                foreach (OrderDetail od in orderdetails)
                {
                    //SE BORRA CADA ORDEN DE DETALLE 
                    dbContext.OrderDetails.Remove(od);
                    dbContext.SaveChanges();
                }
                //SE BORRA CADA ORDEN 
                dbContext.Orders.Remove(or);

            }
            dbContext.SaveChanges();
            //SE BUSCA EL ID DEL CLIENTE EN LA LISTA 
            var removedCustomer = GetCustomerById(id);
            //SE ELIMINA EL CLIENTE 
            dbContext.Customers.Remove(removedCustomer);
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
