﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Warehouse_API.Models.Inbound
{
    public class InboundFetch
    {
        public string OrderId { get; set; }
        public string OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public string OrderType { get; set; }
        public string OrderDetailId { get; set; }
        public string ItemNo { get; set; }
        public double Qty { get; set; }
        public double QtyScanning { get; set; }
    }
}