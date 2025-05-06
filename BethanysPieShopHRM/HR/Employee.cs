using System;
using BethanysPieShopHRM.Logic;
using Newtonsoft.Json;

namespace BethanysPieShopHRM.HR
{
    public class Employee : IEmployee
    {
        // Need to change these all to private and add methods
        private string firstName;
        private string lastName;
        private string email;
        private int numberOfHoursWorked;
        private double wage;
        private double? hourlyRate; // ? means this type is nullable
        private DateTime birthDay;
        private const int minimalHoursWorkedUnit = 1;
        private Address address;

        public static double taxRate = 0.15;

        // CONSTRUCTORS
        #region Constructors

        public Employee(string firstName, string lastName, string email, 
            DateTime birthDay, double? hourlyRate)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthDay = birthDay;
            // ?? is null coalesce, 10 is default if null
            HourlyRate = hourlyRate ?? 10;
        }

        public Employee(string firstName, string lastName, string email, 
            DateTime birthDay, double? hourlyRate, string street, string
            houseNumber, string zipCode, string city)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthDay = birthDay;
            // ?? is null coalesce, 10 is default if null
            HourlyRate = hourlyRate ?? 10;
            Address = new Address(street, houseNumber, zipCode, city);
        }

        // The ": this()" calls the other constructor and passes it
        // the required parameters.
        public Employee(string firstName, string lastName, string email, 
            DateTime birthDay) : this(firstName, lastName, email, birthDay, 0)
        {
        }

        #endregion

        // PROPERTIES
        #region Properties

        public string FirstName
        {
            get
            { return firstName; }
            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            { return lastName; }
            set
            {
                lastName = value;
            }
        }

        public string Email
        {
            get
            { return email; }
            set
            {
                email = value;
            }
        }

        public int NumberOfHoursWorked
        {
            get
            { return numberOfHoursWorked; }
            protected set // Only the Employee class can set this value
            {
                numberOfHoursWorked = value;
            }
        }

        public double Wage
        {
            get
            { return wage; }
            private set
            {
                wage = value;
            }
        }

        public double? HourlyRate
        {
            get
            { return hourlyRate; }
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
            { return birthDay; }
            set
            {
                birthDay = value;
            }
        }

        public Address Address
        {
            get { return address; }
            set {
                address = value;
            }
        }

        #endregion

        public void PerformWork()
        {
            // Call the overloaded method instead of duplicating
            PerformWork(minimalHoursWorkedUnit);

            //numberOfHoursWorked++;
            //Console.WriteLine($"{firstName} {lastName} has worked for " +
            //  $"{numberOfHoursWorked} hour(s).");
        }

        public void PerformWork(int numberOfHoursWorked)
        {
            NumberOfHoursWorked += numberOfHoursWorked;
            Console.WriteLine($"{FirstName} {LastName} has worked for " +
                $"{numberOfHoursWorked} hour(s).");
        }

        public int CalculateBonus(int bonus)
        {
            if (NumberOfHoursWorked > 10)
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

        // out does not have to be initialized in the caller progam before
        // calling, but it does have to be initialized in the method before
        // returning
        public int CalculateBonusAndBonusTax(int bonus, out int bonusTax)
        {
            bonusTax = 0;
            
            if (NumberOfHoursWorked > 10)
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

        public virtual void GiveBonus()
        {
            Console.WriteLine($"{FirstName} {LastName} received a generic bonus " +
                $"of $100!");
        }

        public double CalculateWage()
        {
            WageCalculations wageCalculations = new WageCalculations();
            double calculatedValue = wageCalculations.ComplexWageCalculation(
                Wage, taxRate, 3, 42);
            return calculatedValue;
        }

        public double ReceiveWage(bool resetHours = true)
        {
            double wageBeforeTax = NumberOfHoursWorked * HourlyRate.Value;
            double taxAmount = wageBeforeTax * taxRate;

            Wage = wageBeforeTax - taxAmount;

            Console.WriteLine($"{FirstName} {LastName} has received a wage " +
                $"of {Wage} for {NumberOfHoursWorked} hour(s) of work.");

            if (resetHours)
            {
                NumberOfHoursWorked = 0;
            }

            return Wage;
        }

        public static void DisplayTaxRate()
        {
            Console.WriteLine($"The current tax rate is {taxRate}");
        }

        public void GiveCompliment()
        {
            Console.WriteLine($"You've done a great job, {FirstName}.");
        }

        public string ConvertToJson()
        {
            string json = JsonConvert.SerializeObject(this);
            return json;
        }

        public void DisplayEmployeeDetails()
        {
            Console.WriteLine($"\nFirst name: \t{FirstName}\nLast name: \t" +
                $"{LastName}\nEmail: \t\t{Email}\nBirthday: \t" +
                $"{BirthDay.ToShortDateString()}\n");
        }
    }
}