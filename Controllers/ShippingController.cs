using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Warehouse_API.Helper;
using Warehouse_API.Models;

namespace Warehouse_API.Controllers
{
    [System.Web.Mvc.ValidateAntiForgeryToken]
    public class ShippingController : ApiController
    {
        Connection connection;
        ShippingController()
        {
            connection = new Connection();
        }

        [HttpGet]
        public IHttpActionResult Get(string orderId, string token, string userName)
        {
            ResponseData response = new ResponseData();
            try
            {
                Shipping shipping = connection.GetSingle<Shipping>("Shipping_GET",
                    new { orderId, token, userName });

                response.Message = "SUCCESS";
                response.Data = shipping;
                return this.Content(HttpStatusCode.OK, response);
            }
            catch (Exception error)
            {

                response.Message = error.Message;
                response.Data = null;
                return this.Content(HttpStatusCode.BadRequest, response);
            }
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}