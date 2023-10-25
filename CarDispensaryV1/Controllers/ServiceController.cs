using CarDispensaryV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Services.Description;
using System.Web.Http.Cors;
using CarDispensaryV1.Authentication;
using CarDispensaryV1.Filter;

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
                BrandId = r.BrandId,    
                BrandName = r.BrandName,
                BrandImage = "http://localhost:63650//images/" + r.BrandImage,

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
                    ModelId = r.CarModel.ModelId,
                    ModelName = r.CarModel.ModelName,
                     BrandImage = "http://localhost:63650//images/" + r.CarModel.ModelImage,
                }).Distinct().ToList();
            return Ok(result);   
        }
        #endregion

        #region GetAll Vareint 
        
        [HttpGet]
        [Route("api/Service/GetAllVarient")]
        
        public IHttpActionResult GetAllVarient()
        {
            var result = CD.Varients
                .Select(r => new 
                {
                    VarientId = r.VarientId,    
                    VarName = r.VarName,
                    VarImage = "http://localhost:63650//images/" + r.VarImage,          
                }).ToList();
                

            return Ok(result);
        }

        #endregion


        #region Get A Specific CarModel With Specific Varient and its All Service price basis of BrandId  and VarientId 

       
        [HttpGet]
        [Route("api/Service/GetCarModel/{modelId}/{varientId}")]
        public IHttpActionResult GetCarModel( int modelId , int varientId)
        {
            var result = CD.RateCharts
                .Where(r =>  r.ModelId == modelId && r.VarientId==varientId)
                .Select(r => new
                {
                    ModelImage = "http://localhost:63650//images/" + r.CarModel.ModelImage,
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
