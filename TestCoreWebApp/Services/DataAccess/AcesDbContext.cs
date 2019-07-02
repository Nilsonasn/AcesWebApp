using Microsoft.EntityFrameworkCore;
using Services.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.DataAccess
{
    public class AcesDbContext : DbContext
    {
        public AcesDbContext(DbContextOptions<AcesDbContext> options)
            :base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
    }
}
