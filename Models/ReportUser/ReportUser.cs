using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Warehouse_API.Models.ReportUser
{
    public class ReportUser
    {
        public string UserName { get; set; }
        public string RoleName { get; set; }
        public string LastLoginDate { get; set; }
        public string Active { get; set; }
        public string Received { get; set; }
        public string Putaway { get; set; }
        public string Picking { get; set; }
        public string Packing { get; set; }
        public string Shipping { get; set; }
        public string Inbound { get; set; }
        public string Outbound { get; set; }
    }
}