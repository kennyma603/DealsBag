using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apps.ViewModels
{
    public class VoucherViewModels
    {
    }

    public class VoucherEditModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string SiteName { get; set; }
        public string DealURL { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string VoucherFileURL { get; set; }
    }
}