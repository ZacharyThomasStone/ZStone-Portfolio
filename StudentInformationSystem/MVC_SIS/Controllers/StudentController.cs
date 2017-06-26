using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercises.Models.Data;
using Exercises.Models.ViewModels;

namespace Exercises.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = StudentRepository.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new StudentVM();
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentVM studentVM)
        {
            studentVM.Student.Courses = new List<Course>();

            foreach (var id in studentVM.SelectedCourseIds)
                studentVM.Student.Courses.Add(CourseRepository.Get(id));

            studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

            StudentRepository.Add(studentVM.Student);

            return RedirectToAction("List");
        }
        [HttpGet]
        public ActionResult Edit(int studentId)
        {
            var student = StudentRepository.Get(studentId);
            var viewmodel = new StudentVM();
            var model = MajorRepository.GetAll();

            viewmodel.Student = student;
            viewmodel.SetMajorItems(MajorRepository.GetAll());
            return View(viewmodel);
        }
        [HttpPost]
        public ActionResult Edit(StudentVM studentVM)
        {
            if (ModelState.IsValid)
            {
                var major = MajorRepository.Get(studentVM.Student.Major.MajorId);
                studentVM.Student.Major = major;
                StudentRepository.Edit(studentVM.Student);
                return RedirectToAction("List");
            }
            else
            {
                return View("Edit", studentVM);
            }
       

        }

        [HttpGet]
        public ActionResult Delete(int studentId)
        {
            var student = StudentRepository.Get(studentId);
            var viewmodel = new StudentVM();
            viewmodel.Student = student;
           
            return View(viewmodel);
        }
        [HttpPost]
        public ActionResult Delete(StudentVM studentVM)
        {
            StudentRepository.Delete(studentVM.Student.StudentId);
            return RedirectToAction("List");
        }
        [HttpGet]
        public ActionResult EditAddress(int studentid, StudentVM studentVM)
        {

            var student = StudentRepository.Get(studentid);

            StudentRepository.SaveAddress(studentid, studentVM.Student.Address);
            var viewmodel = new StudentVM();
            var model = MajorRepository.GetAll();

            viewmodel.Student = student;
            viewmodel.SetMajorItems(MajorRepository.GetAll());
            return View(viewmodel);

        }
        [HttpPost]
        public ActionResult EditAddress()
        {

         
            return RedirectToAction("List");


        }

    }
}