using DatabaseFirstDWB.DataAccess;
using DatabaseFirstDWB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstDWB.BackEnd
{
    public class EmployeeSC : BaseSC
    {

        public IQueryable<Employee> GetAllEmployees()
        {
            
            return dbContext.Employees.Select(s => s);
        }
        public IQueryable<EmployeeTerritory> GetAllEmployeesTerritories()
        {
            ;
            return dbContext.EmployeeTerritories.Select(s => s);
        }
        public ICollection<Order> GetOrders()
        {
            
            return dbContext.Orders.Select(s => s).ToList();
        }
        public ICollection<OrderDetail> GetOrdersDetail()
        {
            
            return dbContext.OrderDetails.Select(s => s).ToList();
        }
        public ICollection<OrderDetail> GetOrdersDetailByOrderId(int orderid)
        {
           
            return GetOrdersDetail().Where(detail => detail.OrderId == orderid).ToList();
        }
        public ICollection<Order> GetOrdersByEmployeeId(int employeeid)
        {
            
            return GetOrders().Where(w => w.EmployeeId == employeeid).ToList();
        }


        public ICollection<EmployeeTerritory> GetEmployeeTerritoriesByEmployeeId(int employeeid)
        {
           
            return GetAllEmployeesTerritories().Where(w => w.EmployeeId == employeeid).ToList();
        }
        public Employee GetEmployeeById(int id)
        {
            
            return GetAllEmployees().Where(w => w.EmployeeId == id).FirstOrDefault();
        }
        public ICollection<Employee> GetEmployeesReporsto(int id)
        {
            return GetAllEmployees().Where(reporsto => reporsto.ReportsTo == id).ToList();

        }
        public void FireEmployee(int id)
        {

            var territorylist = GetEmployeeTerritoriesByEmployeeId(id);
            foreach (EmployeeTerritory et in territorylist)
            {
                dbContext.EmployeeTerritories.Remove(et);
                
            }
            dbContext.SaveChanges();

            var orderslist = GetOrdersByEmployeeId(id);
            foreach (Order or in orderslist)
            {
                var orderdetaillist = GetOrdersDetailByOrderId(or.OrderId);
                foreach (OrderDetail od in orderdetaillist)
                {
                   
                    dbContext.OrderDetails.Remove(od);
                    
                }
                dbContext.Orders.Remove(or);
                
            }
            dbContext.SaveChanges();

            var employeelistact = GetEmployeesReporsto(id);
            foreach (Employee em in employeelistact)
            {
                em.ReportsTo = null;
                dbContext.Employees.Update(em);
            }
            dbContext.SaveChanges();

            var firedEmployee = GetEmployeeById(id);
            //Console.WriteLine(firedEmployee.FirstName);
            dbContext.Employees.Remove(firedEmployee);
            dbContext.SaveChanges();
        }

        public void UpdateEmployeeFirstNameById(int id, string name)
        {
            Employee currentEmployee = GetEmployeeById(id);
            if (currentEmployee == null)
            {
                throw new Exception("No se encontro el empleado con el ID proporcionado");
            }

            currentEmployee.FirstName = name;
            dbContext.SaveChanges();
        }

        public void UpdateEmployee(int id, EmployeeModel employee)
        {
            Employee currentEmplpyee = GetEmployeeById(id);
            if (currentEmplpyee == null)
            {
                throw new Exception("No se encontró el empleado con el ID proporcionado");
            }
            currentEmplpyee.FirstName = employee.Name;
            currentEmplpyee.LastName = employee.FamilyName;
            dbContext.SaveChanges();
        }

        public void AddEmployee(EmployeeModel newEmployee)
        {
            var newEmployeeRegister = new Employee()
            {
                FirstName = newEmployee.Name,
                LastName = newEmployee.FamilyName
            };

            dbContext.Employees.Add(newEmployeeRegister);
            dbContext.SaveChanges();

        }

    }
}
