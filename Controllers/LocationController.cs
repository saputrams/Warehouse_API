using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Warehouse_API.Helper;
using Warehouse_API.Models;
using Warehouse_API.Models.Location;

namespace Warehouse_API.Controllers
{
    [System.Web.Mvc.ValidateAntiForgeryToken]
    public class LocationController : ApiController
    {
        Connection connection;

        LocationController()
        {
            connection = new Connection();
        }

        [HttpGet]
        public IHttpActionResult Get(string token, string userName)
        {
            ResponseData response = new ResponseData();
            try
            {
                string locationId = "";
                string filter = "";
                string search = "";
                IEnumerable<Location> location = connection.Get<Location>("Location_GET",
                    new { locationId, filter, search, token, userName }).ToList();

                response.Message = "SUCCESS";
                response.Data = location;
                return this.Content(HttpStatusCode.OK, response);
            }
            catch(Exception error)
            {
                response.Message = error.Message;
                response.Data = null;
                return this.Content(HttpStatusCode.BadRequest, response);
            }
        }

        [HttpGet]
        public IHttpActionResult Get(string itemId,string token, string userName)
        {
            ResponseData response = new ResponseData();
            try
            {
                IEnumerable<Location> location = connection.Get<Location>("LocationItem_GET",
                    new { itemId, token, userName }).ToList();

                response.Message = "SUCCESS";
                response.Data = location;
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
        public IHttpActionResult Get(string status, string itemId, string token, string userName)
        {
            ResponseData response = new ResponseData();
            try
            {
                IEnumerable<Location> location = connection.Get<Location>("LocationItem_GET",
                    new { itemId, status, token, userName }).ToList();

                response.Message = "SUCCESS";
                response.Data = location;
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
        public IHttpActionResult Post([FromBody] LocationData data, string token, string userName)
        {
            ResponseData response = new ResponseData();
            try
            {
                string locationId = data.LocationId;
                string locationCode = data.LocationCode;
                string categoryId = data.CategoryId;
                double maxQty = data.MaxQty;
                Location location = connection.Get<Location>("Location_POST",
                    new { locationId, locationCode, categoryId, maxQty, token, userName }).FirstOrDefault();

                response.Message = "SUCCESS";
                response.Data = location;
                return this.Content(HttpStatusCode.OK, response);
            }
            catch (Exception error)
            {
                response.Message = error.Message;
                response.Data = null;
                return this.Content(HttpStatusCode.BadRequest, response);
            }
        }


        [HttpDelete]
        public IHttpActionResult Delete(string locationId, string token, string userName)
        {
            ResponseData response = new ResponseData();
            try
            {
                connection.Get<Location>("Location_DEL",
                    new { locationId, token, userName });

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