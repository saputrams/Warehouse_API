using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Warehouse_API.Helper;
using Warehouse_API.Models;
using Warehouse_API.Models.Scan;

namespace Warehouse_API.Controllers
{
    [System.Web.Mvc.ValidateAntiForgeryToken]
    public class ScanController : ApiController
    {
        Connection connection;

        ScanController()
        {
            connection = new Connection();
        }

        [HttpGet]
        public IHttpActionResult Get(string orderId, string token, string userName)
        {
            ResponseData response = new ResponseData();
            try
            {
                IEnumerable<Scan> scan = connection.Get<Scan>("Scan_GET",
                    new { orderId, token, userName }).ToList();


                response.Message = "SUCCESS";
                response.Data = scan;
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