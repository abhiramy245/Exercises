using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WebApplication1.BusinessLayer
{
    public class Customer
    {
        // Loading the xml file
        XDocument xml = XDocument.Load(@"D:\Exercises\CustomerApplication\Customer.xml");

        /// <summary>
        /// Get the details of all customers in the ascending order of city
        /// </summary>
        /// <returns>result as string</returns>
        public string GetInfo()
        {
         

            // Query the data using linq
            var result = from c in xml.Root.Descendants("Customer") orderby (string)c.Element("City").Value ascending
                         select c;
            string info = "";
            foreach (var data in result)
            {
                info += data.Element("CustomerID").Value + "\t" + data.Element("City").Value + "\t" + data.Element("ContactName").Value + "\n";
            }

            return info;
        }

        /// <summary>
        /// Get the details of customers whose city id London
        /// </summary>
        
        public string GetByCity()
        {

            // Query the data using linq 
            var result = from c in xml.Root.Descendants("Customer")
                         where (string)c.Element("City").Value == "London"
                         select c;
            string info = "";
            foreach (var data in result)
            {
                info += data.Element("CustomerID").Value + "\t" + data.Element("City").Value + "\t" + data.Element("ContactName").Value + "\n";
            }

            return info;

        }

        /// <summary>
        /// Get the count of customers in each city
        /// </summary>
       
        public string CustomerCountByCity()
        {
         
            // Query the data using linq
            var result = from c in xml.Root.Descendants("Customer")
                         group c by (string)c.Element("City") into grp
                         select new { city = grp.Key,count = grp.Count() };
            string info = "";
            foreach (var data in result)
            {
                info += data + "\n";
            }

            return info;

        }

        /// <summary>
        /// List all customer details
        /// </summary>
        /// <returns>result as string</returns>
        public string ListCustomers()
        {


            // Query the data using linq
            var result = from c in xml.Root.Descendants("Customer")
                         select new
                         {
                            CustomerId= c.Element("CustomerID").Value,
                            City= c.Element("City").Value,
                            ContactName = c.Element("ContactName").Value
                         }
                         ;
            string info = "";
            foreach (var data in result)
            {
                info += data + "\n";
            }

            return info;
        }

        /// <summary>
        /// Get the details of customers group by city
        /// </summary>
        /// <returns>result as json</returns>
        public ObjectResult CustomersByCity()
        {
            

            // Query the data using lambda expression
            var result = xml.Descendants("Customer")
                         .Select(x => new
                         {
                             city = (string)x.Element("City").Value,
                             contactName = (string)x.Element("ContactName").Value
                         }).GroupBy(x => x.city);




            return new ObjectResult(result);

        }
    }
}
