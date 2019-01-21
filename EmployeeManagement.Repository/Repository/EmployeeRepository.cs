using EmployeeManagement.Repository.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Entities;

namespace EmployeeManagement.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private EmployeeContex _context;

        public EmployeeRepository(EmployeeContex context)
        {
            this._context=context;
        }
        public void Add(Employee employee)
        {
            _context.Employee.Add(employee);
            _context.SaveChanges();
        }

        public int CheckLogIn(string email, string password)
        {
            var data = _context.Employee.Where(x => x.Email == email && x.password == password).FirstOrDefault();
            if (data != null)
            {
                return 1;
            }
            return 0;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Find(int id)
        {
            _context.Employee.Find(id); 
        }

        public List<Employee> GetEmpolyee()
        {
            var data=_context.Employee.ToList();
            return data;
        }

        public void save()
        {
            _context.SaveChanges();
        }
    }
}
