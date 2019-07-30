using AcesWebApp.Models.Classrooms;
using AcesWebApp.Models.Students;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AcesWebApp.Models.DataAccess
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
