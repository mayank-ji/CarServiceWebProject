using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Services.Description;
using CarDispensary.Controllers;
using CarDispensaryV1.Authentication;
using CarDispensaryV1.Filter;
using CarDispensaryV1.Models;

namespace CarDispensaryV1.Controllers
{
    [EnableCors("*", "*", "*")]
    public class OrderController : ApiController
    {
       
       CarDispensaryEntities CD = new CarDispensaryEntities();



        // At the time of Add cart
        #region Add orderDetail    
        [JwtAuthentication]

        [HttpPost]
        [Route("api/Order/orderDetail/{id}")]

        public IHttpActionResult orderDetail( int id, OrderDetail orderDetail)
        {
            if (orderDetail != null && id > 0) 
            {
                var ExistingCustomer = CD.Customers.Find(id);

                orderDetail.CustomerName = ExistingCustomer.CustName;
                orderDetail.CustAddress = ExistingCustomer.CustAddress;
                orderDetail.CustEmail = ExistingCustomer.CustEmail;
                orderDetail.CustMobileNo = ExistingCustomer.CustMobile;
                orderDetail.ServiceDone = true;
                CD.OrderDetails.Add(orderDetail);
                
                CD.SaveChanges();
                return Ok("OrderDetail Succefully Added...! ");

            }
            else
            {
                return Ok (" failed....");
            }

           
        }

        #endregion     

        #region update OrderDetail


        [HttpPut]
        [Route("api/Order/editOrder/{orderId}")]

        public IHttpActionResult editOrder(int orderId, OrderDetail orderDetail) 
        {

            OrderDetail  OD = CD.OrderDetails.Find(orderId);
            if (OD != null) 
            {
                OD.CarRegistrationNo = orderDetail.CarRegistrationNo;
                OD.VisitMode = orderDetail.VisitMode;   
                OD.CustMobileNo = orderDetail.CustMobileNo; 
                OD.CustAddress = orderDetail.CustAddress;   
                OD.CustomerName = orderDetail.CustomerName; 
                OD.GarageName = orderDetail.GarageName; 
                OD.ManufacturingYear = orderDetail.ManufacturingYear;   
                OD.OdometerReading = orderDetail.OdometerReading;   
                OD.VehicleModel = orderDetail.VehicleModel;
                 OD.ServiceId = orderDetail.ServiceId;    
                OD.CustEmail = orderDetail.CustEmail;
                OD.ServiceDone = orderDetail.ServiceDone; 
                OD.ServicePrice = orderDetail.ServicePrice; 
                OD.VarientName= orderDetail.VarientName;

                CD.SaveChanges();
                return Ok(new RegistrationResponse { Status = "Success" });
            }
            return Ok("Something Went Wrong...!");  
        }

        #endregion

        #region GetOrderDetail BY orderId
        [HttpGet]
        [Route("api/Order/GetOrderDetail/{OrderID}")]

        public IHttpActionResult GetOrderDetail(int  orderId) 
        
        {
           if(orderId != 0)
            {
               var result = CD.OrderDetails.Where(O=> O.OrderId == orderId).
                    Select(  O=>new
                    {
                        OrderId = orderId,  
                        CarRegistrationNo = O.CarRegistrationNo,
                         ManufacturingYear = O.ManufacturingYear.ToString(),
                        OdometerReading = O.OdometerReading,
                        VehicleModel =O.VehicleModel,
                        CustomerName = O.CustomerName,
                        CustMobileNo = O.CustMobileNo,
                        CustEmail = O.CustEmail,
                        CustAddress = O.CustAddress,
                        GarageName = O.GarageName,
                        ServiceName = O.Service.ServiceName,
                        ServicePrice = O.ServicePrice, 
                        VarientName = O.VarientName,
                        VisitMode = O.VisitMode,



                    }).Distinct().ToList();
                return Ok(result);
            }
            return BadRequest();
        }
        #endregion
    }
}









