using System.Collections.Generic;
using System.Threading.Tasks;
using Employees.Domain.Models;

namespace Employees.Domain.Service
{
    public interface IEmployeesService
    {
        Task AddEmployeesAsync(IEnumerable<Employee> Employees);
        Task<IEnumerable<Employee>> GetEmployeesAsync();
    }
}