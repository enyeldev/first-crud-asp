using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstCrud.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstCrud.Domain.Data
{
    public class FirstCrudDbContext : DbContext
    {
        public FirstCrudDbContext(DbContextOptions<FirstCrudDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}