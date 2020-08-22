using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DebitCreditAPI.Application.DTO.DTO;
using DebitCreditAPI.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DebitCreditAPI.Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly IApplicationServiceAccount _applicationServiceAccount;
        private readonly IApplicationServiceTransaction _applicationServiceTransaction;

        public TransactionsController(IApplicationServiceAccount ApplicationServiceAccount,
                                      IApplicationServiceTransaction ApplicationServiceTransaction)
        {
            _applicationServiceAccount = ApplicationServiceAccount;
            _applicationServiceTransaction = ApplicationServiceTransaction;
        }

        [HttpPost]
        public ActionResult CreateTransaction([FromBody] TransactionDTO transactionDTO)
        {
            try
            {
                if (transactionDTO == null)
                    return NotFound();

                AccountDTO OriginAccount = _applicationServiceAccount.GetAccountByAccountNumber(transactionDTO.OriginAccountNumber);
                AccountDTO DestinyAccount = _applicationServiceAccount.GetAccountByAccountNumber(transactionDTO.DestinyAccountNumber);

                if (OriginAccount == null || DestinyAccount == null)
                    return NotFound();

                _applicationServiceTransaction.CreateTransaction(OriginAccount,
                                                                 DestinyAccount,
                                                                 new EntryDTO { DestinyAccountId = (int)DestinyAccount.Id, 
                                                                                OriginAccountId = (int)OriginAccount.Id, 
                                                                                Value = transactionDTO.Value });
                return Ok("Transaction created successfully!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
