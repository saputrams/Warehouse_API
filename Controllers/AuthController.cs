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
    public class AuthController : ApiController
    {

        Connection connection;

        AuthController()
        {
            connection = new Connection();
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] AuthData data)
        {
            ResponseData response = new ResponseData();
            try
            {
                string userName = data.UserName;
                string password = data.Password;
                Auth authObj = connection.Get<Auth>("Login_POST", new { userName, password }).FirstOrDefault();


                response.Message = "SUCCESS";
                response.Data = authObj;

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