using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apps.Models
{
    public class VoucherRepository
    {
        private AppsDBContext _appsDB = new AppsDBContext();

        public IEnumerable<Voucher> ListVouchers()
        {
            return _appsDB.Vouchers.ToList();
        }

        public Voucher GetVoucher(int id)
        { 
            return (from v in _appsDB.Vouchers
                    where v.ID == id
                    select v).FirstOrDefault();
        }
    }
}