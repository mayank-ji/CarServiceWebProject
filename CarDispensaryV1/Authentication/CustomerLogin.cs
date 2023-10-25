using CarDispensaryV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Security;


namespace CarDispensaryV1.Authentication
{
    [EnableCors("*", "*", "*")]
    public class CustomerLogin
    {

        
        
            CarDispensaryEntities CD = new CarDispensaryEntities();


        [AllowAnonymous]
        [HttpGet]
        [Route("api/CustomerLogin/GetToken")]
        public string GetToken(string username, string password)
        {
            if (CheckCredentials(username, password))
            {
                return JwtToken.GenerateToken(username);
            }

            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }


        #region CheckCredentials
        public bool CheckCredentials(String username, String password)
            {

                var matchingCustomer = CD.Customers.FirstOrDefault(c =>
                    c.CustEmail == username &&
                    c.CustPassword == password);

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

            [Route("api/CustomerLogin/Signout")]
            public void Signout()
            {
                FormsAuthentication.SignOut();

            }

            #endregion
        
    }
}