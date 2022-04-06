using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject
{
    public class BankAccount
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public double Balance { get; set; }

        #region Constructors
        private BankAccount() { }

        public BankAccount(string username, string password, double balance)
        {
            Username = username;
            Password = password;
            Balance = balance;
        }
        #endregion

        public void Debit(double amount)
        {
            if (amount > Balance)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            Balance -= amount;
        }

        public void Credit(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            Balance += amount;
        }
    }
}
