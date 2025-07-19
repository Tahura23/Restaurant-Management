using System;

using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Restaurant_app.Models;

namespace Restaurant_app.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        // GET: Admin/Order
        private DBRestaurant db = new DBRestaurant();
        public async Task<ActionResult> Index()
        {

            OrganizationInfo orginfo = new OrganizationInfo();
            var uid = User.Identity.GetUserId();
            orginfo = db.OrganizationInfoes.FirstOrDefault(d => d.UserId == uid);
            return View(await db.MenuItems.Where(d => d.RestId == orginfo.RestId && d.IsDeleted != true).ToListAsync());
        }

        // GET: Admin/Order/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Order/Create
        [HttpPost]
        public ActionResult Create(OrderDetail obj)
        {
            try
            {
                OrganizationInfo orginfo = new OrganizationInfo();
                var uid = User.Identity.GetUserId();

                 //get organusation info 
                orginfo = db.OrganizationInfoes.FirstOrDefault(d => d.UserId == uid);



                obj.RestId = orginfo.RestId;



                obj.IsDeleted = false;

                //obj.CreatedBy = uid;
                obj.CreatedAt = DateTime.Now;
                db.OrderDetails.Add(obj);

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Order/Edit/5
        public ActionResult Edit(int id)


        {
            return View();
        }

        // POST: Admin/Order/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Order/Delete/5
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
