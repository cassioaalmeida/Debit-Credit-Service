using DebitCreditAPI.Application.Service;
using DebitCreditAPI.Domain.Services.Services;
using DebitCreditAPI.Infra.CrossCutting.Adapter.Map;
using DebitCreditAPI.Infra.Data;
using DebitCreditAPI.Infra.Repository.Repositories;
using DebitCreditAPI.Presentation.Controllers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebitCreditAPI.Test.Config
{
    public class TestAccountConfig
    {
        public AccountsController accountsController;

        public TestAccountConfig(string dbname, ContextConfig contextConfig)
        {
            accountsController = new AccountsController(
                new ApplicationServiceAccount(
                    new ServiceAccount(
                        new RepositoryAccount(contextConfig.getContext(dbname))),
                    new MapperAccount()));
        }
    }
}
