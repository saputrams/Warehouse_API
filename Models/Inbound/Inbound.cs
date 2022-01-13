using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Warehouse_API.Models.Inbound
{
    public class Inbound
    {
        public string OrderId { get; set; }
        public string OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public string OrderType { get; set; }
        public List<InboundDetail> OrderDetail { get; set; }
    }
}