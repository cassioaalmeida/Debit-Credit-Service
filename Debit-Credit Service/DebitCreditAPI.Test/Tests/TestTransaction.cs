using DebitCreditAPI.Application.DTO.DTO;
using DebitCreditAPI.Test.Config;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Xunit;

namespace DebitCreditAPI.Test.Tests
{
    public class TestTransaction
    {
        private readonly TestAccountConfig _testAccount;
        private readonly TestTransactionConfig _testTransaction;
        ContextConfig contextConfig = new ContextConfig();
        public TestTransaction()
        {
            string dbname = Util.Util.RandomString(10);
            _testAccount = new TestAccountConfig(dbname, contextConfig);
            _testTransaction = new TestTransactionConfig(dbname, contextConfig);

            Util.Util.LoadAccounts(_testAccount);
        }

        [Theory]
        [InlineData(100, 200, 10, 90, 110)]
        [InlineData(200, 100, 50, 50, 150)]
        [InlineData(100, 200, 220, -120, 320)]
        public void CreateTransaction(int originAccount, int destinyAccount, decimal value, decimal originBalance, decimal destinyBalance)
        {
            var actionResult = _testTransaction.transactionsController.CreateTransaction(
                new TransactionDTO { OriginAccountNumber = originAccount, DestinyAccountNumber = destinyAccount, Value = value });

            actionResult.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.OK);

            var result = _testAccount.accountsController.GetAccounts();
            var accounts = ((OkObjectResult)result.Result).Value as List<AccountDTO>;

            accounts.Where(a => a.AccountNumber == originAccount).FirstOrDefault().Balance.Should().Be(originBalance);
            accounts.Where(a => a.AccountNumber == destinyAccount).FirstOrDefault().Balance.Should().Be(destinyBalance);
        }
        [Fact]
        public void CreateTransactionWithNegativeValue()
        {
            Action act = () => _testTransaction.transactionsController.CreateTransaction(
                new TransactionDTO { OriginAccountNumber = 100, DestinyAccountNumber = 200, Value = -10 });

            var exception = Assert.Throws<Exception>(act);

            exception.Message.Should().Be("Invalid Value");
        }
        [Theory]
        [InlineData(999999, 100)]
        [InlineData(100, 9999999)]
        public void CreateTransactionWithInvalidAccounts(int originAccount, int destinyAccount)
        {
            var actionResult = _testTransaction.transactionsController.CreateTransaction(
                new TransactionDTO { OriginAccountNumber = originAccount, DestinyAccountNumber = destinyAccount, Value = -10 });


            actionResult.Should().BeOfType<NotFoundResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.NotFound);
        }
        [Fact]
        public void CreateTransactionWithNullParameter()
        {
            var actionResult = _testTransaction.transactionsController.CreateTransaction(null);

            actionResult.Should().BeOfType<NotFoundResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.NotFound);
        }
    }
}
