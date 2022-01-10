using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Warehouse_API.Helper;
using Warehouse_API.Models;
using Warehouse_API.Models.Category;

namespace Warehouse_API.Controllers
{
    [System.Web.Mvc.ValidateAntiForgeryToken]
    public class CategoryController : ApiController
    {
        Connection connection;

        CategoryController()
        {
            connection = new Connection();
        }

        [HttpGet]
        public IHttpActionResult Get(string token, string userName)
        {
            ResponseData response = new ResponseData();
            try
            {
                string categoryId = "";
                IEnumerable<Category> category = connection.Get<Category>("Category_GET", 
                    new { categoryId, token, userName }).ToList();


                response.Message = "SUCCESS";
                response.Data = category;
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
                string categoryId = id;
                Category category = connection.Get<Category>("Category_GET",
                    new { categoryId, token, userName }).FirstOrDefault();


                response.Message = "SUCCESS";
                response.Data = category;
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
