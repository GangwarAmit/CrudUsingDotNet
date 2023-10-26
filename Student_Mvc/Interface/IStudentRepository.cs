using Student_Mvc.Models;
using System.Collections.Generic;

namespace Student_Mvc.Interface
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAllStudents(string serchtext="");
        Student GetStudentById(int id);
        void CreateStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int id);

    }
}
