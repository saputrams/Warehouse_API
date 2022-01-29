using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Warehouse_API.Models.ReportOutbound
{
    public class ReportOutbound
    {
        public string OrderNo { get; set; }
        public string OrderDate { get; set; }
        public string Status { get; set; }
        public string TotalItem { get; set; }
        public string TotalQty { get; set; }
        public string ShipmentNo { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string Courier { get; set; }
        public string CourierName { get; set; }
    }
}