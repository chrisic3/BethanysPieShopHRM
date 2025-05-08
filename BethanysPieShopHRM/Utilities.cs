using BethanysPieShopHRM.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShopHRM
{
    internal class Utilities
    {
        private static string directory = @"C:\Users\cpstelly\source\repos\test\BethanysPieShopHRM\BethanysPieShopHRM\";
        private static string fileName = "employees.txt";

        internal static void RegisterEmployee(List<Employee> employees)
        {

        }

        internal static void CheckForExistingEmployeeFile()
        {
            //TODO: write code to check if file exists
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("TODO: write code to check if file exists");
            Console.ResetColor();
        }

        internal static void ViewAllEmployees(List<Employee> employees)
        {

        }

        internal static void LoadEmployees(List<Employee> employees)
        {

        }

        internal static void SaveEmployees(List<Employee> employees)
        {

        }
    }
}
