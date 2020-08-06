using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using Employees.Domain.Models;
using Employees.Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Employees.Api.Controllers
{
    [ApiController]
    [Route("api/v1/employees")]
    public class EmployeesController : ControllerBase
    {
        readonly ILogger<EmployeesController> logger;
        readonly IEmployeeRepository employeeRepository;

        public EmployeesController(ILogger<EmployeesController> logger, IEmployeeRepository employeeRepository)
        {
            this.logger = logger;
            this.employeeRepository = employeeRepository;
        }

        /// <summary>
        /// Gets a list of employees
        /// </summary>
        /// <returns>Returns the list of employees</returns>
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            return Ok(await employeeRepository.GetEmployeesAsync());
        }

        /// <summary>
        /// Upload employee CVS file
        /// </summary>
        /// <param name="employeeFile">Employee CVS file</param>
        /// <returns>Returns accepted if file was successfully uploaded</returns>
        [HttpPost]
        public async Task<IActionResult> UploadEmployeeDetails([FromForm] IFormFile employeeFile) //ToDo: Stream for larger files
        {
            logger.LogInformation("Processing employee cvs file");

            using (var reader = new StreamReader(employeeFile.OpenReadStream()))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.HasHeaderRecord = false;
                csv.Configuration.TrimOptions = TrimOptions.Trim;

                var records = csv.GetRecordsAsync<Employee>();

                logger.LogInformation("Completed processing employee cvs file");

                await employeeRepository.AddEmployeesAsync(records).ConfigureAwait(false);

                logger.LogInformation("Employee data saved to database");
            }

            return Accepted();
        }
    }
}
