using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsoleApp.Models;
using Flurl.Http;

namespace ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Log("Retriving employees...");

            Employee[] employee = await "https://localhost:5003/api/v1/employees".GetJsonAsync<Employee[]>();

            Console.Clear();
            foreach (var item in employee)
            {
                WriteEmployee(item);
            }
            
            Console.ReadKey();
        }
        
        static void Log(string message)
        {
            Console.WriteLine($"[{DateTime.Now}] {message}");
        }

        static void WriteEmployee(Employee employee)
        {
            if (employee == null)
                return;

            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Title: {employee.Title}");
            Console.WriteLine($"Firstname: {employee.Firstname}");
            Console.WriteLine($"Latname: {employee.Lastname}");
            Console.WriteLine($"Gender: {employee.Gender}");
            Console.WriteLine($"DateOfBirth: {employee.DateOfBirth}");
            Console.WriteLine($"Email: {employee.Email}");
            Console.WriteLine($"Role: {employee.Role}");
            Console.WriteLine($"Salary: {employee.Salary}");
            Console.WriteLine("--------------------------------");
        }
    }
}
