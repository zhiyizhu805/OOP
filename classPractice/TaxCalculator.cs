//person class containing infos:Name/annualIncom/Taxpaid

public abstract class TaxCalculator
{
    public abstract double CalculateTax(Person person);
}

public class EmployeeTaxCalculator : TaxCalculator
{
    public override double CalculateTax(Person person)
    {
        if (person is Employee employee)
        {

            double income = employee.AnnualIncome;
            double tax = 0;

            if (income > 0 && income <= 15000)
            {
                tax = income * 0.1;
            }
            else if (income > 15000 && income <= 35000)
            {
                tax = 15000 * 0.10 + (income - 15000) * 0.20;
            }
            else
            {
                tax = 15000 * 0.10 + 20000 * 0.20 + (income - 35000) * 0.30;
            }
            return tax;
        }
        else
        {
            throw new ArgumentException("Invalid type for EmployeeTaxCalculator.");
        }
    }
}

public class SelfEmployeeTaxCalculator : TaxCalculator
{
    public override double CalculateTax(Person person)
    {
        //Down casting to Employee class
        if (person is SelfEmployee selfEmployee)
        {

            double taxableIncome = selfEmployee.AnnualIncome - selfEmployee.Expense;

            double tax = 0;

            if (taxableIncome > 0 && taxableIncome <= 15000)
            {
                tax = taxableIncome * 0.1;
            }
            else if (taxableIncome > 15000 && taxableIncome <= 35000)
            {
                tax = 15000 * 0.10 + (taxableIncome - 15000) * 0.20;
            }
            else
            {
                tax = 15000 * 0.10 + 20000 * 0.20 + (taxableIncome - 35000) * 0.30;
            }
            return tax;
        }
        else
        {
            throw new ArgumentException("Invalid type for SelfEmployeeTaxCalculator.");
        }

    }
}