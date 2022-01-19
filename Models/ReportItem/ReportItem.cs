using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Warehouse_API.Models.ReportItem
{
    public class ReportItem
    {
        public string ItemNo { get; set; }
        public string Style { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
        public string Qty { get; set; }
        public string Price { get; set; }
        public string CategoryName { get; set; }
    }
}