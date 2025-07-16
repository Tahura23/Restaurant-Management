using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Restaurant_app.Models;

namespace Restaurant_app.Areas.Admin.Controllers
{
    [Authorize]
    public class AddBranchController : Controller
    {
        // GET: Admin/AddBranch
        private DBRestaurant db = new DBRestaurant();
        public async Task< ActionResult> Index()
        {
            OrganizationInfo orginfo = new OrganizationInfo();
            var uid = User.Identity.GetUserId();
            orginfo = db.OrganizationInfoes.FirstOrDefault(d => d.UserId == uid);
            return View(await db.Branches.Where(d =>d.RestId == orginfo.RestId  && d.IsDeleted !=true).ToListAsync());
        }

        // GET: Admin/AddBranch/Details/5
        public ActionResult Details(int id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Branch obj = db.Branches.Find(id);
            if (obj == null || obj.IsDeleted == true) return HttpNotFound();
            return View(obj);
        }

        // GET: Admin/AddBranch/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AddBranch/Create
        [HttpPost]
        public ActionResult Create(Branch obj, HttpPostedFileBase ProfilePhoto)
        {
            try
            {

                OrganizationInfo orginfo = new OrganizationInfo();
                var uid = User.Identity.GetUserId();
                orginfo = db.OrganizationInfoes.FirstOrDefault(d => d.UserId == uid);

                obj.RestId = orginfo.RestId;
                

                obj.IsDeleted = false;
                obj.CreatedBy = User.Identity.GetUserId();
                obj.CreatedAt = DateTime.Now;
                db.Branches.Add(obj);
             
                db.SaveChanges();

                if (ProfilePhoto != null && ProfilePhoto.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(ProfilePhoto.FileName);
                    var fileExtention = Path.GetExtension(ProfilePhoto.FileName);
                    obj.CoverImage = string.Concat(obj.RestId + "-" + obj.BranchName).Replace(" ", "-") + fileExtention;
                    var pan = Path.Combine(Server.MapPath("~/Images/Restaurant"), obj.CoverImage);
                    ProfilePhoto.SaveAs(pan);
                    db.Entry(obj).State = EntityState.Modified;
                }

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/AddBranch/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Branch obj = new Branch();
            obj = db.Branches.Find(id);

            if (obj == null || obj.IsDeleted == true)
                return HttpNotFound();

            return View(obj);

        }

        // POST: Admin/AddBranch/Edit/5
        [HttpPost]
        public async Task<ActionResult>Edit(Branch obj, HttpPostedFileBase ProfilePhoto)
        {

          
            try
            {

                OrganizationInfo orginfo = new OrganizationInfo();
                var uid = User.Identity.GetUserId();
                orginfo = db.OrganizationInfoes.FirstOrDefault(d => d.UserId == uid);

                obj.RestId = orginfo.RestId;

                obj.IsDeleted = false;
                obj.CreatedBy = User.Identity.GetUserId();
                obj.ModifiedAt = DateTime.Now;

                db.Entry(obj).State = EntityState.Modified;
                await db.SaveChangesAsync();
      

                

                if (ProfilePhoto != null && ProfilePhoto.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(ProfilePhoto.FileName);
                    var fileExtention = Path.GetExtension(ProfilePhoto.FileName);
                    obj.CoverImage = string.Concat(obj.RestId + "-" + obj.BranchName).Replace(" ", "-") + fileExtention;
                    var pan = Path.Combine(Server.MapPath("~/Images/Restaurant"), obj.CoverImage);
                    ProfilePhoto.SaveAs(pan);
                    db.Entry(obj).State = EntityState.Modified;
                }

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/AddBranch/Delete/5
        public  async Task<ActionResult>Delete(int id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

           Branch obj = await db.Branches.FindAsync(id); 
            if (obj == null)
                return HttpNotFound();
            return View(obj);
        }

        // POST: Admin/AddBranch/Delete/5
        [HttpPost]
        public  async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                Branch obj = await db.Branches.FindAsync(id);
                obj.IsDeleted = true;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
