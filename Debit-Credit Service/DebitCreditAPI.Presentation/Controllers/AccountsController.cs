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
    public class AccountsController : ControllerBase
    {
        private readonly IApplicationServiceAccount _applicationServiceAccount;

        public AccountsController(IApplicationServiceAccount ApplicationServiceAccount)
        {
            _applicationServiceAccount = ApplicationServiceAccount;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AccountDTO>> GetAccounts()
        {
            return Ok(_applicationServiceAccount.GetAllWithChilds());
        }
        [HttpPost]
        public ActionResult CreateAccount([FromBody] AccDTO accDTO)
        {
            try
            {
                if (accDTO == null)
                    return NotFound();

                _applicationServiceAccount.Add(
                    new AccountDTO {AccountNumber= accDTO.AccountNumber, Balance = accDTO.Balance });
                return Ok("Account created successfully!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
