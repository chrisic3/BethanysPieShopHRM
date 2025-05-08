using BethanysPieShopHRM;
using BethanysPieShopHRM.HR;

class Program
{
    public static void Main(String[] args)
    {
        List<Employee> employees = new List<Employee>();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("***********************************");
        Console.WriteLine("* Bethany's Pie Shop Employee App *");
        Console.WriteLine("***********************************");
        Console.ForegroundColor = ConsoleColor.White;

        string userSelection;
        Console.ForegroundColor = ConsoleColor.Blue;

        Utilities.CheckForExistingEmployeeFile();

        do
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Loaded {employees.Count} employee(s)\n\n");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("*******************");
            Console.WriteLine("* Selet an action *");
            Console.WriteLine("*******************");

            Console.WriteLine("1: Register employee");

        }    
    }
}