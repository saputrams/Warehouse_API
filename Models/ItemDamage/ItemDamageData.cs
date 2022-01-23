using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Warehouse_API.Models.ItemDamage
{
    public class ItemDamageData
    {
        public string ItemId { get; set; }
        public double Qty { get; set; }
        public string Note { get; set; }
        public string LocationId { get; set; }
    }
}