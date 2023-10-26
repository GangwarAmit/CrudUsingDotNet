using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Mvc.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter first name")]
        [Display(Name = "First Name")]
        public string First_Name { get; set; }
        [Required(ErrorMessage = "Enter Last name")]
        [Display(Name = "Last Name")]
        public string Last_Name { get; set; }
        [Required(ErrorMessage = "Enter Class")]
        [Display(Name = "Class Name")]
        public string? Class { get; set; }
        [Required(ErrorMessage = "Enter Roll No")]
        [Display(Name = "Roll No ")]
        public int Roll_No { get; set; }
        [Required(ErrorMessage = "Enter Percentage ")]
        [Display(Name = "Percentage ")]
        public decimal Percentage { get; set; }

    }
}
