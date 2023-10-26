using Student_Mvc.Data;
using Student_Mvc.Interface;
using Student_Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Mvc.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly MDbContext _context;
        public StudentRepository(MDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Student> GetAllStudents( string serchtext="" )
        {
            if (!string.IsNullOrEmpty(serchtext)) {
                return _context.Student.Where(x => x.First_Name.Contains(serchtext)  || x.Class.Contains(serchtext) ||x.Roll_No.ToString().Contains(serchtext) || serchtext==null).ToList();
            }
            else
            {
                return _context.Student.ToList();
            }
            
        }

        public Student GetStudentById(int id)
        {
            return _context.Student.FirstOrDefault(s => s.Id == id);
        }

        public void CreateStudent(Student student)
        {
            _context.Student.Add(student);
            _context.SaveChanges();
        }
        public void UpdateStudent(Student student)
        {
            var existingStudent = _context.Student.Find(student.Id);
            if (existingStudent != null)
            {
                existingStudent.First_Name = student.First_Name;
                existingStudent.Last_Name = student.Last_Name;
                existingStudent.Class = student.Class;
                existingStudent.Roll_No = student.Roll_No;
                existingStudent.Percentage = student.Percentage;
                _context.Update(existingStudent);
                _context.SaveChanges();
            }
        }

        public void DeleteStudent(int id)
        {
            var existingStudent = _context.Student.Find(id);
            if (existingStudent != null)
            {
                _context.Student.Remove(existingStudent);
                _context.SaveChanges();
            }
        }
    }
}
