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
    public class ReservationController : Controller
    {
        // GET: Admin/Reservation
        private DBRestaurant db = new DBRestaurant();
        public async Task<ActionResult> Index()
        
        {
           
            var uid = User.Identity.GetUserId();
            var orginfo = db.OrganizationInfoes.FirstOrDefault(d => d.UserId == uid);
            return View(await db.Reservations.Where(d => d.RestId == orginfo.RestId && d.IsDeleted != true).ToListAsync());
        }

        // GET: Admin/Reservation/Details/5
        public ActionResult Details(int id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Reservation obj = db.Reservations.Find(id);
            if (obj == null || obj.IsDeleted == true) return HttpNotFound();
            return View(obj);
        }

        // GET: Admin/Reservation/Create
        public ActionResult Create()
        {

           
            var uid = User.Identity.GetUserId();
            var orginfo = db.OrganizationInfoes.FirstOrDefault(d => d.UserId == uid);
            Reservation obj = new Reservation();

            ViewBag.MealId= new SelectList(db.Meal.Where(x => x.IsDeleted != true),"MealId","Name",obj.MealId);
            ViewBag.GuestId = new SelectList(db.Guest.Where(x => x.IsDeleted != true), "GuestId", "GuestNumber", obj.GuestId);

            ViewBag.BranchId = new SelectList(db.Branches.Where(x => x.IsDeleted != true && x.RestId == orginfo.RestId), "BranchId", "BranchName", obj.BranchId);
            ViewBag.TimeSlotId = new SelectList(db.TimeSlots.Where(x => x.IsDeleted != true), "TimeSlotId", "Timing", obj.TimeSlotId);
            
            return View(obj);
        }

        // POST: Admin/Reservation/Create
        [HttpPost]
        public ActionResult Create(Reservation obj)
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


                    db.Reservations.Add(obj);
                    db.SaveChanges();
                }

                    return RedirectToAction("Index");
                

            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Reservation/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Reservation obj = new Reservation();
            obj = db.Reservations.Find(id);

            if (obj == null || obj.IsDeleted == true)
                return HttpNotFound();

          

            ViewBag.MealId = new SelectList(db.Meal.Where(x => x.IsDeleted != true), "MealId", "Name", obj.MealId);
            ViewBag.GuestId = new SelectList(db.Guest.Where(x => x.IsDeleted != true), "GuestId", "GuestNumber", obj.GuestId);

            ViewBag.BranchId = new SelectList(db.Branches.Where(x => x.IsDeleted != true && x.RestId == obj.RestId), "BranchId", "BranchName", obj.BranchId);
            ViewBag.TimeSlotId = new SelectList(db.TimeSlots.Where(x => x.IsDeleted != true), "TimeSlotId", "Timing", obj.TimeSlotId);


            return View(obj);
        }

        // POST: Admin/Reservation/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Reservation obj)
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

        // GET: Admin/Reservation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Reservation/Delete/5
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
