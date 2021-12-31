using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Warehouse_API.Models
{
    public class Auth
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}