using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Warehouse_API.Helper;
using Warehouse_API.Models;
using Warehouse_API.Models.Item;

namespace Warehouse_API.Controllers
{
    [System.Web.Mvc.ValidateAntiForgeryToken]
    public class ItemController : ApiController
    {
        Connection connection;

        ItemController()
        {
            connection = new Connection();
        }

        [HttpGet]
        public IHttpActionResult Get(string token, string userName)
        {
            ResponseData response = new ResponseData();
            try
            {
                string itemId = "";
                string filter = "";
                string search = "";
                IEnumerable<Item> item = connection.Get<Item>("Item_GET",
                    new { itemId, filter, search, token, userName }).ToList();


                response.Message = "SUCCESS";
                response.Data = item;
                return this.Content(HttpStatusCode.OK, response);
            }
            catch (Exception error)
            {

                response.Message = error.Message;
                response.Data = null;
                return this.Content(HttpStatusCode.BadRequest, response);
            }
        }

        [HttpGet]
        public IHttpActionResult Get(string id, string token, string userName)
        {
            ResponseData response = new ResponseData();
            try
            {
                string itemId = id;
                string filter = "";
                string search = "";
                Item item = connection.Get<Item>("Item_GET", new { itemId, filter, search, token, userName }).FirstOrDefault();


                response.Message = "SUCCESS";
                response.Data = item;
                return this.Content(HttpStatusCode.OK, response);
            }
            catch (Exception error)
            {

                response.Message = error.Message;
                response.Data = null;
                return this.Content(HttpStatusCode.BadRequest, response);
            }
        }

        [HttpGet]
        public IHttpActionResult Get(string id, string userFilter, string userSearch, string token, string userName)
        {
            ResponseData response = new ResponseData();
            try
            {
                string itemId = id;
                string filter = userFilter;
                string search = userSearch;
                IEnumerable<Item> item = connection.Get<Item>("Item_GET", new { itemId, filter, search, token, userName }).ToList();


                response.Message = "SUCCESS";
                response.Data = item;
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
        public IHttpActionResult Post([FromBody]ItemData data, string token, string userName)
        {
            ResponseData response = new ResponseData();
            try
            {
                string itemId = data.ItemId;
                string itemNo = data.ItemNo;
                string style = data.Style;
                string size = data.Size;
                string desc = data.Desc;
                double qty = data.Qty;
                double price = data.Price;
                string categoryId = data.CategoryId;
                Item item = connection.Get<Item>("Item_POST",
                    new { itemId, itemNo, style, size, desc, qty, price, categoryId, token, userName }).FirstOrDefault();


                response.Message = "SUCCESS";
                response.Data = item;
                return this.Content(HttpStatusCode.OK, response);
            }
            catch (Exception error)
            {

                response.Message = error.Message;
                response.Data = null;
                return this.Content(HttpStatusCode.BadRequest, response);
            }
        }

        // DELETE: api/Item/5
        public IHttpActionResult Delete(string itemId, string token, string userName)
        {
            ResponseData response = new ResponseData();
            try
            {
                connection.Get<Item>("Item_DEL", new { itemId, token, userName });

                response.Message = "SUCCESS";
                response.Data = null;
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
