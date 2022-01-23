using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Warehouse_API.Helper;
using Warehouse_API.Models;
using Warehouse_API.Models.ItemExpired;

namespace Warehouse_API.Controllers
{
    [System.Web.Mvc.ValidateAntiForgeryToken]
    public class ItemExpiredController : ApiController
    {
        Connection connection;

        ItemExpiredController()
        {
            connection = new Connection();
        }

        [HttpGet]
        public IHttpActionResult Get(string token, string userName)
        {
            ResponseData response = new ResponseData();
            try
            {
                IEnumerable<ItemExpired> itemDamage = connection.Get<ItemExpired>("ItemExpired_GET",
                    new { token, userName }).ToList();


                response.Message = "SUCCESS";
                response.Data = itemDamage;
                return this.Content(HttpStatusCode.OK, response);
            }
            catch (Exception error)
            {

                response.Message = error.Message;
                response.Data = null;
                return this.Content(HttpStatusCode.BadRequest, response);
            }
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] ItemExpiredData data,string token, string userName)
        {
            ResponseData response = new ResponseData();
            try
            {

                string itemId = data.ItemId;
                double qty = data.Qty;
                DateTime expiredDate = data.ExpiredDate;
                string locationId = data.LocationId;

                ItemExpired itemDamage = connection.Get<ItemExpired>("ItemExpired_POST",
                    new { itemId, qty, expiredDate, locationId, token, userName }).FirstOrDefault();


                response.Message = "SUCCESS";
                response.Data = itemDamage;
                return this.Content(HttpStatusCode.OK, response);
            }
            catch (Exception error)
            {

                response.Message = error.Message;
                response.Data = null;
                return this.Content(HttpStatusCode.BadRequest, response);
            }
        }
    }
}