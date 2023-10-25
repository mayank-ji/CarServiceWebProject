using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Services.Description;
using CarDispensaryV1.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;


namespace CarDispensary.Controllers

{
   
    [EnableCors("*", "*", "*")]
   
    public class CustomerController : ApiController
    {
        CarDispensaryEntities CD = new CarDispensaryEntities();



        #region Customer Registration

        [HttpPost]
        [Route("api/Customer/Registration")]

        public IHttpActionResult Registration(Customer customer)
        {
            if (customer != null)
            {
                try
                {
                    CD.Customers.Add(customer);
                    CD.SaveChanges();

                    var response = new RegistrationResponse
                    {
                        Status = "Success",
                        Message = "Customer registered successfully."
                    };

                    return Ok(response);
                }
                catch (Exception ex)
                {
                    var response = new RegistrationResponse
                    {
                        Status = "Error",
                        Message = "Error while registering customer: " + ex.Message
                    };

                    return Ok(response);
                }
            }

            var invalidResponse = new RegistrationResponse
            {
                Status = "Error",
                Message = "Invalid customer data."
            };
            return Ok(invalidResponse);
        }
      


        #endregion

         #region CustomerLogin

                [HttpPost]
        [Route("api/Customer/Login")]

        public String Login(Customer customer)
        {
            
                var existingCustomer = CD.Customers.FirstOrDefault(c => c.CustEmail == customer.CustEmail && c.CustPassword == customer.CustPassword);
                if (existingCustomer != null)
                {

                    var response = new RegistrationResponse
                    {
                        Status = "Success",
                        Message = "Customer Login successfully.",
                        CustomerId = existingCustomer.Id
                    };

                    return JsonConvert.SerializeObject(response);
                }
                else
                {
                    var invalidResponse = new RegistrationResponse
                    {
                        Status = "Error",
                        Message = "Invalid customer data."
                    };
                    return JsonConvert.SerializeObject(invalidResponse);
                }
            }

           

        #endregion




    }
}