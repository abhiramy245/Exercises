using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CustomerApplication.BusinessLayer
{
    public class Customer
    {
        public dynamic GetInfo()
        {
            // Loading from a file
            var xml = XDocument.Load(@"D:\Exercises\CustomerApplication\Customer.xml");


            // Query the data 
            IEnumerable<XElement> query = from c in xml.Root.Descendants("Customer").AsEnumerable()
                                          select c;

            return query;

        }
    }
}
