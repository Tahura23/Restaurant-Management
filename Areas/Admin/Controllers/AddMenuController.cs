using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Restaurant_app.Models;

namespace Restaurant_app.Areas.Admin.Controllers
{
    public class AddMenuController : Controller
    {
        // GET: Admin/AddMenu
        private DBRestaurant db = new DBRestaurant();
        public async Task<ActionResult> Index()
        {
            OrganizationInfo orginfo = new OrganizationInfo();
            var uid = User.Identity.GetUserId();
            orginfo = db.OrganizationInfoes.FirstOrDefault(d => d.UserId == uid);
            return View(await db.Menus.Where(d => d.RestId == orginfo.RestId && d.IsDeleted != true).ToListAsync());
        }

        // GET: Admin/AddMenu/Details/5
        public ActionResult Details(int id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Models.Menu obj = db.Menus.Find(id);
            if (obj == null || obj.IsDeleted == true) return HttpNotFound();
            return View(obj);

        }

        // GET: Admin/AddMenu/Create
        public ActionResult Create()
        {

            OrganizationInfo orginfo = new OrganizationInfo();
            var uid = User.Identity.GetUserId();
            orginfo = db.OrganizationInfoes.FirstOrDefault(d => d.UserId == uid);
            var branches = db.Branches.Where(x=>x.RestId == orginfo.RestId && x.IsDeleted !=true)
                     .Select(b => new SelectListItem
                     {
                         Value = b.BranchId.ToString(),
                         Text = b.BranchName
                     })
                     .ToList();

            var viewModel = new Models.Menu
            {
                Branches = branches
            };

            return View(viewModel);
        }

        // POST: Admin/AddMenu/Create
        [HttpPost]
        public ActionResult Create(Models.Menu obj)
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
                    

                    db.Menus.Add(obj);
                    db.SaveChanges();
                

                    return RedirectToAction("Index");
            }
            catch

            {
                return View();
            }
        }

        // GET: Admin/AddMenu/Edit/5
        public ActionResult Edit(int id)
        {
       
            if(id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Models.Menu menu = new Models.Menu();
            menu = db.Menus.Find(id);
            if (menu == null) return HttpNotFound();

            ViewBag.BranchId = new SelectList(db.Branches.Where(x => x.IsDeleted != true && x.RestId == menu.RestId), "BranchId", "BranchName", menu.BranchId);

            return View(menu);

        }

        // POST: Admin/AddMenu/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Models.Menu obj)
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

        // GET: Admin/AddMenu/Delete/5
        public ActionResult Delete(int id)
        {
            if(id == null) return new HttpStatusCodeResult (HttpStatusCode.BadRequest);

            Models.Menu menu = db.Menus.Find(id); if (menu == null)
                return HttpNotFound();
            return View(menu);
        }

        // POST: Admin/AddMenu/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Models.Menu obj = db.Menus.Find(id);
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
