using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Restaurant_app.Models;

namespace Restaurant_app.Areas.Admin.Controllers
{
    public class MenuItemsController : Controller
    {
        // GET: Admin/MenuItems
        private DBRestaurant db = new DBRestaurant();
        public async Task< ActionResult >Index()
        {
            OrganizationInfo orginfo = new OrganizationInfo();
            var uid = User.Identity.GetUserId();
            orginfo = db.OrganizationInfoes.FirstOrDefault(d => d.UserId == uid);
            return View(await db.MenuItems.Where(d => d.RestId == orginfo.RestId && d.IsDeleted != true).ToListAsync());
        }

        // GET: Admin/MenuItems/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            MenuItem obj = db.MenuItems.Find(id);
            if (obj == null || obj.IsDeleted == true) return HttpNotFound();
            return View(obj);
        }

        // GET: Admin/MenuItems/Create
        public ActionResult Create()
        {
            var uid = User.Identity.GetUserId();

            
            var restId = db.OrganizationInfoes
                           .Where(o => o.UserId == uid)
                           .Select(o => o.RestId)
                           .FirstOrDefault();

           
            var branches = db.Branches
                             .Where(b => b.RestId == restId && b.IsDeleted != true)
                             .Select(b => new SelectListItem
                             {
                                 Value = b.BranchId.ToString(),
                                 Text = b.BranchName
                             }).ToList();

            ViewBag.Branches = branches; 
            ViewBag.Menus = new List<SelectListItem>(); 
            ViewBag.ItemCategories = new List<SelectListItem>();

            return View(new MenuItem());

        }
        public JsonResult GetMenus(int branchId)
        {
            var menus = db.Menus
                          .Where(m => m.BranchId == branchId && m.IsDeleted != true)
                          .Select(m => new
                          {
                              m.MenuId,
                              m.MenuName
                          }).ToList();
            return Json(menus, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetItemCategories(int branchId)
        {
            var categories = db.ItemCategories
                               .Where(c => c.BranchId == branchId && c.IsDeleted != true)
                               .Select(c => new
                               {
                                   c.CategoryId,
                                   c.CategoryName
                               }).ToList();
            return Json(categories, JsonRequestBehavior.AllowGet);
        }
        // POST: Admin/MenuItems/Create
        [HttpPost]
        public ActionResult Create(MenuItem obj, HttpPostedFileBase ProfilePhoto)
        {



            try
            {
                if (ModelState.IsValid)
                {


                    OrganizationInfo orginfo = new OrganizationInfo();
                    var uid = User.Identity.GetUserId();
                    orginfo = db.OrganizationInfoes.FirstOrDefault(d => d.UserId == uid);


                   
                    obj.RestId = orginfo.RestId;
           


                    obj.IsDeleted = false;
                    obj.IsAvailable = true;
                    obj.CreatedBy = User.Identity.GetUserId();
                    obj.CreatedAt = DateTime.Now;
                    db.MenuItems.Add(obj);

                    db.SaveChanges();

                    if (ProfilePhoto != null && ProfilePhoto.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(ProfilePhoto.FileName);
                        var fileExtention = Path.GetExtension(ProfilePhoto.FileName);
                        obj.ItemImage = string.Concat(obj.ItemId + "-" + obj.ItemName).Replace(" ", "-") + fileExtention;
                        var pan = Path.Combine(Server.MapPath("~/Images/Restaurant"), obj.ItemImage);
                        ProfilePhoto.SaveAs(pan);
                        db.Entry(obj).State = EntityState.Modified;
                    }

                }

                    db.SaveChanges();


                    return RedirectToAction("Index");



                
            }


            catch
            {

                return View();
            }


        }

        // GET: Admin/MenuItems/Edit/5
        public ActionResult Edit(int id)
        {

            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            MenuItem obj = new MenuItem();
            obj = db.MenuItems.Find(id);

            if (obj == null || obj.IsDeleted == true)
                return HttpNotFound();
           

            var uid = User.Identity.GetUserId();

            // Fetch RestId based on the logged-in user's ID
            var restId = db.OrganizationInfoes
                           .Where(o => o.UserId == uid)
                           .Select(o => o.RestId)
                           .FirstOrDefault();

            // Fetch branches linked to the RestId
            ViewBag.BranchId = new SelectList(db.Branches.Where(x => x.IsDeleted != true && x.RestId == obj.RestId), "BranchId", "BranchName", obj.BranchId);

            ViewBag.MenuId = new SelectList(db.Menus.Where(x => x.IsDeleted != true && x.RestId == obj.RestId), "MenuId", "MenuName", obj.MenuId);
            ViewBag.CategoryId = new SelectList(db.ItemCategories.Where(x => x.IsDeleted != true && x.RestId == obj.RestId), "CategoryId", "CategoryName", obj.CategoryId);

            return View(obj);
        }

        // POST: Admin/MenuItems/Edit/5
        [HttpPost]
        public async Task< ActionResult> Edit(MenuItem obj, HttpPostedFileBase ProfilePhoto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                  
                    obj.IsAvailable = true;
                    obj.CreatedBy = User.Identity.GetUserId();
                    obj.ModifiedAt = DateTime.Now;

                    db.Entry(obj).State = EntityState.Modified;
                    await db.SaveChangesAsync();


                    if (ProfilePhoto != null && ProfilePhoto.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(ProfilePhoto.FileName);
                        var fileExtention = Path.GetExtension(ProfilePhoto.FileName);
                        obj.ItemImage = string.Concat(obj.ItemId + "-" + obj.ItemName).Replace(" ", "-") + fileExtention;
                        var pan = Path.Combine(Server.MapPath("~/Images/Restaurant"), obj.ItemImage);
                        ProfilePhoto.SaveAs(pan);
                        db.Entry(obj).State = EntityState.Modified;
                    }

                }

                db.SaveChanges();


                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/MenuItems/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            MenuItem obj = new MenuItem();
            obj = db.MenuItems.Find(id);

            if (obj == null || obj.IsDeleted == true)
                return HttpNotFound();

            return View(obj);
        }

        // POST: Admin/MenuItems/Delete/5
        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Branch obj = new Branch();
                obj = db.Branches.Find(id);
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
