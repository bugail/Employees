using System.Collections.Generic;
using System.Threading.Tasks;
using Employees.Domain.Models;

namespace Employees.Infrastructure.Repository
{
    public class EmployeeRepository : RepositoryBase, IEmployeeRepository
    {
        public EmployeeRepository(string connectionString)
            : base(connectionString) {  }

        public async Task AddEmployeesAsync(IAsyncEnumerable<Employee> employees)
        {
            await foreach(var employee in employees)
            {
                await ExecuteStoreProcedureAsync("[AddEmployees]", new {
                    Title = employee.Title,
                    Firstname = employee.Firstname,
                    Lastname = employee.Lastname,
                    Gender = employee.Gender,
                    DateOfBirth = employee.DateOfBirth,
                    Email = employee.Email,
                    Role = employee.Role,
                    Salary = employee.Salary
                });
            }
        }

        public Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return QueryStoreProcedureAsync<Employee>("[GetEmployees]");
        }
    }
}