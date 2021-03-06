using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Warehouse_API.Helper;
using Warehouse_API.Models;

namespace Warehouse_API.Controllers
{
    [System.Web.Mvc.ValidateAntiForgeryToken]
    public class RoleController : ApiController
    {
        Connection connection;

        RoleController()
        {
            connection = new Connection();
        }

        [HttpGet]
        public IHttpActionResult Get(string token, string userName)
        {
            ResponseData response = new ResponseData();
            try
            {
                string pk = "";
                IEnumerable<Role> role = connection.Get<Role>("Role_GET", new { pk, token, userName }).ToList();


                response.Message = "SUCCESS";
                response.Data = role;
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
        public IHttpActionResult Get(string id, string token, string userName)
        {
            ResponseData response = new ResponseData();
            try
            {
                string pk = id;
                IEnumerable<Role> role = connection.Get<Role>("Role_GET", new { pk, token, userName }).ToList();


                response.Message = "SUCCESS";
                response.Data = role;
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
