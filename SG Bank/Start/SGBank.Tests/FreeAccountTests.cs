using NUnit.Framework;
using SGBank.BLL;
using SGBank.BLL.DepositRules;
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
    public class FreeAccountTests
    {
        [Test]
        public void CanLoadFreeAccountTestData()
        {
            AccountManager manager = AccountManagerFactory.Create();

            AccountLookupResponse response = manager.LookupAccount("12345");

            Assert.IsNotNull(response.Account);
            Assert.IsTrue(response.Success);
            Assert.AreEqual("12345", response.Account.AccountNumber);
        }
        [TestCase("12345", "Free Account", 100, 1, 250, false)]
        [TestCase("12345", "Free Account", 100, 1, -100, false)]
        [TestCase("12345", "Free Account", 100, 2, 50, false)]
        [TestCase("12345", "Free Account", 100, 1, 50, true)]

        public void FreeAccountDepositRuleTest(string accountNumber, string name, decimal balance, int accountType,
            decimal amount, bool expectResult)
        {
            IDeposit testDeposit = new FreeAccountDepositRule();
            Account testAccount = new Account();
            testAccount.AccountNumber = accountNumber;
            testAccount.Name = name;
            testAccount.Balance = balance;
            testAccount.Type = (AccountType)accountType;

            AccountDepositResponse testDepositResponse =  testDeposit.Deposit(testAccount, amount);


            Assert.AreEqual(expectResult, testDepositResponse.Success);
            
        }
        //positive withdraw amount (fail)
        [TestCase("12345", "Free Account", 100, 1, 100, false)]
        //negative withdraw over limit (fail)
        [TestCase("12345", "Free Account", 100, 1, -150, false)]
        //wrong account type (fail)
        [TestCase("12345", "Free Account", 100, 2, -50, false)]
        //Overdraft Fail 
        [TestCase("12345", "Free Account", 50, 2, -70, false)]
        //Successful Withdraw (success) 
        [TestCase("12345", "Free Account", 100, 1, -30, true)]
        public void FreeAccountWithdrawRuleTest(string accountNumber, string name, decimal balance, int accountType, 
            decimal amount, bool expectedResult)
        {
            IWithdraw testWithdraw = new FreeAccountWithdrawRule();
            Account testAccount = new Account();
            testAccount.AccountNumber = accountNumber;
            testAccount.Name = name;
            testAccount.Balance = balance;
            testAccount.Type = (AccountType)accountType;

            AccountWithdrawResponse testWithdrawResponse = testWithdraw.Withdraw(testAccount, amount);
            Assert.AreEqual(expectedResult, testWithdrawResponse.Success);
        }
    }
}
