using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Warehouse_API.Helper;
using Warehouse_API.Models;
using Warehouse_API.Models.Users;

namespace Warehouse_API.Controllers
{
    [System.Web.Mvc.ValidateAntiForgeryToken]
    public class UsersController : ApiController
    {
        Connection connection;

        UsersController()
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
                string filter = "";
                string search = "";
                IEnumerable<Users> user = connection.Get<Users>("User_GET", new { pk, filter, search,  token, userName }).ToList();


                response.Message = "SUCCESS";
                response.Data = user;
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
        public IHttpActionResult Get(string id, string token, string userName)
        {
            ResponseData response = new ResponseData();
            try
            {
                string pk = id;
                string filter = "";
                string search = "";
                Users user = connection.Get<Users>("User_GET", new { pk, filter, search, token, userName }).FirstOrDefault();


                response.Message = "SUCCESS";
                response.Data = user;
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
        public IHttpActionResult Get(string id, string userFilter, string userSearch, string token, string userName)
        {
            ResponseData response = new ResponseData();
            try
            {
                string pk = id;
                string filter = userFilter;
                string search = userSearch;
                IEnumerable<Users> user = connection.Get<Users>("User_GET", new { pk, filter, search, token, userName }).ToList();


                response.Message = "SUCCESS";
                response.Data = user;
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
        public IHttpActionResult Post([FromBody] UsersData data, string token, string userName)
        {
            ResponseData response = new ResponseData();
            try
            {
                string userId = data.UserId;
                string userNameNew = data.UserName;
                string userPassword = data.Password;
                string roleId = data.RoleId;
                int isActive = data.IsActive? 1 : 0;
                Users user = connection.Get<Users>("User_POST",
                    new { userId, userNameNew, userPassword, roleId, isActive, token, userName }).FirstOrDefault();


                response.Message = "SUCCESS";
                response.Data = user;
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
        public IHttpActionResult Delete(string userId, string token, string userName)
        {
            ResponseData response = new ResponseData();
            try
            {
                connection.Get<Users>("User_DEL", new { userId, token, userName });

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