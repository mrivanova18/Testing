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
            int id = 123;
            decimal amount = 500;
            BankAccount bankAccount = new BankAccount(id,amount);
            decimal amountDeposit = 100;

            //Act
            bankAccount.Deposit(amountDeposit);

            //Assert
            Assert.AreEqual(amountDeposit+amount, bankAccount.Balance);
        }
        [TestCase(123,500)]
        [TestCase(123, 500.7896)]
        [TestCase(123, 0)]
        public void ConstructorShouldSetBalanceCorrectly(int id, decimal amount)
        {
            //Arrange&Act           
            BankAccount bankAccount = new BankAccount(id, amount);

            //Assert
            Assert.AreEqual(amount, bankAccount.Balance);
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
        [Test]
        public void ConstructorShouldSetZeroBalance()
        {
            //Arrange
            int id = 123;

            //Act
            BankAccount bankAccount = new BankAccount(id);

            //Assert
            Assert.AreEqual(0, bankAccount.Balance);
        }
        [Test]
        public void IsIdSetRight()
        {
            //Arrange
            int id = 123;

            //Act
            BankAccount bankAccount = new BankAccount(id);

            //Assert
            Assert.AreEqual(id, bankAccount.Id);
        }
        [Test]
        public void NegativeAmountShouldThrowArgumentExeptionWhenAmountIsNegative()
        {
            //Arrange
            int id = 123;
            decimal amount = -100.123m;

             //Act
            //Assert
            var ex = Assert.Throws<ArgumentException>(() => new BankAccount(id, amount));
        }
        [Test]
        public void BalanceShouldThrowArgumentExeptionsWithMessage()
        {
            //Arrange
            int id = 123;
            decimal amount = -100.123m;
            string message = "Balance must be positive or zero.";

            //Act
            var ex = Assert.Throws<ArgumentException>(() => new BankAccount(id, amount));

            //Assert
            Assert.AreEqual(message, ex.Message);
        }
        
        [TestCase(123, 500)]
        [TestCase(123, 1000)]        
        public void BonusShouldIncreaseBalanceWhenBalanceIsLessOrEqualThan1000(int id, decimal balance)
        {
            BankAccount bankAccount = new BankAccount(id, balance);
            bankAccount.Bonus();
            Assert.AreEqual(balance, bankAccount.Balance);
        }

        [Test]
        public void ConstructorShouldWorkCorrectly()
        {
            BankAccount bankAccount = new BankAccount(234,450);
            Assert.AreEqual(234, bankAccount.Id);
            Assert.AreEqual(450, bankAccount.Balance);
        }
        [Test]
        public void IncreaseShouldIncreaseBalance()
        {
            BankAccount account = new BankAccount(123, 100);
            account.Increase(5);
            Assert.AreEqual(105, account.Balance);
        }
    }
}
