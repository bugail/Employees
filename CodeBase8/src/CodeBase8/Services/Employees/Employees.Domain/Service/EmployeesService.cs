using System.Collections.Generic;
using System.Threading.Tasks;
using Employees.Domain.Models;
using Employees.Domain.Service;

namespace Employees.Domain.Service
{
    public class EmployeesService : IEmployeesService
    {
        public Task AddEmployeesAsync(IEnumerable<Employee> Employees)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}