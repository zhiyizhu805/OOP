public class EmployeeCalculatorFactory : ITaxCalculatorFactory
{
    public ITaxCalculator CreateTaxCalculator(){
        return new EmployeeTaxCalculator();
    }
}
