using MiniORM;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniOrmApp.Data.Entities
{
    internal class SoftUniDbContext : DbContext
    {
        public SoftUniDbContext(string ConnectionString) : base(ConnectionString)
        {
        }

        public DbSet<Employee> Employees { get;  }
        public DbSet<Department> Departments { get;  }
        public DbSet<Project> Projects { get; }
        public DbSet<EmployeeProject> EmployeesProjects { get;  }
    }
}
