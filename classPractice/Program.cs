//person class containing infos:Name/annualIncom/Taxpaid

try
{

    TaxFilingSystem taxFilingSystem = new TaxFilingSystem();
    TaxCalculator taxCalculator = new TaxCalculator();

    //create users
    Person user1 = new Person("James", 50000);
    Person user2 = new Person("Christine", 60000);
    Person user3 = new Person("Paul", 80000);
    Person user4 = new Person("DiDi", 10000);


    taxFilingSystem.FileForPerson(user1, taxCalculator);
    taxFilingSystem.FileForPerson(user2, taxCalculator);
    taxFilingSystem.FileForPerson(user3, taxCalculator);
    taxFilingSystem.FileForPerson(user4, taxCalculator);

    Console.WriteLine("Total tax collect is "+ taxFilingSystem.GetTotalTaxCollected() + ".");
    
    taxFilingSystem.DisplayTaxRecords();
}
catch (Exception e)
{
    Console.WriteLine(e);

}



