using BankingSystem;
using NUnit.Framework;
using System;

namespace BankSystemTesting
{
    [TestFixture]
    public class Tests
    {       
        [Test]
        public void DepositShouldIncreaseBalance()
        {
            //Arrange
            BankAccount bankAccount = new BankAccount(123);
            decimal amountDeposit = 100;

            //Act
            bankAccount.Deposit(amountDeposit);

            //Assert
            Assert.AreEqual(amountDeposit, bankAccount.Balance);
        }
        [Test]
        public void AccountInicializeWithPositiveValue()
        {
            //Arrange

            //Act
            BankAccount bankAccount = new BankAccount(123,2000m);

            //Assert
            Assert.AreEqual(2000m, bankAccount.Balance);
        }
        [Test]
        public void NegativeAmountShouldThrowInvalidOperationExeptionsWithMessage()
        {
            //Arrange
            BankAccount bankAccount = new BankAccount(123);
            decimal amountDeposit = -100;

            //Act

            //Assert
            var ex = Assert.Throws<InvalidOperationException>(() => bankAccount.Deposit(amountDeposit));
            Assert.AreEqual(ex.Message, "Negative amount");
        }
    }
}