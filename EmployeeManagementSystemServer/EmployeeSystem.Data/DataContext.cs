using EmployeeSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Employee> EmployeeList { get; private set; }
        public DbSet<Position> PositionsList { get; private set; }
        public DbSet<PositionForEmployee> PositionForEmployeesList { get; private set; }
        public DataContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=sample_db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PositionForEmployee>()
                .HasKey(e => new { e.PositionId, e.EmployeeId });
        }

    }
}
