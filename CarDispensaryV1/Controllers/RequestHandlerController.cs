using CarDispensaryV1.Filter;
using CarDispensaryV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CarDispensaryV1.Controllers
{
    [EnableCors("*", "*", "*")]
    public class RequestHandlerController : ApiController
    {

        
        CarDispensaryEntities CD = new CarDispensaryEntities();


        Random random = new Random();

        #region  show order Request to appropriate Garage
        [JwtAuthentication]
        [HttpGet]
        [Route("api/RequestHandler/Detail/{id}")]  //Garage Id l
        public IHttpActionResult Detail(int id)
        {

            
                try
                {
                    Random random = new Random();
                    int randomNumber = random.Next(1, 1);

                    if (id == randomNumber)
                    {
                        var Data = CD.OrderDetails.Where(orderDetail => orderDetail.ServiceDone == true).Select(orderDetail => new
                        {
                            Id = orderDetail.OrderId,
                            VehicleModel = orderDetail.VehicleModel,
                             VarientName = orderDetail.VarientName,
                    


                        }).ToList();

                        return Ok(Data);
                    }

                    return Ok("No Service available");
                }
                catch (Exception ex)
                {

                    return InternalServerError(ex);
                }
            }


        #endregion


        #region  response by garage order accepted or Not
        [JwtAuthentication]
        [HttpPut]
            [Route("api/RequestHandler/OrderAccept/{Id}")]

            public IHttpActionResult OrderAccept(int Id)
            {
                OrderDetail OD = CD.OrderDetails.Find(Id);
                if (OD != null)
                {
                    OD.ServiceDone = false;
                CD.SaveChanges();

                return Ok("Done...!");
                }
                return Ok("Not Done...!");

            }

            #endregion

        }
 }
