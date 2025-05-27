using BethanysPieShopHRM.HR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShopHRM
{
    internal class Utilities
    {
        //private static string directory = @"..\..\..\";

        // This one for Windows
        //private static string directory = Directory.GetParent(Directory.
        //    GetCurrentDirectory()).Parent.Parent.FullName + @"\Data\";

        // This one for Codespaces paths
        private static string directory = Directory.GetParent
            (Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"/Data/";
        private static string fileName = "employees.txt";

        internal static void CheckForExistingEmployeeFile()
        {
            string path = $"{directory}{fileName}";
            bool existingFileFound = File.Exists(path);

            if (existingFileFound)
            {
                Console.WriteLine("An existing file with Employee data is found.");
            }
            else
            {
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Directory is ready for saving files.");
                    Console.ResetColor();
                }
            }
        }

        internal static void RegisterEmployee(List<Employee> employees)
        {
            Console.WriteLine("Creating an employee");

            Console.WriteLine("What type of employee do you want to register?");
            Console.WriteLine("1: Employee\n2: Manager\n3: Store Manager\n4: Researcher" +
                "\n5: Junior Researcher"); // Demonstrating using new lines to list the
                                           // menu in one WriteLine
            Console.WriteLine("Your selection: ");
            string employeeType = Console.ReadLine();

            if (employeeType != "1" && employeeType != "2" && employeeType != "3" &&
                employeeType != "4" && employeeType != "5")
            {
                Console.WriteLine("Invalid selection");
                return; // Return to the caller since there is nothing for this method
                        // to do
            }

            Console.WriteLine("Enter the first name: ");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter the last name: ");
            string lastName = Console.ReadLine();

            Console.WriteLine("Enter the email: ");
            string email = Console.ReadLine();

            Console.WriteLine("Enter the birth day (ex. 2/16/2008): ");
            DateTime birthDay = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter the hourly rate: ");
            string hourlyRate = Console.ReadLine();
            double rate = double.Parse(hourlyRate); // Assuming for now input is 
                                                    // in the correct format

            Employee employee = null;

            // No default since the earlier if ensures the type is valid
            switch (employeeType)
            {
                case "1":
                    employee = new Employee(firstName, lastName, email, birthDay,
                        rate);
                    break;
                case "2":
                    employee = new Manager(firstName, lastName, email, birthDay,
                        rate);
                    break;
                case "3":
                    employee = new StoreManager(firstName, lastName, email, birthDay,
                        rate);
                    break;
                case "4":
                    employee = new Researcher(firstName, lastName, email, birthDay,
                        rate);
                    break;
                case "5":
                    employee = new JuniorResearcher(firstName, lastName, email,
                        birthDay, rate);
                    break;
            }

            employees.Add(employee);

            Console.WriteLine("Employee created.\n\n");
        }

        internal static void ViewAllEmployees(List<Employee> employees)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                employees[i].DisplayEmployeeDetails();
            }
        }

        internal static void LoadEmployees(List<Employee> employees)
        {
            string path = $"{directory}{fileName}";

            try
            {
                if (File.Exists(path))
                {
                    employees.Clear();

                    // Read the employees to an array
                    string[] employeesAsString = File.ReadAllLines(path);
                    for (int i = 0; i < employeesAsString.Length; i++)
                    {
                        // Split each employee by ';' and save each piece to array
                        string[] employeeSplits = employeesAsString[i].Split(';');
                        string firstName = employeeSplits[0].Substring(
                            employeeSplits[0].IndexOf(':') + 1);
                        string lastName = employeeSplits[1].Substring(
                            employeeSplits[1].IndexOf(':') + 1);
                        string email = employeeSplits[2].Substring(
                            employeeSplits[2].IndexOf(':') + 1);
                        DateTime birthDay = DateTime.Parse(employeeSplits[3].
                            Substring(employeeSplits[3].IndexOf(':') + 1));
                        double hourlyRate = double.Parse(employeeSplits[4].
                            Substring(employeeSplits[4].IndexOf(':') + 1));
                        string employeeType = employeeSplits[5].Substring(
                            employeeSplits[5].IndexOf(':') + 1);

                        Employee employee = null;

                        switch (employeeType)
                        {
                            case "1":
                                employee = new Employee(firstName, lastName, email,
                                    birthDay, hourlyRate);
                                break;
                            case "2":
                                employee = new Manager(firstName, lastName, email,
                                    birthDay, hourlyRate);
                                break;
                            case "3":
                                employee = new StoreManager(firstName, lastName,
                                    email, birthDay, hourlyRate);
                                break;
                            case "4":
                                employee = new Researcher(firstName, lastName, email,
                                    birthDay, hourlyRate);
                                break;
                            case "5":
                                employee = new JuniorResearcher(firstName, lastName,
                                    email, birthDay, hourlyRate);
                                break;
                        }

                        employees.Add(employee);
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Loaded {employees.Count} employees!\n\n");
                    //Console.ResetColor();
                }
            }
            catch (IndexOutOfRangeException iex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went wrong parsing the file, please check the data."); ;
                Console.WriteLine(iex.Message);
                //Console.ResetColor();
            }
            catch (FileNotFoundException fnfex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Could not find the file.");
                Console.WriteLine(fnfex.Message);
                Console.WriteLine(fnfex.StackTrace);
                //Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went wrong while loading the file."); ;
                Console.WriteLine(ex.Message);
                //Console.ResetColor();
            }
            finally
            {
                Console.ResetColor();
            }
        }

        internal static void LoadEmployeeById(List<Employee> employees)
        {
            try
            {
                Console.WriteLine("Enter the Employee ID you want to view: ");
                int id = int.Parse(Console.ReadLine());
                Employee employee = employees[id];
                employee.DisplayEmployeeDetails();
            }
            catch (FormatException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("That's not the correct format to enter an id.\n\n");
                Console.ResetColor();
            }
        }

        internal static void SaveEmployees(List<Employee> employees)
        {
            string path = $"{directory}{fileName}";
            StringBuilder sb = new StringBuilder();
            foreach (Employee employee in employees)
            {
                string type = GetEmployeeType(employee);

                sb.Append($"firstName:{employee.FirstName};");
                sb.Append($"lastName:{employee.LastName};");
                sb.Append($"email:{employee.Email};");
                sb.Append($"birthDay:{employee.BirthDay};");
                sb.Append($"hourlyRate:{employee.HourlyRate};");
                sb.Append($"type:{type};");
                sb.Append(Environment.NewLine);

                // Problem is we don't know what type of employee this is since
                // they are all of type Employee, hence the GetEmployeeType method
            }

            File.WriteAllText(path, sb.ToString());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Saved employees successfully");
            Console.ResetColor();
        }

        private static string GetEmployeeType(Employee employee)
        {
            // We have to check for the most specific type first since
            // they all extend Employee
            if (employee is Manager)
            {
                return "2";
            }
            else if (employee is StoreManager)
            {
                return "3";
            }
            else if (employee is JuniorResearcher)
            {
                return "5";
            }
            else if (employee is Researcher)
            {
                return "4";
            }
            else if (employee is Employee)
            {
                return "1";
            }

            return "0";
        }
    }
}
