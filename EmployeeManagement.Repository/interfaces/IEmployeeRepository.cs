using EmployeeManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.interfaces
{
   public interface IEmployeeRepository:IDisposable
    {
        IEnumerable<Employee> GetEmpolyee();
        void Add(Employee employee);
        void Find(int id);
        int CheckLogIn(String email, string password);
        void save();
    }
}
