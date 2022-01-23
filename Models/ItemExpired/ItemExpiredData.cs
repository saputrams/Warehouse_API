using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Warehouse_API.Models.ItemExpired
{
    public class ItemExpiredData
    {
        public string ItemId { get; set; }
        public double Qty { get; set; }
        public DateTime ExpiredDate { get; set; }
        public string LocationId { get; set; }
    }
}