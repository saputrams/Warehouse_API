using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Warehouse_API.Helper;
using Warehouse_API.Models;
using Warehouse_API.Models.ReportItem;

namespace Warehouse_API.Controllers
{
    public class ReportItemController : ApiController
    {

        Connection connection;

        ReportItemController()
        {
            connection = new Connection();
        }
        
        [HttpGet]
        public IHttpActionResult Get(string token,string userName)
        {
            ResponseData response = new ResponseData();
            try
            {
                IEnumerable<ReportItem> report = connection.Get<ReportItem>("RPT_Item_GET",
                    new { token, userName }).ToList();


                response.Message = "SUCCESS";
                response.Data = report;
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