using System;

namespace BethanysPieShopHRM;

public class Employee
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

    public Employee(string firstName, string lastName, string email, 
        DateTime birthDay, double hourlyRate)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.email = email;
        this.birthDay = birthDay;
        this.hourlyRate = hourlyRate;
    }

    public Employee(string firstName, string lastName, string email, 
        DateTime birthDay) : this(firstName, lastName, email, birthDay, 0)
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
