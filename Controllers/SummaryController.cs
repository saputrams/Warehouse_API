using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Warehouse_API.Helper;
using Warehouse_API.Models;
using Warehouse_API.Models.Summary;

namespace Warehouse_API.Controllers
{
    public class SummaryController : ApiController
    {

        Connection connection;

        SummaryController()
        {
            connection = new Connection();
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] SummaryData data, string token, string userName)
        {
            ResponseData response = new ResponseData();
            try
            {
                DateTime fromDate = data.FromDate;
                DateTime toDate = data.ToDate;
                Summary summary = connection.Get<Summary>("Summary_GET",
                    new { fromDate, toDate, token, userName }).FirstOrDefault();


                response.Message = "SUCCESS";
                response.Data = summary;
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