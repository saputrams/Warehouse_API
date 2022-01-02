using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Warehouse_API.Models.Users
{
    public class UsersData
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RoleId { get; set; }
        public bool IsActive { get; set; }
    }
}