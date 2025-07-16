using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Restaurant_app.Models;

namespace Restaurant_app.Areas.Admin.Controllers
{
    public class ItemCategoryController : Controller

    {
        // GET: Admin/ItemCategory
        private DBRestaurant db = new DBRestaurant();
        public async Task<ActionResult>Index()
        {
         
            var uid = User.Identity.GetUserId();
             var     orginfo = db.OrganizationInfoes.FirstOrDefault(d => d.UserId == uid);
            return View(await db.ItemCategories.Where(d => d.RestId == orginfo.RestId && d.IsDeleted != true).ToListAsync());
        }

        // GET: Admin/ItemCategory/Details/5
        public ActionResult Details(int id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            ItemCategory Itc = db.ItemCategories.FirstOrDefault();
            if(Itc == null) return HttpNotFound();
            return View(Itc);
        }

        // GET: Admin/ItemCategory/Create
        public ActionResult Create()
        {
            OrganizationInfo orginfo = new OrganizationInfo();
            var uid = User.Identity.GetUserId();
            orginfo = db.OrganizationInfoes.FirstOrDefault(d => d.UserId == uid);
            if(orginfo == null) return HttpNotFound();
            var branches = db.Branches.Where(x=> x.RestId == orginfo.RestId && x.IsDeleted != true)
                     .Select(b => new SelectListItem
                     {
                         Value = b.BranchId.ToString(),
                         Text = b.BranchName
                     })
                     .ToList();

            var viewModel = new ItemCategory
            {
                Branches = branches
            };

            return View(viewModel);

        }

        // POST: Admin/ItemCategory/Create
        [HttpPost]
        public ActionResult Create(ItemCategory obj)
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
                    obj.CreatedBy = User.Identity.GetUserId();
                    obj.CreatedAt = DateTime.Now;


                    db.ItemCategories.Add(obj);
                    db.SaveChanges();

                }
                    return RedirectToAction("Index");
                
            }

            catch
            {
                return View();
            }

           
      

        }

        // GET: Admin/ItemCategory/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            ItemCategory Itc = new ItemCategory();
            Itc = db.ItemCategories.Find(id);
            if (Itc == null) return HttpNotFound();
            ViewBag.BranchId = new SelectList(db.Branches.Where(x => x.IsDeleted != true && x.RestId == Itc.RestId), "BranchId", "BranchName", Itc.BranchId);

            return View(Itc);
        }

        // POST: Admin/ItemCategory/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(ItemCategory obj)
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



                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/ItemCategory/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ItemCategory obj = new ItemCategory();
            obj = db.ItemCategories.Find(id);

            if (obj == null || obj.IsDeleted == true)
                return HttpNotFound();

            return View(obj);
        }

        // POST: Admin/ItemCategory/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                ItemCategory obj = new ItemCategory();
                obj = db.ItemCategories.Find(id);
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
