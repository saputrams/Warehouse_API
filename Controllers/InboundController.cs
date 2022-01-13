using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Warehouse_API.Helper;
using Warehouse_API.Models;
using Warehouse_API.Models.Inbound;

namespace Warehouse_API.Controllers
{
    [System.Web.Mvc.ValidateAntiForgeryToken]
    public class InboundController : ApiController
    {
        Connection connection;

        InboundController()
        {
            connection = new Connection();
        }

        [HttpGet]
        public IHttpActionResult Get(string token, string userName)
        {
            ResponseData response = new ResponseData();
            List<Inbound> inbound = new List<Inbound>() ;
            IEnumerable<InboundDetail> inboundDetail = null;
            Inbound inboundData;
            try
            {
                IEnumerable<InboundFetch> data = connection.Get<InboundFetch>("Inbound_GET", new { token, userName }).ToList();
                foreach (var s in data.Select(x => new { x.OrderId, x.OrderNo, x.OrderDate, x.Status, x.OrderType }).Distinct().ToList())
                {
                    inboundData = new Inbound();
                    inboundDetail = data.Where(e => e.OrderId == s.OrderId).Select(y => new InboundDetail { OrderDetailId = y.OrderDetailId, ItemNo = y.ItemNo, Qty = y.Qty, QtyScanning = y.QtyScanning }).Distinct().ToList();

                    inboundData.OrderId = s.OrderId;
                    inboundData.OrderNo = s.OrderNo;
                    inboundData.OrderDate = s.OrderDate;
                    inboundData.OrderType = s.OrderType;
                    inboundData.Status = s.Status;
                    inboundData.OrderDetail = (List<InboundDetail>)inboundDetail;

                    inbound.Add(inboundData);
                }


                response.Message = "SUCCESS";
                response.Data = inbound;
                return this.Content(HttpStatusCode.OK, response);
            }
            catch(Exception error)
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