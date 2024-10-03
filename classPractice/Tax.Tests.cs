using NUnit.Framework;
using System;

namespace classPractice
{
    [TestFixture]
    public class TaxTests
    {
        private EmployeeTaxCalculator employeeTaxCalculator;
        private SelfEmployeeTaxCalculator selfEmployedTaxCalculator;
        private TaxFilingSystem taxFilingSystem;

        [SetUp]
        public void Setup()
        {
            employeeTaxCalculator = new EmployeeTaxCalculator();
            selfEmployedTaxCalculator = new SelfEmployeeTaxCalculator();
            taxFilingSystem = new TaxFilingSystem();
        }

        [Test]
        public void CalculateTax_LowIncome_ShouldReturn10PercentTax()
        {
            // Arrange
            Person alice = new Employee("Alice", 10000);

            // Act
            double tax = employeeTaxCalculator.CalculateTax(alice);

            // Assert
            Assert.AreEqual(1000, tax);  // 10% of 10,000 is 1,000
        }

        [Test]
        public void CalculateTax_MiddleIncome_ShouldApplyProgressiveTax()
        {
            // Arrange
            Person bob = new Employee("Bob", 30000);

            // Act
            double tax = employeeTaxCalculator.CalculateTax(bob);

            // Assert
            // First 15,000 at 10% = 1,500
            // Remaining 15,000 at 20% = 3,000
            // Total tax = 1,500 + 3,000 = 4,500
            Assert.AreEqual(4500, tax);
        }

        [Test]
        public void CalculateTax_HighIncome_ShouldApply30PercentAbove35000()
        {
            // Arrange
            Person charlie = new Employee("Charlie", 75000);

            // Act
            double tax = employeeTaxCalculator.CalculateTax(charlie);

            // Assert
            // First 15,000 at 10% = 1,500
            // Next 20,000 at 20% = 4,000
            // Remaining 40,000 at 30% = 12,000
            // Total tax = 1,500 + 4,000 + 12,000 = 17,500
            Assert.AreEqual(17500, tax);
        }

        [Test]
        public void SelfEmployed_ShouldApplyBusinessExpenses_BeforeTaxCalculation()
        {
            // Arrange
            Person dave = new SelfEmployee("Dave", 60000, 10000); // Dave has $10,000 in business expenses

            // Act
            double tax = selfEmployedTaxCalculator.CalculateTax(dave);

            // Assert
            // Taxable income = 60,000 - 10,000 = 50,000
            // First 15,000 at 10% = 1,500
            // Next 20,000 at 20% = 4,000
            // Remaining 15,000 at 30% = 4,500
            // Total tax = 1,500 + 4,000 + 4,500 = 10,000
            Assert.AreEqual(10000, tax);
        }

        [Test]
        public void TaxFilingSystem_ShouldTrackTotalTaxCollected()
        {
            // Arrange
            Person alice = new Employee("Alice", 10000);
            Person bob = new Employee("Bob", 30000);

            // Act
            taxFilingSystem.FileForPerson(alice);
            taxFilingSystem.FileForPerson(bob);

            // Assert
            // Alice's tax: 10% of 10,000 = 1,000
            // Bob's tax: 1,500 + 3,000 = 4,500
            // Total tax = 1,000 + 4,500 = 5,500
            Assert.AreEqual(5500, taxFilingSystem.GetTotalTaxCollected());
        }

        [Test]
        public void TaxFilingSystem_ShouldTrackEachPersonTaxPaid()
        {
            // Arrange
            Person alice = new Employee("Alice", 12000);
            Person bob = new Employee("Bob", 45000);

            // Act
            taxFilingSystem.FileForPerson(alice);
            taxFilingSystem.FileForPerson(bob);

            // Assert
            Assert.AreEqual(1200, alice.TaxPaid);  // Alice should have paid 10% of 12,000 = 1,200
            Assert.AreEqual(8500, bob.TaxPaid);    // Bob should have paid progressive tax of 8,500
        }

        [Test]
        public void TaxFilingSystem_ShouldHandleSelfEmployedPersonWithBusinessExpenses()
        {
            // Arrange
            Person dave = new SelfEmployee("Dave", 60000, 10000);  // $10,000 business expenses

            // Act
            taxFilingSystem.FileForPerson(dave);

            // Assert
            Assert.AreEqual(10000, dave.TaxPaid);  // Dave should pay $10,000 in tax after expenses
        }
    }
}
