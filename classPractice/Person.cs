//person class containing infos:Name/annualIncom/Taxpaid




public class Person
{
    public string Name { get; set; }
    public double AnnualIncome { get; set; }
    public double TaxPaid { get; set; }

    public Person(string name, double annualIncome)
    {
         if (annualIncome < 0){
            throw new Exception("Income cannot be negative");
         }
        Name = name;
        AnnualIncome = annualIncome;
        TaxPaid = 0;
    }

    // In the current design, the Person class has a method FileTax that triggers the tax calculation for that person. This is just a way for the Person class to interact with the TaxCalculator class, not to actually perform the calculation itself.
    public void FileTax(TaxCalculator taxCalculator){
    
    TaxPaid = taxCalculator.CalculateTax(this);

    }
}
