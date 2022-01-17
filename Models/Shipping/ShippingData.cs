using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Warehouse_API.Models.Shipping
{
    public class ShippingData
    {
        public string OrderId { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public string ShipmentNo { get; set; }
        public string CourierName { get; set; }
        public string CourierId { get; set; }
    }
}