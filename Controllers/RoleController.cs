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
    public class RoleController : ApiController
    {
        Connection connection;

        RoleController()
        {
            connection = new Connection();
        }

        [HttpGet]
        public IEnumerable<Role> Get()
        {
            string PK = "";
            IEnumerable<Role> role = connection.Get<Role>("Role_GET",new { PK });
            return role;
        }

        [HttpGet]
        public IEnumerable<Role> Get(string ID)
        {
            string PK = ID;
            IEnumerable<Role> role = connection.Get<Role>("Role_GET", new { PK });
            return role;
        }

        // POST: api/Role
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Role/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Role/5
        public void Delete(int id)
        {
        }
    }
}
