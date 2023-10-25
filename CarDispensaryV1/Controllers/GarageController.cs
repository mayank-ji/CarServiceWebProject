using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using CarDispensaryV1.Models;

namespace CarDispensaryV1.Controllers
{
    [EnableCors("*", "*", "*")]
    public class GarageController : ApiController
    {
CarDispensaryEntities CD = new CarDispensaryEntities();



        #region Garage registration


        [HttpPost]
        [Route("api/Garage/registration")]

        public string registration(GarageDetail garageDetail) 
        {
            try
            {
                if (garageDetail != null)
                {
                    CD.GarageDetails.Add(garageDetail);
                    CD.SaveChanges();
                    return "Registration Success";
                }

                return "Something went Wrong";
            }

            catch (Exception ex) 
            {
               return "Something Went wrong";   
            }

        }

        #endregion


        #region Garage Login

        [HttpPost]
        [Route("api/Garage/login")]

        public IHttpActionResult login(GarageDetail garageDetail) 
        {


         if (garageDetail !=null)

            {
                var existingGarage = CD.GarageDetails.FirstOrDefault(g => g.GarageMobile == garageDetail.GarageMobile && g.Password == garageDetail.Password);

                if (existingGarage != null)
                {
                    

                    var garageId = existingGarage.Id;

                    return Ok(garageId);
                        }
            }

            else
            {
                return Ok("Invalid email or customer does not exist.");
            }

            return Ok("Invalid Garage data");
        }


        #endregion


    }
}
