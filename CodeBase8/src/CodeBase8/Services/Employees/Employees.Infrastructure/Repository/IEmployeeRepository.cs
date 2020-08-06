// <copyright file="IEmployeeRepository.cs" company="CodeBase8">
// Copyright (c) CodeBase8. All rights reserved.
// </copyright>

namespace Employees.Infrastructure.Repository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Employees.Domain.Models;

    /// <summary>
    /// Employee repository.
    /// </summary>
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Add employees.
        /// </summary>
        /// <param name="employees">List of employees to add to database.</param>
        /// <returns>Task result.</returns>
        Task AddEmployeesAsync(IAsyncEnumerable<Employee> employees);

        /// <summary>
        /// Get list of employees from database.
        /// </summary>
        /// <returns>List of employees from database.</returns>
        Task<IEnumerable<Employee>> GetEmployeesAsync();
    }
}