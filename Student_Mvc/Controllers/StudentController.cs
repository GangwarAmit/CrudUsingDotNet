using Microsoft.AspNetCore.Mvc;
using Student_Mvc.Data;
using Student_Mvc.Interface;
using Student_Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Mvc.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public IActionResult Index(string  searchText)
        {
            var result = _studentRepository.GetAllStudents(searchText);
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Create(Student model)
        {
            if (ModelState.IsValid)
            {
                var existingStudent = _studentRepository.GetAllStudents()
                    .FirstOrDefault(x => x.Roll_No == model.Roll_No);

                if (existingStudent != null)
                {
                    ViewBag.RollNumberExists = "Roll number already exists.";
                }
                else
                {
                    _studentRepository.CreateStudent(model);

                    TempData["Message"] = "Record saved.";
                }


                

                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = "Empty fields cannot be submitted.";
                return View(model);
            }
        }
        public IActionResult Edit(int id)
        {
            var student = _studentRepository.GetStudentById(id);
            if (student == null)
            {
                return NotFound(); // Handle not found case
            }
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student model)
        {
            if (ModelState.IsValid)
            {
                _studentRepository.UpdateStudent(model);
                TempData["Message"] = "Record updated.";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = "Empty fields cannot be submitted.";
                return View(model);
            }
        }

        public IActionResult Delete(int id)
        {
            var student = _studentRepository.GetStudentById(id);
            if (student != null)
            {
                _studentRepository.DeleteStudent(id);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _studentRepository.DeleteStudent(id);
            TempData["Message"] = "Record deleted.";
            return RedirectToAction("Index");
        }
    }
}
