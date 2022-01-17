using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Warehouse_API.Helper;
using Warehouse_API.Models;
using Warehouse_API.Models.Order;
using Warehouse_API.Models.Shipping;

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

        [HttpPost]
        public IHttpActionResult Post([FromBody] ShippingData ship, string token, string userName)
        {
            ResponseData response = new ResponseData();
            IEnumerable<OrderDetail> orderDetail = null;
            Order orderData;
            try
            {

                var orderId = ship.OrderId;
                var name = ship.Name;
                var phoneNo = ship.PhoneNo;
                var address = ship.Address;
                var shipmentNo = ship.ShipmentNo;
                var courierName = ship.CourierName;
                var courierId = ship.CourierId;

                IEnumerable<OrderFetch> data = connection.Get<OrderFetch>("Shipping_POST", new { orderId, name, phoneNo, address, shipmentNo, courierName, courierId, token, userName }).ToList();
                var s = data.Select(x => new { x.OrderId, x.OrderNo, x.OrderDate, x.Status, x.OrderType }).Distinct().FirstOrDefault();
                
                orderData = new Order();
                orderDetail = data.Where(e => e.OrderId == s.OrderId).Select(y => new OrderDetail { OrderDetailId = y.OrderDetailId, ItemId = y.ItemId, ItemNo = y.ItemNo, ItemDesc = y.ItemDesc, Qty = y.Qty, QtyScanning = y.QtyScanning }).Distinct().ToList();

                orderData.OrderId = s.OrderId;
                orderData.OrderNo = s.OrderNo;
                orderData.OrderDate = s.OrderDate;
                orderData.OrderType = s.OrderType;
                orderData.Status = s.Status;
                orderData.OrderDetail = (List<OrderDetail>)orderDetail;

                response.Message = "SUCCESS";
                response.Data = orderData;
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