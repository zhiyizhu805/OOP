//person class containing infos:Name/annualIncom/Taxpaid

public class TaxCalculator
{
    public double CalculateTax(Person person){
        double income = person.AnnualIncome;
        double tax = 0;
        // Rate and logic to add
        
        if (income > 0 && income <= 15000){
            tax = income * 0.1;
        } else if(income > 15000 && income <= 35000){
            tax = 15000 * 0.10 + (income - 15000) * 0.20;
        } else {
            tax = 15000 * 0.10 + 20000 * 0.20 + (income - 35000) * 0.30;
        } 
        return tax;
    }
}
