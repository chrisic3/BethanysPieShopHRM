using BethanysPieShopHRM.HR;

Console.WriteLine("Creating an employee");
Console.WriteLine("--------------------\n");

Employee bethany = new Employee("Bethany", "Smith", "bsmith@pies.shop", 
    new (1979, 01, 16), 25, EmployeeType.Manager);
Employee george = new Employee("George", "Will", "bwill@pies.shop", 
    new (1993, 05, 24), 20, EmployeeType.Research);

bethany.DisplayEmployeeDetails();
george.DisplayEmployeeDetails();

bethany.PerformWork();
bethany.PerformWork();
bethany.PerformWork(5);
bethany.PerformWork();

george.PerformWork();
george.PerformWork();
george.PerformWork(5);
george.PerformWork();

double receivedWageBethany = bethany.ReceiveWage(true);
double receivedWageGeorge = george.ReceiveWage(true);
Console.WriteLine($"Wage paid (message from Program): {receivedWageBethany}");
Console.WriteLine($"Wage paid (message from Program): {receivedWageGeorge}");

WorkTask task;
task.description = "Bake pies";
task.hours = 3;
task.PerformWorkTask();