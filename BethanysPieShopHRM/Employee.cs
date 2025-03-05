using System;
using Newtonsoft.Json;

namespace BethanysPieShopHRM
{

    internal class Employee
    {
        // Need to change these all to private and add methods
        public string firstName;
        public string lastName;
        public string email;
        
        public int numberOfHoursWorked;
        public double wage;
        public double hourlyRate;
        
        public DateTime birthDay;

        const int MinimalHoursWorkedUnit = 1;

        public EmployeeType employeeType;

        public Employee(string firstName, string lastName, string email, 
            DateTime birthDay, double hourlyRate, EmployeeType employeeType)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.birthDay = birthDay;
            this.hourlyRate = hourlyRate;
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

        public double ReceiveWage(bool resetHours = true)
        {
            if (employeeType == EmployeeType.Manager)
            {
                Console.WriteLine($"An extra was added to the wage since {firstName} " +
                    $"is a manager.");
                wage = numberOfHoursWorked * hourlyRate * 1.25;
            }
            else
            {
                wage = numberOfHoursWorked * hourlyRate;
            }

            Console.WriteLine($"{firstName} {lastName} has received a wage of " +
                $"{wage} for {numberOfHoursWorked} hour(s) of work.");

            if (resetHours)
            {
                numberOfHoursWorked = 0;
            }

            return wage;
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
                $"{birthDay.ToShortDateString()}\n");
        }
    }
}