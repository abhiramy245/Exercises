using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.BusinessLayer;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        /// <summary>
        /// All details of customer in the ascending order of city
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<string> Get()
        {
            Customer customer = new Customer();
            return customer.GetInfo();
        }

        /// <summary>
        /// List details of customer based on city
        /// </summary>
        /// <returns></returns>
        [Route("London")]
        public ActionResult<string> SearchByCity()
        {
            Customer customer = new Customer();
            return customer.GetByCity();
        }

        /// <summary>
        /// Count of customers in each city
        /// </summary>
        /// <returns></returns>
        [Route("count")]
        public ActionResult<string> Count()
        {
            Customer customer = new Customer();
            return customer.CustomerCountByCity();
        }

        /// <summary>
        /// List all customers
        /// </summary>
        /// <returns></returns>
        [Route("list")]
        public ActionResult<string> GetAll()
        {
            Customer customer = new Customer();
            return customer.ListCustomers();
        }

        /// <summary>
        /// Display customers group by city
        /// </summary>
        /// <returns></returns>
        [Route("bycity")]
        public ActionResult<string> CustomersOfCity()
        {
            Customer customer = new Customer();
            return customer.CustomersByCity();
           
        }

    }
}