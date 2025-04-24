using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.HR
{
    internal class Researcher : Employee
    {
        private int numberOfPieTastesInvented = 0;

        public Researcher(string firstName, string lastName, string email, 
            DateTime dateOfBirth, double? hourlyRate) : base(firstName, 
            lastName, email, dateOfBirth, hourlyRate)
        {
        }

        public int NumberOfPieTastesInvented
        {
            get { return numberOfPieTastesInvented; }
            private set
            {
                numberOfPieTastesInvented = value;
            }
        }

        public void ResearchNewPieTastes(int researchHours)
        {
            NumberOfHoursWorked += researchHours;

            // Random number between 0 and 100 and the condition is true
            // if the number is greater than 50
            if (new Random().Next(100) > 50)
            {
                NumberOfPieTastesInvented++;

                Console.WriteLine($"Researcher {FirstName} {LastName} has " +
                    $"invented a new pie taste! Total number of pies invented: " +
                    $"{NumberOfPieTastesInvented}");
            }
            else
            {
                Console.WriteLine($"Researcher {FirstName} {LastName} is working " +
                    $"still on a new pie taste!");
            }
        }
    }
}
