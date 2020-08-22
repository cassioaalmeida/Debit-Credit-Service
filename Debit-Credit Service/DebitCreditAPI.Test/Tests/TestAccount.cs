using DebitCreditAPI.Application.DTO.DTO;
using DebitCreditAPI.Test.Config;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Xunit;
using System.Linq;

namespace DebitCreditAPI.Test.Tests
{
    public class TestAccount
    {
        private readonly TestAccountConfig _testAccount;
        public TestAccount()
        {
            ContextConfig contextConfig = new ContextConfig();
            _testAccount = new TestAccountConfig(Util.Util.RandomString(10), contextConfig);
        }
        [Fact]
        public void CreateAccount()
        {
            AccountDTO account = new AccountDTO
            {
                AccountNumber = Util.Util.RandomNumber(100000, 999999),
                Balance = 0
            };

            var actionResult = _testAccount.accountsController.CreateAccount(account);

            actionResult.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.OK);

            var accounts = _testAccount.accountsController.GetAccounts();
            var result = ((OkObjectResult)accounts.Result).Value as List<AccountDTO>;

            result.Where(a => a.AccountNumber == account.AccountNumber).Should().NotBeNull();
        }
        [Fact]
        public void CreateNullAccount()
        {
            AccountDTO account = null;

            var actionResult = _testAccount.accountsController.CreateAccount(account);

            actionResult.Should().BeOfType<NotFoundResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.NotFound);
        }
        [Fact]
        public void CreateDuplicateAccount()
        {
            AccountDTO account = new AccountDTO
            {
                AccountNumber = Util.Util.RandomNumber(100000, 999999),
                Balance = 0
            };
            _testAccount.accountsController.CreateAccount(account);
            Action act = () => _testAccount.accountsController.CreateAccount(account);

            var exception = Assert.Throws<Exception>(act);

            exception.Message.Should().Be("Account Number already exists!");
        }
    }
}
