using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Warehouse_API.Models.ItemExpired
{
    public class ItemExpired
    {
        public string ItemExpiredId { get; set; }
        public string ItemId { get; set; }
        public string ItemNo { get; set; }
        public string LocationName { get; set; }
        public double Qty { get; set; }
        public DateTime ExpiredDate { get; set; }
    }
}