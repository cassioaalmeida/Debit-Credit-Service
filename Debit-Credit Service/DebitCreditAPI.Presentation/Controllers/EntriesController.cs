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
    public class EntriesController : ControllerBase
    {
        private readonly IApplicationServiceEntry _applicationServiceEntry;

        public EntriesController(IApplicationServiceEntry ApplicationServiceEntry)
        {
            _applicationServiceEntry = ApplicationServiceEntry;
        }
    }
}
