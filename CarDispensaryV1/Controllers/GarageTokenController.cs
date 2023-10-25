using CarDispensary.Controllers;
using CarDispensaryV1.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Web.Http;

namespace CarDispensaryV1.Controllers
{
    public class GarageTokenController : ApiController
    {
        CarDispensaryEntities CD = new CarDispensaryEntities(); 

        #region getToken 

        [AllowAnonymous]
        [HttpGet]
        [Route("api/GarageToken/GetToken/{username}/{password}")]
        public IHttpActionResult GetToken(string username,string password)
        {
            if (CheckCredentials(username, password))
            {

                var matchingGarage = CD.GarageDetails.FirstOrDefault(garage => garage.GarageMobile == username && garage.Password == password);

                if (matchingGarage != null)
                {
                    var id = matchingGarage.Id;

                  String Token =    JwtToken.GenerateToken(username);

                    var response = new RegistrationResponse
                    {
                        Status = "Success",
                        Message = "Customer Login successfully.",
                        CustomerId = id,
                        Token = Token
                    };


                    return Ok(response);
                }
            }

            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

        #endregion

        #region CheckCredentials
        public bool CheckCredentials(String username, String password)
        {

            var matchingGarage =CD.GarageDetails.FirstOrDefault(garage => garage.GarageMobile  == username && garage.Password == password);

            if (matchingGarage != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
