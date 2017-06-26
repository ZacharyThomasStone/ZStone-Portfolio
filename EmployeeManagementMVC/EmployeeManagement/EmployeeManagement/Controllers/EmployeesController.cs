using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeesController : Controller
    {
        [HttpGet]
        public ActionResult List()
        {
           IEnumerable<EmployeeListViewModel> model = from employee in EmployeeRepository.GetAll()
                                                join department in DepartmentRepository.GetAll()
                                                on employee.DepartmentId equals department.DepartmentId
                                                select new EmployeeListViewModel()
                                                {
                                                    Name = employee.FirstName + " " + employee.LastName,
                                                    Phone = employee.Phone,
                                                    Department = department.DepartmentName,
                                                    EmployeeId = employee.EmployeeId,
                                                };
            return View(model);
        }
        [HttpGet]
        public ActionResult Add()
        {
            AddEmployeeViewModel model = new AddEmployeeViewModel();

            model.Departments = (from departments in DepartmentRepository.GetAll()
                                 select new SelectListItem()
                                 {
                                     Text = departments.DepartmentName,
                                     Value = departments.DepartmentId.ToString(),


                                 }).ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult Add(AddEmployeeViewModel model)
        {
            Employee employee = new Employee();
            employee.FirstName = model.FirstName;
            employee.LastName = model.LastName;
            employee.Phone = model.Phone;
            employee.DepartmentId = model.DepartmentId;

            EmployeeRepository.Add(employee);

            //instead of returning the view, you use this to redirect them to the "List" Action.
            return RedirectToAction("List");
        }
    }
}