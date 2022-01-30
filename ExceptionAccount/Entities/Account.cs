using ExceptionAccount.Entities.Exceptions;
using System;

namespace ExceptionAccount.Entities
{
    class Account
    {
        public int Number { get; set; }
        public string Holder { get; set; }
        public double Balance { get; set; }
        public double WithdrawLimit { get; set; }

        public Account()
        {
        }

        public Account(int number, string holder, double balance, double withdrawLimit)
        {
            Number = number;
            Holder = holder;
            Deposit(balance);
            WithdrawLimit = withdrawLimit;
        }

        public void Deposit(double amount)
        {
            if(amount < 0)
            {
                throw new DomainExceptions("Valor não pode ser menor que zero.");
            }
            Balance += amount;
        }

        public void Withdraw(double amount)
        {
            if(amount > WithdrawLimit)
            {
                throw new DomainExceptions("Withdraw error: The amount exceeds withdraw limit");
            }
            if (Balance < amount)
            {
                throw new DomainExceptions("Withdraw error: Not enough balance");
            }

            Balance -= amount;
        }
    }
}
