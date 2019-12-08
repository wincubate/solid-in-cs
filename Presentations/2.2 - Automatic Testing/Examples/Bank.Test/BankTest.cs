using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Wincubate.UnitTestExamples.Test
{
    [TestClass]
    public class BankTest
    {
        [TestInitialize]
        public void TestInitialize()
        {
        }

        [TestCleanup]
        public void TestCleanup()
        {
        }

        [TestMethod]
        public void TestTransfer_EnoughMoney()
        {
            BankAccount from = new BankAccount();
            from.Deposit(176);

            BankAccount to = new BankAccount();
            to.Deposit(87);

            Bank bank = new Bank();
            bank.Transfer(from, 42, to);

            decimal fromExpectedBalance = 134;
            Assert.AreEqual(fromExpectedBalance, from.Balance);

            decimal toExpectedBalance = 129;
            Assert.AreEqual(toExpectedBalance, to.Balance);
        }
    }
}
