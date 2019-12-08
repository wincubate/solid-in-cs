using System;

namespace Wincubate.UnitTestExamples
{
    public class Bank
    {
        public void Transfer( BankAccount from, decimal amount, BankAccount to )
        {
            from.Withdraw(amount);
            to.Deposit(amount);
        }
    }
}
