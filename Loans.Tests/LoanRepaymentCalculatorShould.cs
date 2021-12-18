using System;
using System.Collections.Generic;
using System.Text;
using Loans.Domain.Applications;
using NUnit.Framework;

namespace Loans.Tests
{
    public class LoanRepaymentCalculatorShould
    {
        //private LoanRepaymentCalculator _sut;
        //private decimal _monthlyPayment;

        [SetUp]
        public void Setup()
        {
             //_sut = new LoanRepaymentCalculator();
           //  _monthlyPayment = _sut.CalculateMonthlyRepayment(new LoanAmount("USD", 200_000), 6.5m, new LoanTerm(30));
        }

        [Test]
        public void CalculateCorrectMonthlyRepayment()
        {
            var _sut = new LoanRepaymentCalculator();
            var _monthlyPayment = _sut.CalculateMonthlyRepayment(new LoanAmount("USD", 200_000), 6.5m, new LoanTerm(30));
        
            Assert.That(_monthlyPayment,Is.EqualTo(1264.14));
        }

        [Test]
        [TestCase(200_000, 6.5, 30, 1264.14)]
        public void CalculateCorrectMonthlyRepayment_Parameters(decimal principal, decimal interestRate, int termInYears, decimal expectedMonthlyPayment)
        {
            var _sut = new LoanRepaymentCalculator();
            var _monthlyPayment = _sut.CalculateMonthlyRepayment(new LoanAmount("USD", principal), interestRate, new LoanTerm(termInYears));
        
            Assert.That(_monthlyPayment,Is.EqualTo(expectedMonthlyPayment));
        }

        [Test]
        [TestCase(200_000, 6.5, 30,ExpectedResult= 1264.14)]
        public decimal CalculateCorrectMonthlyRepayment_Expected(decimal principal, decimal interestRate,
            int termInYears)
        {
            var _sut = new LoanRepaymentCalculator();
            return _sut.CalculateMonthlyRepayment(new LoanAmount("USD", principal), interestRate,
                new LoanTerm(termInYears));

        }
    }
}
