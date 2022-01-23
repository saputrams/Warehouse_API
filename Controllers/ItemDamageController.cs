using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Warehouse_API.Helper;
using Warehouse_API.Models;
using Warehouse_API.Models.ItemDamage;

namespace Warehouse_API.Controllers
{
    [System.Web.Mvc.ValidateAntiForgeryToken]
    public class ItemDamageController : ApiController
    {
        Connection connection;

        ItemDamageController()
        {
            connection = new Connection();
        }

        [HttpGet]
        public IHttpActionResult Get(string token, string userName)
        {
            ResponseData response = new ResponseData();
            try
            {
                IEnumerable<ItemDamage> itemDamage = connection.Get<ItemDamage>("ItemDamage_GET",
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
        public IHttpActionResult Post([FromBody] ItemDamageData data, string token, string userName)
        {
            ResponseData response = new ResponseData();
            try
            {
                string itemId = data.ItemId;
                double qty = data.Qty;
                string note = data.Note;
                string locationId = data.LocationId;

                ItemDamage itemDamage = connection.Get<ItemDamage>("ItemDamage_POST",
                    new { itemId, qty, note, locationId, token, userName }).FirstOrDefault();


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