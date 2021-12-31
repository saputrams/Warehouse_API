using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Warehouse_API.Models
{
    public class AuthResponse
    {
        public string Message { get; set; }
        public Auth Data { get; set; }
    }
}