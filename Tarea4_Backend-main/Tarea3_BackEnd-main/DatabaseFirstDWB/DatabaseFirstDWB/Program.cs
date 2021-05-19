using DatabaseFirstDWB.BackEnd;
using DatabaseFirstDWB.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DatabaseFirstDWB
{
    class Program
    {
        #region Services
        public static EmployeeSC employeeService = new EmployeeSC();
        public static ProductSC productService = new ProductSC();
        public static OrderSC orderService = new OrderSC();
        #endregion

        #region MainExercises
        public static void Exersise1()
        {
            IQueryable<Employee> employeeQry = employeeService.GetAllEmployees();

            //Materializamos el query
            var output = employeeQry.ToList();

        }

        public static void Exersise2()
        {
            var employeeQry = employeeService.GetAllEmployees().Select(s => new
            {
                s.Title,
                s.FirstName,
                s.LastName
            }).Where(w => w.Title == "Sales Representative");
            var output = employeeQry.ToList();

            output.ForEach(fe => Console.WriteLine("Nombre: " + fe.FirstName + " " + fe.LastName));
        }

        public static void Exersise3()
        {

            var employeeQry = employeeService.GetAllEmployees().Select(s => new
            {
                Nombre = s.FirstName,
                Apellido = s.LastName,
                Puesto = s.Title
            }).Where(w => w.Puesto == "Sales Representative");

            var output = employeeQry.ToList();
            output.ForEach(fe => Console.WriteLine("Nombre: " + fe.Nombre + " " + fe.Apellido));
            
        }
        public static void Exersise4(int id, string name)
        {
            employeeService.UpdateEmployeeFirstNameById(id, name);
        }


        public static void Exersise6(int id = 10)
        {
            employeeService.FireEmployee(id);
        }

        public static void Exersise7(int OrderId = 10248)
        {
            var qry = orderService.GetOrderById(OrderId).Select(s => new
            {
                Cliente = s.Customer.CompanyName,
                Vendedor = s.Employee.FirstName,
                Productos = s.OrderDetails.Select(se => se.Product.ProductName)
            });

            var result = qry.ToList();


        }

        public static void Exercise()
        {
            var employeeQry = employeeService.GetAllEmployees().Select(s => new
            {
                title = s.TitleOfCourtesy,
                name = s.FirstName,
                familyName = s.LastName
            }).Where(w => w.title == "Mr.");

            var result = employeeQry.ToList();
            result.ForEach(fe => Console.WriteLine(fe.title + " " + fe.name + " " + fe.familyName));
        }

        #endregion

        static void Main(string[] args)
        {
            //Exersise1();
            //Exersise2();
            Exercise();
        }
    }
}
