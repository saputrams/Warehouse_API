using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Warehouse_API.Models.Order
{
    public class OrderDetail
    {
        public string OrderDetailId { get; set; }
        public string ItemId { get; set; }
        public string ItemNo { get; set; }
        public string ItemDesc { get; set; }
        public double Qty { get; set; }
        public double QtyScanning { get; set; }
    }
}