using CarDispensary.Controllers;
using CarDispensaryV1.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Security;

namespace CarDispensaryV1.Controllers
{
    [EnableCors("*", "*", "*")]
    public class CustomerTokenController : ApiController
    {


        CarDispensaryEntities CD = new CarDispensaryEntities();


        #region getToken 

        [AllowAnonymous]
        [HttpGet]
        [Route("api/CustomerToken/Get/{username}/{password}")]
        public IHttpActionResult Gettoken(string username, string password)
        {
            if (CheckCredentials(username, password))
            {
                var matchingCustomer = CD.Customers.FirstOrDefault(cust => cust.CustEmail == username && cust.CustPassword == password);

                var id = matchingCustomer.Id;

                String Token =  JwtToken.GenerateToken(username);

                var response = new RegistrationResponse
                {
                    Status = "Success",
                    Message = "Customer Login successfully.",
                    CustomerId = id,
                    Token = Token
                };

                return Ok(response);
            }

            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

        #endregion

        #region CheckCredentials
        public bool CheckCredentials(String username, String password)
        {

            var matchingCustomer = CD.Customers.FirstOrDefault(cust => cust.CustEmail == username && cust.CustPassword == password);

            if (matchingCustomer != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion



        #region Singout
        [AllowAnonymous]
        [Route("api/CustomerLogin/Signout")]
        public void Signout()
        {
            FormsAuthentication.SignOut();

        }

        #endregion

    }


}

