using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Warehouse_API.Models.Location
{
    public class LocationData
    {
        public string LocationId { get; set; }
        public string LocationCode { get; set; }
        public string CategoryId { get; set; }
        public double MaxQty { get; set; }
    }
}