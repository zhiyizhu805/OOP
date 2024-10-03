using System.Reflection.Metadata.Ecma335;

public abstract class Person
{
    public string Name { get; set; }
    public double AnnualIncome { get; set; }
    public double TaxPaid { get; set; }

    public Person(string name, double annualIncome)
    {
        if (annualIncome < 0)
        {
            throw new Exception("Income cannot be negative");
        }
        Name = name;
        AnnualIncome = annualIncome;
        TaxPaid = 0;
    }

    // Every future type person should know where (The factory here is just a middle layer (eg. SelfEmployee => SelfEmployeeCalculatorFactory => SelfEmployeeCalculator) to buy their needed tax calculator. because they know who their type and every type's calculator has been created.
    //  Here assume you must get the factory
    public abstract ITaxCalculator GetTaxCalculator();

    
    public void FileTax(){
        ITaxCalculator calculator = GetTaxCalculator();
        TaxPaid = calculator.CalculateTax(this);
        
    }
}


public class Employee : Person
{

    public Employee(string name, double annualIncome)
    : base(name, annualIncome) { }

    public override ITaxCalculator GetTaxCalculator()
    {
        return new EmployeeTaxCalculator();
    }

}

public class SelfEmployee : Person
{
    public double Expense { get; set; }

    public SelfEmployee(string name, double annualIncome, double expense)
    : base(name, annualIncome)
    {
        Expense = expense;
    }

    public override ITaxCalculator GetTaxCalculator()
    {
        return new SelfEmployeeTaxCalculator();
    }

}