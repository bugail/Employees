using System;

namespace Employees.Domain.Models
{
    /// <summary>
    /// Employee object
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Gets or sets the title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the Firstname
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// Gets or sets the Lastname
        /// </summary>
        public string Lastname { get; set; }

        /// <summary>
        /// Gets or sets the gender
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Gets or sets the date of birth
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the role
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Gets or sets the salary
        /// </summary>
        public decimal Salary { get; set; }
    }
}