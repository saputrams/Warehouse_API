using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Warehouse_API.Models.Summary
{
    public class Summary
    {
        public string Received { get; set; }
        public string Putaway { get; set; }
        public string Picking { get; set; }
        public string Packing { get; set; }
        public string Shipping { get; set; }
        public string Closed { get; set; }
        public string Pending { get; set; }
    }
}