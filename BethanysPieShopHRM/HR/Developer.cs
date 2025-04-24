using System;

namespace BethanysPieShopHRM.HR;

class Developer : Employee
{
    private string currentProject;

    public string CurrentProject
    {
        get
        { return currentProject; }
        set
        {
            currentProject = value;
        }
    }

    public Developer(string firstName, string lastName, string email, 
        DateTime birthday, double? hourlyRate) : base(firstName, lastName, 
        email, birthday, hourlyRate)
    {
    }
}
