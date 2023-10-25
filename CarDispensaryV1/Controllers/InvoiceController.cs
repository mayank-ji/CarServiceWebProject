using CarDispensary.Controllers;
using CarDispensaryV1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CarDispensaryV1.Controllers
{
    [EnableCors("*", "*", "*")]
    public class InvoiceController : ApiController
    {

        CarDispensaryEntities CD = new CarDispensaryEntities();

        [HttpGet]
        [Route("api/Invoice/getData/{id}")]

        public IHttpActionResult getData(int id)
        {
            if (id == 0)
            {
                return Ok(new RegistrationResponse { Status = "Fail" });
            }
            var result = from item in CD.items
                         join orderDetail in CD.OrderDetails
                         on item.orderId equals orderDetail.OrderId
                         where item.orderId == id 
                         select new
                         {
                             OrderId = item.orderId,
                             Part = item.part,
                             CustName = orderDetail.CustomerName,
                             CustAddress = orderDetail.CustAddress,
                             CustMobile = orderDetail.CustMobileNo,
                             Model = orderDetail.VehicleModel,
                             Varient = orderDetail.VarientName,
                             Price=item.price,
                             Amount = item.amount,
                             Qty = item.qty, 
                             Reg = orderDetail.CarRegistrationNo,
                            
                         };

            return Ok(result);



        }
    }
}
