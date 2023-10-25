using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using CarDispensary.Controllers;
using CarDispensaryV1.Filter;
using CarDispensaryV1.Models;

namespace CarDispensaryV1.Controllers
{

    [JwtAuthentication]
    [EnableCors("*", "*", "*")]
    public class InventoryController : ApiController
    {
        

        CarDispensaryEntities CD = new CarDispensaryEntities();



        #region Inventory Added

        [HttpPost]
        [Route("api/Inventory/addInventory/{id}")]


        public IHttpActionResult addInventory(int id , InventoryDetail inventoryDetail)
        {
            if (inventoryDetail != null)
            {

                //inventoryDetail.ExId = CD.ExteriorImages.FirstOrDefault(Exe => Exe.Id == id)?.Id;
                //inventoryDetail.InId = CD.InteriorImages.FirstOrDefault(In => In.Id == id)?.Id;


                try
                {
                    inventoryDetail.OrderId = id;

                    CD.InventoryDetails.Add(inventoryDetail);
                    //CD.SaveChanges();

                    return Ok(new RegistrationResponse { Status = "Success"  });

                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
            }

            return BadRequest("Inventory Detail Not Added!");
        }


        #endregion


        #region ExteriorImage


        [HttpPost]
        [Route("api/Inventory/addExteriorImage/{id}")]
        //public async Task<IHttpActionResult> addExteriorImage(int id)
        //{
        //    try
        //    {
        //        if (!Request.Content.IsMimeMultipartContent())
        //        {
        //            return BadRequest("unsupported");

        //        }

        //        var provider = new MultipartMemoryStreamProvider();

        //        await Request.Content.ReadAsStreamAsync();

        //        ArrayList arrayList = new ArrayList();

        //        if (provider.Contents != null)
        //        {
        //            for (int i = 0; i < 5; i++)
        //            {
        //                foreach (var item in provider.Contents)
        //                {
        //                    var fileBytes = await item.ReadAsByteArrayAsync();
        //                    var fileName = $"{i}_{item.Headers.ContentDisposition.FileName.Trim('\"')}";
        //                    var filepath = Path.Combine(HttpContext.Current.Server.MapPath("~images"), fileName);

        //                    File.WriteAllBytes(filepath, fileBytes);
        //                    arrayList.Add(fileName);


        //                }

        //            }

        //            ExteriorImage exteriorImage = new ExteriorImage();

        //            for (int i = 0; i < 5; i++)
        //            {
        //                foreach (var item in arrayList)
        //                {
        //                    if (i == 0)
        //                        exteriorImage.Right = (string)item;
        //                    if (i == 1)
        //                        exteriorImage.Left = (string)item;
        //                    if (i == 2)
        //                        exteriorImage.Front = (string)item;
        //                    if (i == 3)
        //                        exteriorImage.Rear = (string)item;
        //                }
        //            }

        //            CD.ExteriorImages.Add(exteriorImage);
        //            CD.SaveChanges();

        //            return Ok("Success");
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        return BadRequest(ex.Message);  
        //    }
        //    return Ok("Failed");


        //}

       
        public async Task<IHttpActionResult> addExteriorImage(int id)
        {
            try
            {
                if (!Request.Content.IsMimeMultipartContent())
                {
                    return BadRequest("Unsupported content type");
                }

                var provider = new MultipartMemoryStreamProvider();

                await Request.Content.ReadAsMultipartAsync(provider);

                var arrayList = new List<string>();

                foreach (var item in provider.Contents)
                {
                    var fileBytes = await item.ReadAsByteArrayAsync();
                    var fileName = item.Headers.ContentDisposition.FileName.Trim('\"');
                    var filepath = Path.Combine(HttpContext.Current.Server.MapPath("~/images"), fileName);

                    File.WriteAllBytes(filepath, fileBytes);
                    arrayList.Add(fileName);
                }

                if (arrayList.Count < 4)
                {
                    return BadRequest("Insufficient images uploaded");
                }

                var exteriorImage = new ExteriorImage
                {
                    Right = arrayList[0],
                    Left = arrayList[1],
                    Front = arrayList[2],
                    Rear = arrayList[3]
                };

                CD.ExteriorImages.Add(exteriorImage);
                CD.SaveChanges();

                return Ok("Success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }







        #endregion


        #region InteriorIamage

        [HttpPost]
        [Route("api/Inventory/addInteriorImage/{id}")]
        public IHttpActionResult addInteriorImage(InteriorImage interiorImage, int id )
        {
            if (interiorImage != null)
            {
                try
                {
                    interiorImage.OId = id;

                        CD.InteriorImages.Add(interiorImage);
                        CD.SaveChanges();

                        return Ok("Interior Image Added successfully!");
                    
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
            }

            return BadRequest("Interior Image Not Added!");
        }

        #endregion

    }
}

