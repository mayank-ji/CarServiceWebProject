using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using CarDispensary.Models;


namespace CarDispensary.Controllers

{

    [EnableCors("*", "*", "*")]
    public class CustomerController : ApiController
    {
        CarDispensaryEntities CD = new CarDispensaryEntities();



        #region Customer Registration

        [HttpPost]
        [Route("api/Customer/Registration")]

        public string Registration(Customer customer)
        {
            if (customer != null)
            {
                try
                {

                    CD.Customers.Add(customer);
                    CD.SaveChanges();


                    return "Customer registered successfully.";
                }
                catch (Exception ex)
                {
                    return "Error while registering customer: " + ex.Message;
                }
            }

            return "Invalid customer data.";
        }

        #endregion



        #region CustomerLogin

        [HttpPost]
        [Route("api/Customer/Login")]

        public IHttpActionResult Login(Customer customer)
        {
            if (customer != null)
            {
                var existingCustomer = CD.Customers.FirstOrDefault(c => c.CustEmail == customer.CustEmail && c.CustPassword == customer.CustPassword);
                if (existingCustomer != null)
                {

                    return Ok("Login successful.");
                }
                else
                {
                    return Ok("Invalid email or customer does not exist.");
                }
            }

            return Ok("Invalid customer data.");
        }

        #endregion


       

    }   
}