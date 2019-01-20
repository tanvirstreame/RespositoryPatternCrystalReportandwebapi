using EmployeeManagement.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    public class EmployeeContex:DbContext
    {
        public EmployeeContex():base("Employee")
        {
            
        }
        public DbSet<Employee> Employee { get; set; }
    }
}
