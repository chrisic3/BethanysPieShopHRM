using BethanysPieShopHRM.HR;

Console.WriteLine("Creating an employee");
Console.WriteLine("--------------------\n");

Employee bethany = new Employee("Bethany", "Smith", "bsmith@pies.shop", 
    new (1979, 01, 16), 25);
Manager george = new Manager("George", "Will", "bwill@pies.shop", 
    new (1993, 05, 24), 20);

#region First run Bethany

bethany.PerformWork();
bethany.PerformWork(5);
bethany.PerformWork();
bethany.ReceiveWage();
bethany.DisplayEmployeeDetails();

#endregion

#region First run George

george.PerformWork(10);
george.PerformWork();
george.PerformWork();
george.ReceiveWage();
george.DisplayEmployeeDetails();

#endregion
