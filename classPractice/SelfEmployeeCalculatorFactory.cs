public class SelfEmployeeCalculatorFactory : ITaxCalculatorFactory
{
   public ITaxCalculator CreateTaxCalculator(){
    return new SelfEmployeeTaxCalculator();
   }
}
