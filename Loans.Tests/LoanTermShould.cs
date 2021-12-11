using System.Collections.Generic;
using Loans.Domain.Applications;
using NUnit.Framework;

namespace Loans.Tests
{
    [TestFixture]
    public class LoanTermShould
    {
        [Test]
        public void ReturnTermInMonths()
        {
            var sut = new LoanTerm(1);
            Assert.That(sut.ToMonths(),Is.EqualTo(12));
        }
        [Test]
        public void StoreYears()
        {
            var sut = new LoanTerm(1);
            Assert.That(sut.Years,Is.EqualTo(1));
        }

        [Test]
        public void RespectValueEquality()
        {
            var a = new LoanTerm(1);
            var b = new LoanTerm(1);

            Assert.That(a,Is.EqualTo(b));

        }

        [Test]
        public void RespectValueInequality()
        {
            var a = new LoanTerm(1);
            var b = new LoanTerm(2);

            Assert.That(a,Is.Not.EqualTo(b));

        }

        [Test]
        public void ReferenceEqualityExample()
        {
            var a = new LoanTerm(1);
            var b = a;
            var c = new LoanTerm(1);

            Assert.That(a,Is.SameAs(b));
            Assert.That(a,Is.Not.SameAs(c));

            var x = new List<string> { "a", "b" };
            var y = x;
            var z = new List<string> { "a", "b" };

            Assert.That(y,Is.SameAs(x));
            Assert.That(z,Is.Not.SameAs(x));
        }

        [Test]
        public void Double()
        {
            var a = 1.0 / 3.0;
            Assert.That(a,Is.EqualTo(0.33).Within(0.004));
        }

        [Test]
        public void ReturnCorrectNumberOfComparsions()
        {
            var products = new List<LoanProduct>
            {
                new LoanProduct(1,"a",1),
                new LoanProduct(2,"b",2),
                new LoanProduct(3,"c",3)
            };

            var sut = new ProductComparer(new LoanAmount("USD", 200_000m), products);

            List<MonthlyRepaymentComparison> comparison = sut.CompareMonthlyRepayments(new LoanTerm(30));

            Assert.That(comparison, Has.Exactly(3).Items);
        }
    
        [Test]
        public void ReturnComparsionsForFirstProduct()
        {
            var products = new List<LoanProduct>
            {
                new LoanProduct(1,"a",1),
                new LoanProduct(2,"b",2),
                new LoanProduct(3,"c",3)
            };

            var sut = new ProductComparer(new LoanAmount("USD", 200_000m), products);

            List<MonthlyRepaymentComparison> comparison = sut.CompareMonthlyRepayments(new LoanTerm(30));

            var expectedProduct = new MonthlyRepaymentComparison("a", 1, 643.28m);

           // Assert.That(comparison, Does.Contain(expectedProduct));

           Assert.That(comparison, Has.Exactly(1).Property("ProductName").EqualTo("a"));
        }
    }

}
