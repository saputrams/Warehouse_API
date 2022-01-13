using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Warehouse_API.Models.Inbound
{
    public class InboundDetail
    {
        public string OrderDetailId { get; set; }
        public string ItemNo { get; set; }
        public double Qty { get; set; }
        public double QtyScanning { get; set; }
    }
}