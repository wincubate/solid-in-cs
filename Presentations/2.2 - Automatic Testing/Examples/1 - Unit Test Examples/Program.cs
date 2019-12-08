using System;

namespace Wincubate.UnitTestExamples
{
    class Program
    {
        static void Main( string[] args )
        {
            BankAccount from = new BankAccount();
            from.Deposit(176);
            Console.WriteLine(from.Balance);

            BankAccount to = new BankAccount();
            to.Deposit(87);

            Bank bank = new Bank();
            bank.Transfer(from, 42, to);
        }
    }
}
