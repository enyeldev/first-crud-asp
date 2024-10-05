using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstCrudWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstCrudWeb.Data
{
    public class FirstCrudDbContext : DbContext
    {
        public FirstCrudDbContext(DbContextOptions<FirstCrudDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}