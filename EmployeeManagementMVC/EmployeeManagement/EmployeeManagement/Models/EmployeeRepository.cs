using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Models
{
    public class EmployeeRepository
    {
        private static List<Employee> _employees;
        static EmployeeRepository()
        {
            _employees = new List<Employee>()
            {
                new Employee {EmployeeId = 1, FirstName = "Zachary", LastName = "Stone", Phone = "859-539-1923", DepartmentId = 1},
                new Employee {EmployeeId = 2, FirstName = "Penni", LastName = "Stone", Phone = "859-749-7768", DepartmentId = 2},
                new Employee {EmployeeId = 3, FirstName = "Paul", LastName = "Baity", Phone = "919-417-3018", DepartmentId = 3},

            };
        }

        public static void Add(Employee employee)
        {
            //checking if there are any employees
            if(_employees.Any())
            {
                //if already existing employees, make this new employees Id be one higher than the max ID number.
                employee.EmployeeId = _employees.Max(e => e.EmployeeId) + 1;
            }
            else
            {
                employee.EmployeeId = 1;
           
            }
            _employees.Add(employee);
        }

        public static void Edit(Employee employee)
        {
            Employee found = _employees.First(e => e.EmployeeId == e.EmployeeId);
            found = employee;
        }

        public static void Delete(int employeeId)
        {
            _employees.RemoveAll(e => e.EmployeeId == employeeId);
        }

        public static Employee Get(int employeeId)
        {
            return _employees.FirstOrDefault(e => e.EmployeeId == employeeId);
        }

        public static List<Employee> GetAll()
        {
            return _employees;
        }
    }
}