using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Warehouse_API.Models.Scan
{
    public class Scan
    {
        public string ScanId { get; set; }
        public DateTime ScanDate { get; set; }
        public string UserName { get; set; }
        public string ItemName { get; set; }
        public string Status { get; set; }
    }
}