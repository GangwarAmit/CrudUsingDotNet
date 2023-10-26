using Microsoft.EntityFrameworkCore;
using Student_Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Mvc.Data
{
    public class MDbContext:DbContext
    {
        public MDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Student> Student { get; set; }
        
    }
}
