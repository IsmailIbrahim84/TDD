using System;
using System.Security.Cryptography.X509Certificates;
using Loans.Domain.Applications;
using Moq;
using NUnit.Framework;

namespace Loans.Tests
{
    public class LoanApplicationProcessorShould
    {
        [Test]
        public void DeclineLowSalary()
        {
            LoanProduct product = new LoanProduct(99, "Loan", 5.25m);
            LoanAmount amount = new LoanAmount("USD", 200_000);
            var application = new LoanApplication(42,
                                                  product,
                                                  amount,
                                                  "Sarah",
                                                  25,
                                                  "133 Pluralsight Drive, Draper, Utah",
                                                  64_999);
            var mocIdentityVerifier = new Mock<IIdentityVerifier>();
            var mocCreditScore = new Mock<ICreditScorer>();

            var sut = new LoanApplicationProcessor(mocIdentityVerifier.Object, mocCreditScore.Object);

            sut.Process(application);

            Assert.That(application.GetIsAccepted(), Is.False);
        }

        [Test]
        public void Accept()
        {
            LoanProduct product = new LoanProduct(99, "Loan", 5.25m);
            LoanAmount amount = new LoanAmount("USD", 200_000);

            
            var application = new LoanApplication(42,
                product,
                amount,
                "Sarah",
                25,
                "133 Pluralsight Drive, Draper, Utah",
                65_000);

            var mocIdentityVerifier = new Mock<IIdentityVerifier>();

            //mocIdentityVerifier.Setup(x => x.Validate("Sarah", 25,  "133 Pluralsight Drive, Draper, Utah")).Returns(true);

            var isValidOutValue = true;

            mocIdentityVerifier.Setup(x =>
                x.Validate("Sarah", 25, "133 Pluralsight Drive, Draper, Utah", out isValidOutValue));

            var mocCreditScore = new Mock<ICreditScorer>();
            
            var sut = new LoanApplicationProcessor(mocIdentityVerifier.Object, mocCreditScore.Object);

            sut.Process(application);

            Assert.That(application.GetIsAccepted(), Is.True);

        }

    }

    }
