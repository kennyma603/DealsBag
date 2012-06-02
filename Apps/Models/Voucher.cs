using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Apps.Models
{
    public class Voucher
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string SiteName { get; set; }
        public string DealURL { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string VoucherFileURL { get; set; }
        public Guid UserID { get; set; }

        public bool isVoucherCreater(){
            //MembershipUser usr = Membership.GetUser();
            //if (usr == null) return false;

            //Guid id=(Guid)usr.ProviderUserKey;
            Guid id = UserHelper.GetCachedUserID();

            if (UserID == id)
                return true;
            return false;
        }
    }
}