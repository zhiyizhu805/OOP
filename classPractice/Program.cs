//person class containing infos:Name/annualIncom/Taxpaid

try
{

    TaxFilingSystem taxFilingSystem = new TaxFilingSystem();
    EmployeeTaxCalculator employeeTaxCalculator= new EmployeeTaxCalculator();
    SelfEmployeeTaxCalculator selfEmployeeTaxCalculator= new SelfEmployeeTaxCalculator();

    //create users
    Employee user1 = new Employee("James", 50000);
    Employee user2 = new Employee("Christine", 60000);
    SelfEmployee user3 = new SelfEmployee("Paul", 80000, 30000);
    SelfEmployee user4 = new SelfEmployee("DiDi", 10000,5000);


    taxFilingSystem.FileForPerson(user1, employeeTaxCalculator);
    taxFilingSystem.FileForPerson(user2, employeeTaxCalculator);
    taxFilingSystem.FileForPerson(user3, selfEmployeeTaxCalculator);
    taxFilingSystem.FileForPerson(user4, selfEmployeeTaxCalculator);

    Console.WriteLine("Total tax collect is "+ taxFilingSystem.GetTotalTaxCollected() + ".");
    
    taxFilingSystem.DisplayTaxRecords();
}
catch (Exception e)
{
    Console.WriteLine(e);

}



