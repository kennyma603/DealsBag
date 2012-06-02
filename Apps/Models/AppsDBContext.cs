using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Apps.Models
{
    public class AppsDBContext : DbContext
    {
        public DbSet<Voucher> Vouchers { get; set; }
    }
}