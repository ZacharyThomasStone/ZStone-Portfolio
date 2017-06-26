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
     public class BasicAccountTests
    {
        [TestCase("33333", "Basic Account", 100, 1, 250, false) ]
        [TestCase("33333", "Basic Account", 100, 2, -100, false)]
        [TestCase("33333", "Basic Account", 100, 2, 250, true)]
        [Test]
        public void BasicAccountDepositRuleTest(string accountNumber, string name, decimal balance, int accountType, 
            decimal amount, bool expectedResult)
        {
            IDeposit testDeposit = new NoLimitDepositRule();
            Account testAccount = new Account();

            testAccount.AccountNumber = accountNumber;
            testAccount.Name = name;
            testAccount.Balance = balance;
            testAccount.Type = (AccountType)accountType;

            AccountDepositResponse testDepositResponse = testDeposit.Deposit(testAccount, amount);
            Assert.AreEqual(expectedResult, testDepositResponse.Success);
        }





        [TestCase("33333", "Basic Account", 1500, 2, -1000, 1500, false)]
        [TestCase("33333", "Basic Account", 100, 1, -100, 100, false)]
        [TestCase("33333", "Basic Account", 100, 2, 100, 100, false)]
        [TestCase("33333", "Basic Account", 150, 2, -50, 100, true)] 
        [TestCase("33333", "Basic Account", 100, 2, -150, -60, true)] //instructions say this should succeed, yet there is a $100 limit. 
        [Test]
        public void BasicAccountWithdrawRuleTest(string accountNumber, string name, decimal balance, int accountType, 
            decimal amount, decimal newBalance, bool expectedResult)
        {
            IWithdraw testWithdraw = new BasicAccountWithdrawRule();
            Account testAccount = new Account();

            testAccount.AccountNumber = accountNumber;
            testAccount.Name = name;
            testAccount.Balance = balance;
            testAccount.Type = (AccountType)accountType;

            AccountWithdrawResponse testWithdrawResponse = testWithdraw.Withdraw(testAccount, amount);
            Assert.AreEqual(expectedResult, testWithdrawResponse.Success);
            if(testWithdrawResponse.Success)
            {
                newBalance = testAccount.Balance;
            }
        }
        
    }
}
