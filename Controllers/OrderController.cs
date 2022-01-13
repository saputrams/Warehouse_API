using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Warehouse_API.Helper;
using Warehouse_API.Models;
using Warehouse_API.Models.Order;

namespace Warehouse_API.Controllers
{
    public class OrderController : ApiController
    {

        Connection connection;

        OrderController()
        {
            connection = new Connection();
        }

        [HttpGet]
        public IHttpActionResult Get(string token, string userName)
        {
            ResponseData response = new ResponseData();
            List<Order> order = new List<Order>();
            IEnumerable<OrderDetail> orderDetail = null;
            Order orderData;
            try
            {
                IEnumerable<OrderFetch> data = connection.Get<OrderFetch>("Order_GET", new { token, userName }).ToList();
                foreach (var s in data.Select(x => new { x.OrderId, x.OrderNo, x.OrderDate, x.Status, x.OrderType }).Distinct().ToList())
                {
                    orderData = new Order();
                    orderDetail = data.Where(e => e.OrderId == s.OrderId).Select(y => new OrderDetail { OrderDetailId = y.OrderDetailId, ItemNo = y.ItemNo, ItemDesc = y.ItemDesc, Qty = y.Qty, QtyScanning = y.QtyScanning }).Distinct().ToList();

                    orderData.OrderId = s.OrderId;
                    orderData.OrderNo = s.OrderNo;
                    orderData.OrderDate = s.OrderDate;
                    orderData.OrderType = s.OrderType;
                    orderData.Status = s.Status;
                    orderData.OrderDetail = (List<OrderDetail>)orderDetail;

                    order.Add(orderData);
                }


                response.Message = "SUCCESS";
                response.Data = order;
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