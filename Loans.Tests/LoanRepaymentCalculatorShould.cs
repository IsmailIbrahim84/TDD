using System;
using System.Collections.Generic;
using System.Text;
using Loans.Domain.Applications;
using NUnit.Framework;

namespace Loans.Tests
{
    public class LoanRepaymentCalculatorShould
    {
        private LoanRepaymentCalculator _sut;
        private decimal _monthlyPayment;

        [SetUp]
        public void Setup()
        {
             _sut = new LoanRepaymentCalculator();
             _monthlyPayment = _sut.CalculateMonthlyRepayment(new LoanAmount("USD", 200_000), 6.5m, new LoanTerm(30));
        }

        [Test]
        public void CalculateCorrectMonthlyRepayment()
        {
            Assert.That(_monthlyPayment,Is.EqualTo(1264.14));
        }
    }
}
