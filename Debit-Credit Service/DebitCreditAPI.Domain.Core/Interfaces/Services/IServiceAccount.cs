﻿using DebitCreditAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebitCreditAPI.Domain.Core.Interfaces.Services
{
    public interface IServiceAccount : IServiceBase<Account>
    {
        Account GetAccountByAccountNumber(int accountNumber);
        IEnumerable<Account> GetAllWithChilds();
    }
}
