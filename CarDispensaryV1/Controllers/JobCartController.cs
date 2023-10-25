using CarDispensary.Controllers;
using CarDispensaryV1.Filter;
using CarDispensaryV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.UI.WebControls.WebParts;

namespace CarDispensaryV1.Controllers
{
    [JwtAuthentication]
    [EnableCors("*", "*", "*")]
    public class JobCartController : ApiController
    {

        CarDispensaryEntities CD = new CarDispensaryEntities();



        [HttpPost]
        [Route("api/JobCart/Add/{id}")]

        public IHttpActionResult Add(int id, item item)
        {
            if (item == null)
            {
                return Ok(new RegistrationResponse { Status = "Fail" });
            }

            item.orderId = id;
            CD.items.Add(item);
            CD.SaveChanges();

            return Ok(new RegistrationResponse { Status = "Success" });
        }




        [HttpGet]
        [Route("api/JobCart/Data/{id}")]

        public IHttpActionResult Data(int id)
        {
            if (id == 0)
            {
                return Ok(new RegistrationResponse { Status = "Fail" });
            }


            var item = CD.items.Where(i => i.orderId == id).ToList();


            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);

        }


        [HttpDelete]
        [Route("api/JobCart/deleteitem/{id}")]

        public IHttpActionResult deleteitem(int id)
        {
            if (id == 0)
            {
                return Ok(new RegistrationResponse { Status = "Fail" });
            }


            var item = CD.items.Find(id);

            if (item==null)
            {
                return NotFound();
            }

            CD.items.Remove(item);
            CD.SaveChanges();

            return Ok(item);

        }






    }

}
