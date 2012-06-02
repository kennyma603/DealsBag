using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Apps.Models;
using Apps.ViewModels;
using System.Web.Security;

namespace Apps.Controllers
{
    
    public class VoucherController : Controller
    {
        private AppsDBContext db = new AppsDBContext();
        private VoucherRepository _voucherRepo = new VoucherRepository();

        //
        // GET: /Voucher/

        public ViewResult Index()
        {
            return View(_voucherRepo.ListVouchers());
        }

        //
        // GET: /Voucher/Details/5

        public ViewResult Details(int id)
        {
            Voucher voucher = _voucherRepo.GetVoucher(id);
            return View(voucher);
        }

        //
        // GET: /Voucher/Create
        [Authorize]
        public ActionResult Create()
        {
            MembershipUser CurrentUser = Membership.GetUser(User.Identity.Name);
            //Response.Write("CurrentUser ID :: " + User.Identity.Name+ " " + CurrentUser.ProviderUserKey);
            return View();
        } 

        //
        // POST: /Voucher/Create

        [HttpPost]
        public ActionResult Create(Voucher voucher)
        {
            if (ModelState.IsValid)
            {
                DateTime addedDate = DateTime.Now;
                voucher.AddedDate = addedDate;
                voucher.UserID = (Guid)Membership.GetUser().ProviderUserKey;             
                db.Vouchers.Add(voucher);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(voucher);
        }
        
        //
        // GET: /Voucher/Edit/5
 
        public ActionResult Edit(int id)
        {
            Voucher _voucher = _voucherRepo.GetVoucher(id);
            VoucherEditModel _VoucherEditModel = new VoucherEditModel();

            AutoMapper.Mapper.CreateMap<Voucher, VoucherEditModel>();
            AutoMapper.Mapper.Map(_voucher, _VoucherEditModel);

            return View(_VoucherEditModel);
        }

        //
        // POST: /Voucher/Edit/5

        [HttpPost]
        public ActionResult Edit(VoucherEditModel _VoucherEditModel)
        {
            if (ModelState.IsValid)
            {
                Voucher _VoucherToEdit = _voucherRepo.GetVoucher(_VoucherEditModel.ID);

                AutoMapper.Mapper.CreateMap<VoucherEditModel,Voucher>();
                AutoMapper.Mapper.Map(_VoucherEditModel, _VoucherToEdit);


                db.Entry(_VoucherToEdit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(_VoucherEditModel);
        }

        //
        // GET: /Voucher/Delete/5
 
        public ActionResult Delete(int id)
        {
            Voucher voucher = db.Vouchers.Find(id);
            return View(voucher);
        }

        //
        // POST: /Voucher/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Voucher voucher = db.Vouchers.Find(id);
            db.Vouchers.Remove(voucher);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}