using CarDispensary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Services.Description;
using System.Web.Http.Cors;

namespace CarDispensary.Controllers
{

    [EnableCors("*","*","*")]
    
    public class ServiceController : ApiController
    {
        CarDispensaryEntities CD = new CarDispensaryEntities();







        #region  GetAllCarBrands

        [HttpGet]
        [Route("api/Service/GetCarBrands")]
        public IHttpActionResult GetCarBrands()
        {
            var result = CD.Brands.Select(r => new
            {
                BrandName = r.BrandName,
                BrandImage = "http://localhost:56084/images/" + r.BrandImage,

            }).ToList();

            return Ok(result);
        }
        #endregion



        #region GetAllCarCategorys

        [HttpGet]
        [Route("api/Service/GetCarCategory")]
        public IHttpActionResult GetCarCategory()
        {
            var result = CD.Categories.Select(r => new
            {
                CategoryName = r.CateName

            }).ToList();

            return Ok(result);
        }
        #endregion


        #region GetAllCarModelS Of specific BrandId 

        [HttpGet]
        [Route("api/Service/GetAllCarModel/{brandId}")]

        public IHttpActionResult GetAllCarModel(int brandId)
        {

            var result = CD.RateCharts
                .Where(r=>r.BrandId == brandId).
                Select(r=>new
                {
                    ModelName = r.CarModel.ModelName
                }).Distinct().ToList();
            return Ok(result);   
        }
        #endregion

        #region GetAll Vareint 

        [HttpGet]
        [Route("api/Service/GetAllVarient")]
        
        public IHttpActionResult GetAllVarient()
        {
            var result = CD.Varients.
                Where(r => r.VarientId == 1 )
                .Select(r => new 
                {
                    VarImage = "http://localhost:56084/images/" + r.VarImage,            
                }).ToList();
                

            return Ok(result);
        }

        #endregion


        #region Get A Specific CarModel With Specific Varient and its All Service price basis of BrandId  and VarientId 


        [HttpGet]
        [Route("api/Service/GetCarModel/{brandId}/{serviceId}/{varientId}")]
        public IHttpActionResult GetCarModel(int brandId , int serviceId , int varientId)
        {
            var result = CD.RateCharts
                .Where(r => r.BrandId == brandId &&  r.ServiceId==serviceId && r.VarientId==varientId)
                .Select(r => new
                {
                    VarImage = "http://localhost:56084/images/" + r.CarModel.ModelImage,
                    ModelName = r.CarModel.ModelName,
                    ServiceName = r.Service.ServiceName,
                    price = r.Price
                   
                })
                .Distinct()
                .ToList();

            return Ok(result);
        }

        #endregion
  
    
    
    
    }
}
