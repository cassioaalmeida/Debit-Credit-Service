using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_applicationServiceAccount.GetAll());
        }
    }
}
