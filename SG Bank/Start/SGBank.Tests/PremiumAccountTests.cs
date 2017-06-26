using NUnit.Framework;
using SGBank.BLL.DepositRules;
using SGBank.BLL.WithdrawRules;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Tests
{
    [TestFixture]
    public class PremiumAccountTests
    {
        [TestCase("33333", "Premium Account", 100, 1, 250, false)] //wrong account 
        [TestCase("99999", "Premium Account", 100, 3, -10, false)] //must deposit more than 0 
        [TestCase("99999", "Premium Account", 100, 3, 50, true)]

        [Test]
        public void PremiumAccountDepositRuleTest(string accountNumber, string name, decimal balance, int accountType,
        decimal amount, bool expectResult)
        {
            IDeposit testDeposit = new NoLimitDepositRule();
            Account testAccount = new Account();
            testAccount.AccountNumber = accountNumber;
            testAccount.Name = name;
            testAccount.Balance = balance;
            testAccount.Type = (AccountType)accountType;

            AccountDepositResponse testDepositResponse = testDeposit.Deposit(testAccount, amount);


            Assert.AreEqual(expectResult, testDepositResponse.Success);

        }

        [TestCase("33333", "Premium Account", 100, 1, -25, 75, false)] //wrong account 
        [TestCase("99999", "Premium Account", 100, 3, 10, 110, false)] //must be negative amount.  
        [TestCase("99999", "Premium Account", 100, 3, -50, 50, true)]


        [Test]
        public void PremiumAccountWithdrawRuleTest(string accountNumber, string name, decimal balance, int accountType,
         decimal amount, decimal newBalance, bool expectedResult)
        {
            IWithdraw testWithdraw = new PremiumAccountWithdrawRule();
            Account testAccount = new Account();

            testAccount.AccountNumber = accountNumber;
            testAccount.Name = name;
            testAccount.Balance = balance;
            testAccount.Type = (AccountType)accountType;

            AccountWithdrawResponse testWithdrawResponse = testWithdraw.Withdraw(testAccount, amount);
            Assert.AreEqual(expectedResult, testWithdrawResponse.Success);
            if (testWithdrawResponse.Success)
            {
                newBalance = testAccount.Balance;
            }
        }
    }
}
