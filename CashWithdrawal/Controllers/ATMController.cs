using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CashWithdrawal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ATMController : ControllerBase
    {
        private readonly IATM atm;

        public ATMController(IATM atm)
        {
            this.atm = atm;
        }

        [HttpGet("{amount}")]
        public ActionResult<List<decimal>> Get(decimal? amount)
        {
            try
            {
                return atm.GetNotes(amount);
            }
            catch(InvalidArgumentException)
            {
                return BadRequest("Cannot withdraw negative amount.");
            }
            catch(NoteUnavailableException)
            {
                return BadRequest("Cannot withdraw the requested amount. Please use amount dividable by 10.");
            }
        }
    }
}
