using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Warehouse_API.Models.ReportInbound
{
    public class ReportInbound
    {

        public string OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public string TotalItem { get; set; }
        public string TotalQty { get; set; }
    }
}