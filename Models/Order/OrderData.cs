using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Warehouse_API.Models.Order
{
    public class OrderData
    {
        public string OrderId { get; set; }
        public string ItemId { get; set; }
        public string Status { get; set; }
        public string LocationId { get; set; }
    }
}