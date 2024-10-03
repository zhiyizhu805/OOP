using NUnit.Framework;
using System;

namespace classPractice
{
    [TestFixture]  // Changed from [TestClass]
    public class TaxTests
    {
        [SetUp]
        public void Setup()
        {
            // This method is executed before each test if needed for initialization.
        }

        [Test]  // Changed from [TestMethod]
        public void CalculateTax_LowIncome_ShouldReturn10PercentTax()
        {
            // Arrange
            Person person = new Person("Alice", 10000);
            TaxCalculator taxCalculator = new TaxCalculator();

            // Act
            double tax = taxCalculator.CalculateTax(person);

            // Assert
            Assert.AreEqual(1000, tax);  // 10% of 10000 is 1000
        }

        [Test]  // Changed from [TestMethod]
        public void CalculateTax_MiddleIncome_ShouldApplyProgressiveTax()
        {
            // Arrange
            Person person = new Person("Bob", 30000);
            TaxCalculator taxCalculator = new TaxCalculator();

            // Act
            double tax = taxCalculator.CalculateTax(person);

            // Assert
            // First 15,000 at 10% = 1,500
            // Remaining 15,000 at 20% = 3,000
            // Total tax should be 1,500 + 3,000 = 4,500
            Assert.AreEqual(4500, tax);
        }

        [Test]  // Changed from [TestMethod]
        public void CalculateTax_HighIncome_ShouldApply30PercentAbove50000()
        {
            // Arrange
            Person person = new Person("Charlie", 75000);
            TaxCalculator taxCalculator = new TaxCalculator();

            // Act
            double tax = taxCalculator.CalculateTax(person);

            // Assert
            // First 15,000 at 10% = 1,500
            // Next 35,000 at 20% = 7,000
            // Remaining 25,000 at 30% = 7,500
            // Total tax should be 1,500 + 7,000 + 7,500 = 16,000
            Assert.AreEqual(16000, tax);
        }

        // [Test]  // Changed from [TestMethod]
        // public void Person_WithNegativeIncome_ShouldThrowException()
        // {
        //     // Arrange, Act & Assert
        //     Person person = new Person("InvalidPerson", -1000);

        //     // Assert is handled by the ExpectedException attribute
        // }

        [Test]  // Changed from [TestMethod]
        public void TaxFilingSystem_ShouldTrackTotalTaxCollected()
        {
            // Arrange
            Person alice = new Person("Alice", 10000);
            Person bob = new Person("Bob", 30000);
            TaxCalculator taxCalculator = new TaxCalculator();
            TaxFilingSystem taxFilingSystem = new TaxFilingSystem();

            // Act
            taxFilingSystem.FileForPerson(alice, taxCalculator);
            taxFilingSystem.FileForPerson(bob, taxCalculator);

            // Assert
            // Alice's tax: 10% of 10,000 = 1,000
            // Bob's tax: 1,500 + 3,000 = 4,500
            // Total tax = 1,000 + 4,500 = 5,500
            Assert.AreEqual(5500, taxFilingSystem.GetTotalTaxCollected());
        }

        [Test]  // Changed from [TestMethod]
        public void TaxFilingSystem_ShouldTrackEachPersonTaxPaid()
        {
            // Arrange
            Person alice = new Person("Alice", 12000);
            Person bob = new Person("Bob", 45000);
            TaxCalculator taxCalculator = new TaxCalculator();
            TaxFilingSystem taxFilingSystem = new TaxFilingSystem();

            // Act
            taxFilingSystem.FileForPerson(alice, taxCalculator);
            taxFilingSystem.FileForPerson(bob, taxCalculator);

            // Assert
            Assert.AreEqual(1200, alice.TaxPaid);  // Alice should have paid 1,200 in tax (10% of 12,000)
            Assert.AreEqual(8500, bob.TaxPaid);    // Bob should have paid 7,300 in tax
        }
    }
}
