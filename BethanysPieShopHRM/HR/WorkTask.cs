using System;

namespace BethanysPieShopHRM.HR
{
    internal struct WorkTask
    {
        public string description;
        public int hours;

        public void PerformWorkTask()
        {
            Console.WriteLine($"Task {description} of {hours} hour(s) has " +
                $"been performed.");
        }
    }
}