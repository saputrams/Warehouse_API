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
    public class OrderCancelledController : ApiController
    {
        Connection connection;

        OrderCancelledController()
        {
            connection = new Connection();
        }

        [HttpPost]
        public IHttpActionResult Post(string orderId, string token, string userName)
        {
            ResponseData response = new ResponseData();
            try
            {
                IEnumerable<Item> itemDamage = connection.Get<Item>("OrderCancelled_POST",
                    new { orderId,token, userName }).ToList();


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