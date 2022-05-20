using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using EF_CodeFirst_DB_demo.Models;

namespace EF_CodeFirst_DB_Demo1.Models
{
    public class EmpDeptDbContext : DbContext
    {
        public EmpDeptDbContext() : base("name=MyConn")
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}