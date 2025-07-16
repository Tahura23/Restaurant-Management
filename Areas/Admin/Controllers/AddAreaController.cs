using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Restaurant_app.Models;

namespace Restaurant_app.Areas.Admin.Controllers
{
    public class AddAreaController : Controller
    {
        // GET: Admin/AddArea
        private DBRestaurant db = new DBRestaurant();
        public async Task<ActionResult> Index()
        {
           
            var uid = User.Identity.GetUserId();
            var orginfo = db.OrganizationInfoes.FirstOrDefault(d => d.UserId == uid);
            return View(await db.Areas.Where(d => d.RestId == orginfo.RestId && d.IsDeleted != true).ToListAsync());
        }

        // GET: Admin/AddArea/Details/5
        public ActionResult Details(int id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Area obj = db.Areas.Find(id);
            if (obj == null || obj.IsDeleted == true) return HttpNotFound();
            return View(obj);
        }

        // GET: Admin/AddArea/Create
        public ActionResult Create()
        {
           
            var uid = User.Identity.GetUserId();
            var orginfo = db.OrganizationInfoes.FirstOrDefault(d => d.UserId == uid);
            var branches = db.Branches.Where(x => x.RestId == orginfo.RestId &&  x.IsDeleted != true)
                     .Select(b => new SelectListItem
                     {
                         Value = b.BranchId.ToString(),
                         Text = b.BranchName
                     })
                     .ToList();

            var viewModel = new Area
            {
                Branches = branches,
                RestId= orginfo.RestId
            };

            return View(viewModel);
        }

        // POST: Admin/AddArea/Create
        [HttpPost]
        public ActionResult Create(Area obj)
        {
            try
            {
                OrganizationInfo orginfo = new OrganizationInfo();
                var uid = User.Identity.GetUserId();
                orginfo = db.OrganizationInfoes.FirstOrDefault(d => d.UserId == uid);

                obj.RestId = orginfo.RestId;

                obj.IsDeleted = false;
                obj.CreatedBy = uid;
                obj.CreatedAt = DateTime.Now;


                db.Areas.Add(obj);
                db.SaveChanges();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/AddArea/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Area obj = new Area();
            obj = db.Areas.Find(id);

            if (obj == null || obj.IsDeleted == true)
                return HttpNotFound();
            ViewBag.BranchId = new SelectList(db.Branches.Where(x => x.IsDeleted != true && x.RestId == obj.RestId), "BranchId", "BranchName", obj.BranchId);
            return View(obj);
        }

        // POST: Admin/AddArea/Edit/5
        [HttpPost]
        public async Task<ActionResult>Edit(Area obj)
        {
            try
            {

             
            
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

        // GET: Admin/AddArea/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/AddArea/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
