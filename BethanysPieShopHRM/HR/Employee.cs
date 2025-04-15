using System;
using BethanysPieShopHRM.Logic;
using Newtonsoft.Json;

namespace BethanysPieShopHRM.HR
{
    internal class Employee
    {
        // Need to change these all to private and add methods
        private string firstName;
        private string lastName;
        private string email;
        private int numberOfHoursWorked;
        private double wage;
        private double? hourlyRate; // ? means this type is nullable
        private DateTime birthDay;
        private const int MinimalHoursWorkedUnit = 1;
        private EmployeeType employeeType;

        public static double taxRate = 0.15;

        // PROPERTIES
        #region Properties

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        public int NumberOfHoursWorked
        {
            get
            {
                return numberOfHoursWorked;
            }
            private set // Only the Employee class can set this value
            {
                numberOfHoursWorked = value;
            }
        }

        public double Wage
        {
            get
            {
                return wage;
            }
            private set
            {
                wage = value;
            }
        }

        public double? HourlyRate
        {
            get
            {
                return hourlyRate;
            }
            set
            {
                // Validate if the value entered is greater than 0
                if (value < 0)
                {
                    hourlyRate = 0;
                }
                else
                {
                    hourlyRate = value;
                }
            }
        }

        public DateTime BirthDay
        {
            get
            {
                return birthDay;
            }
            set
            {
                birthDay = value;
            }
        }

        public EmployeeType EmployeeType
        {
            get
            {
                return employeeType;
            }
            set
            {
                employeeType = value;
            }
        }

        #endregion

        public Employee(string firstName, string lastName, string email, 
            DateTime birthDay, double? hourlyRate, EmployeeType employeeType)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.birthDay = birthDay;
            // ?? is null coalesce, 10 is default if null
            this.hourlyRate = hourlyRate ?? 10; 
            this.employeeType = employeeType;
        }

        // The ": this()" calls the other constructor and passes it
        // the required parameters.
        public Employee(string firstName, string lastName, string email, 
            DateTime birthDay) : this(firstName, lastName, email, birthDay, 0,
            EmployeeType.StoreManger)
        {
        }

        public void PerformWork()
        {
            // Call the overloaded method instead of duplicating
            PerformWork(MinimalHoursWorkedUnit);

            //numberOfHoursWorked++;
            //Console.WriteLine($"{firstName} {lastName} has worked for " +
            //  $"{numberOfHoursWorked} hour(s).");
        }

        public void PerformWork(int numberOfHoursWorked)
        {
            this.numberOfHoursWorked += numberOfHoursWorked;
            Console.WriteLine($"{firstName} {lastName} has worked for " +
                $"{numberOfHoursWorked} hour(s).");
        }

        public int CalculateBonus(int bonus)
        {
            if (numberOfHoursWorked > 10)
            {
                bonus *= 2;
            }

            Console.WriteLine($"The employee got a bonus of {bonus}");
            return bonus;
        }

        /* // ref has to be initialized in the caller progam before calling
        public int CalculateBonusAndBonusTax(int bonus, ref int bonusTax)
        {
            if (numberOfHoursWorked > 10)
            {
                bonus *= 2;
            }

            if (bonus >= 200)
            {
                bonusTax = bonus / 10;
                bonus -= bonusTax;
            }

            Console.WriteLine($"The employee got a bonus of {bonus} and the " +
                $"tax on the bonus is {bonusTax}");
            return bonus;
        } */

        // out does not have to be initialized in the caller progam before calling,
        // but it does have to be initialized in the method before returning
        public int CalculateBonusAndBonusTax(int bonus, out int bonusTax)
        {
            bonusTax = 0;
            
            if (numberOfHoursWorked > 10)
            {
                bonus *= 2;
            }

            if (bonus >= 200)
            {
                bonusTax = bonus / 10;
                bonus -= bonusTax;
            }

            Console.WriteLine($"The employee got a bonus of {bonus} and the " +
                $"tax on the bonus is {bonusTax}");
            return bonus;
        }

        public double CalculateWage()
        {
            WageCalculations wageCalculations = new WageCalculations();
            double calculatedValue = wageCalculations.ComplexWageCalculation(
                wage, taxRate, 3, 42);
            return calculatedValue;
        }

        public double ReceiveWage(bool resetHours = true)
        {
            double wageBeforeTax = 0.0;

            if (employeeType == EmployeeType.Manager)
            {
                Console.WriteLine($"An extra was added to the wage since {firstName} " +
                    $"is a manager.");
                wageBeforeTax = numberOfHoursWorked * hourlyRate.Value * 1.25;
            }
            else
            {
                wageBeforeTax = numberOfHoursWorked * hourlyRate.Value;
            }

            double taxAmount = wageBeforeTax * taxRate;
            wage = wageBeforeTax - taxAmount;

            Console.WriteLine($"{firstName} {lastName} has received a wage of " +
                $"{wage} for {numberOfHoursWorked} hour(s) of work.");

            if (resetHours)
            {
                numberOfHoursWorked = 0;
            }

            return wage;
        }

        public static void DisplayTaxRate()
        {
            Console.WriteLine($"The current tax rate is {taxRate}");
        }

        public string ConvertToJson()
        {
            string json = JsonConvert.SerializeObject(this);
            return json;
        }

        public void DisplayEmployeeDetails()
        {
            Console.WriteLine($"\nFirst name: \t{firstName}\nLast name: \t" +
                $"{lastName}\nEmail: \t\t{email}\nBirthday: \t" +
                $"{birthDay.ToShortDateString()}\nTax rate: \t{taxRate}\n");
        }
    }
}