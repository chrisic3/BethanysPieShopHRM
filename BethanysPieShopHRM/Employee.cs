using System;

namespace BethanysPieShopHRM;

public class Employee
{
    public string firstName;
    public string lastName;
    public string email;
    
    public int numberOfHoursWorked;
    public double wage;
    public double hourlyRate;
    
    public DateTime birthDay;

    const int MinimalHoursWorkedUnit = 1;

    public void PerformWork()
    {
        PerformWork(MinimalHoursWorkedUnit); // Call the other method instead of duplicating
        //numberOfHoursWorked++;
        //Console.WriteLine($"{firstName} {lastName} has worked for " +
        //  $"{numberOfHoursWorked} hour(s).");
    }

    public void PerformWork(int numberOfHours)
    {
        numberOfHoursWorked += numberOfHoursWorked;
        Console.WriteLine($"{firstName} {lastName} has worked for " +
            $"{numberOfHours} hour(s).");
    }

    public double ReceiveWage(bool resetHours = true)
    {
        wage = numberOfHoursWorked * hourlyRate;
        Console.WriteLine($"{firstName} {lastName} has received a wage of " +
            $"{wage} for {numberOfHoursWorked} hour(s) of work.");

        if (resetHours)
        {
            numberOfHoursWorked = 0;
        }

        return wage;
    }

    public void DisplayEmployeeDetails()
    {
        Console.WriteLine($"\nFirst name: \t{firstName}\nLast name: \t" +
            $"{lastName}\nEmail: \t\t{email}\nBirthday: \t" +
            $"{birthDay.ToShortDateString()}\n");
    }
}
