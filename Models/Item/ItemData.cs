using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Warehouse_API.Models.Item
{
    public class ItemData
    {
        public string ItemId { get; set; }
        public string ItemNo { get; set; }
        public string Style { get; set; }
        public string Size { get; set; }
        public string Desc { get; set; }
        public double Qty { get; set; }
        public double Price { get; set; }
        public string CategoryId { get; set; }
    }
}