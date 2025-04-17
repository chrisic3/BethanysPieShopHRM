using System;

namespace BethanysPieShopHRM.HR
{
    // Struct because this is too small to need a full class
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