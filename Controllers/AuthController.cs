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
    public class AuthController : ApiController
    {

        Connection connection;

        AuthController()
        {
            connection = new Connection();
        }
        // GET api/<controller>

        [HttpPost]
        public IHttpActionResult Post([FromBody] AuthData data)
        {
            AuthResponse response = new AuthResponse();
            try
            {
                string UserName = data.UserName;
                string Password = data.Password;
                Auth authObj = connection.Get<Auth>("Login_POST", new { UserName, Password }).FirstOrDefault();


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