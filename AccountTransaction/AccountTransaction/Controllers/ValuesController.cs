using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AccountTransaction.BusinessLayer;

namespace AccountTransaction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        //Creating an object to access the account and transaction
        AccessAccount access = new AccessAccount();

        /// <summary>
        /// Get all account details
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<object>> Get()
        { 
            return access.AllAccounts();
        }

        /// <summary>
        /// Get the active account details
        /// </summary>
        /// <returns></returns>
        [Route("active")]
        public ActionResult<List<object>> ActiveAccounts()
        {
          
            return access.GetActiveAccounts();

        }

        /// <summary>
        /// Get the accounts with minimum balance 10000/-
        /// </summary>
        /// <returns></returns>
        [Route("minimum")]
        public ActionResult<List<object>> MinimumMaintained()
        {
           
            return access.GetValidBalanceAccounts();

        }

        /// <summary>
        /// Get the active accounts with balance less than or equal to 500/-
        /// </summary>
        /// <returns></returns>
        [Route("lowbalance")]
        public ActionResult<List<object>> LowBalance()
        {
            return access.GetLowBalanceAccounts();

        }






    }
}
