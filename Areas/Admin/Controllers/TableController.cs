using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    public class TableController : Controller
    {
        // GET: Admin/Table
        private DBRestaurant db = new DBRestaurant();
        public async Task<ActionResult>Index()
        {
            OrganizationInfo orginfo = new OrganizationInfo();
            var uid = User.Identity.GetUserId();
            orginfo = db.OrganizationInfoes.FirstOrDefault(d => d.UserId == uid);
            return View(await db.TableAreas.Where(d => d.RestId == orginfo.RestId && d.IsDeleted != true).ToListAsync());
        }

        // GET: Admin/Table/Details/5
        public ActionResult Details(int id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Area obj = db.Areas.Find(id);
            if (obj == null || obj.IsDeleted == true) return HttpNotFound();
            return View(obj);
        }


        // GET: Admin/Table/Create
        public ActionResult Create()
        {
            OrganizationInfo orginfo = new OrganizationInfo();
            var uid = User.Identity.GetUserId();
            orginfo = db.OrganizationInfoes.FirstOrDefault(d => d.UserId == uid);
            TableArea obj = new TableArea();

            ViewBag.AreaId = new SelectList(db.Areas.Where(x => x.IsDeleted != true && x.RestId == orginfo.RestId), "AreaId", "AreaName", obj.AreaId);
            ViewBag.BranchId = new SelectList(db.Branches.Where(x => x.IsDeleted != true && x.RestId == orginfo.RestId), "BranchId", "BranchName", obj.BranchId);
            return View(obj);
        }


        // POST: Admin/Table/Create
        [HttpPost]
        public  ActionResult Create(TableArea obj)
        {
            try
            {

                OrganizationInfo orginfo = new OrganizationInfo();
                var uid = User.Identity.GetUserId();
                orginfo =  db.OrganizationInfoes.FirstOrDefault(d => d.UserId == uid);

                obj.RestId = orginfo.RestId;

                obj.IsDeleted = false;
                obj.CreatedBy = uid;
                obj.CreatedAt = DateTime.Now;


                db.TableAreas.Add(obj);
                db.SaveChanges();


                return RedirectToAction("Index");

               
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Table/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            TableArea obj = new TableArea();
            obj = db.TableAreas.Find(id);

            if (obj == null || obj.IsDeleted == true)
                return HttpNotFound();
          
            ViewBag.AreaId = new SelectList(db.Areas.Where(x => x.IsDeleted != true && x.RestId == obj.RestId), "AreaId", "AreaName", obj.AreaId);

            ViewBag.BranchId = new SelectList(db.Branches.Where(x => x.IsDeleted != true && x.RestId == obj.RestId), "BranchId", "BranchName", obj.BranchId);
            return View(obj);
        }

        // POST: Admin/Table/Edit/5
        [HttpPost]
        public async Task< ActionResult> Edit(TableArea obj)
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

        // GET: Admin/Table/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Table/Delete/5
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
