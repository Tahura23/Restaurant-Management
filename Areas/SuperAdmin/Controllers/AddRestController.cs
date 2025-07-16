using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Restaurant_app.Models;
using Restaurant_app.Helper;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;


namespace Restaurant_app.Areas.SuperAdmin.Controllers
{
    public class AddRestController : Controller
    {
        // GET: SuperAdmin/AddRest

        private DBRestaurant db = new DBRestaurant();

        private ApplicationUserManager _userManager;

        public AddRestController() { }

        public AddRestController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { _userManager = value; }
        }

        public async Task<ActionResult> Index()
        {
            return View( await db.OrganizationInfoes.Where(d => d.IsDeleted != true).ToListAsync());
        }

        // GET: SuperAdmin/AddRest/Details/5
        public ActionResult Details(int id)
        {

            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            OrganizationInfo organization =  db.OrganizationInfoes.Find(id);
            if (organization == null || organization.IsDeleted == true) return HttpNotFound();
            return View(organization);
          
        }

        // GET: SuperAdmin/AddRest/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuperAdmin/AddRest/Create
        [HttpPost]
        public async Task <ActionResult>Create(OrganizationInfo organization, HttpPostedFileBase ProfilePhoto)
        {
            try
            {
                if (ModelState.IsValid)
                {


                    organization.IsDeleted = false;
                    organization.CreatedBy = User.Identity.GetUserId();
                    organization.CreatedAt = DateTime.Now;


                    #region Create User And Add Role
                    bool flag = false;
                    var user = new ApplicationUser { UserName = organization.Email, Email = organization.Email,  EmailConfirmed = true, PhoneNumberConfirmed = true };
                    var result = await UserManager.CreateAsync(user, organization.Password);
                    if (result.Succeeded)
                    {
                     
                        var r = await UserManager.AddToRoleAsync(user.Id,"Admin");
                        flag = r.Succeeded;
                    }

                    if (!flag)
                    {
                     
                        foreach (var item in result.Errors)
                            ModelState.AddModelError("", item);
                     
                        return View(organization);
                    }
                    #endregion
                    organization.UserId=user.Id;
                    db.OrganizationInfoes.Add(organization);
                    db.SaveChanges();

                    if (ProfilePhoto != null && ProfilePhoto.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(ProfilePhoto.FileName);
                        var fileExtention = Path.GetExtension(ProfilePhoto.FileName);
                        organization.CoverImage = string.Concat(organization.RestId + "-" + organization.Name).Replace(" ", "-") + fileExtention;
                        var pan = Path.Combine(Server.MapPath("~/Images/Restaurant"), organization.CoverImage);
                        ProfilePhoto.SaveAs(pan);
                        db.Entry(organization).State = EntityState.Modified;
                    }

                    db.SaveChanges();


                    return RedirectToAction("Index");
                }

                  return View(organization);
                
            }
            catch
            {
                return View();
            }
        
        
        }

        // GET: SuperAdmin/AddRest/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            OrganizationInfo organization = new OrganizationInfo();
            organization = db.OrganizationInfoes.Find(id);

            if (organization == null || organization.IsDeleted == true)
                return HttpNotFound();

            return View(organization);
      
        }


        // POST: SuperAdmin/AddRest/Edit/5
        [HttpPost]
        public ActionResult Edit(OrganizationInfo organization, HttpPostedFileBase ProfilePhoto)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {


                    organization.IsDeleted = false;
                    //organization.CreatedBy = User.Identity.GetUserId();
                    organization.ModifiedAt = DateTime.Now;
                  
                    db.OrganizationInfoes.AddOrUpdate(organization);
                    db.SaveChanges();

                    if (ProfilePhoto != null && ProfilePhoto.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(ProfilePhoto.FileName);
                        var fileExtention = Path.GetExtension(ProfilePhoto.FileName);
                        organization.CoverImage = string.Concat(organization.RestId + "-" + organization.Name).Replace(" ", "-") + fileExtention;
                        var pan = Path.Combine(Server.MapPath("~/Images/Restaurant"), organization.CoverImage);
                        ProfilePhoto.SaveAs(pan);
                        db.Entry(organization).State = EntityState.Modified;
                    }

                    db.SaveChanges();


                    return RedirectToAction("Index");
                }

                return View(organization);

              
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperAdmin/AddRest/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            OrganizationInfo organization = new OrganizationInfo();
            organization = db.OrganizationInfoes.Find(id);

            if (organization == null || organization.IsDeleted == true)
                return HttpNotFound();

            return View(organization);
        }

        // POST: SuperAdmin/AddRest/Delete/5
        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                // TODO: Add delete logic here
                OrganizationInfo organization = new OrganizationInfo();
                organization = db.OrganizationInfoes.Find(id);
                organization.IsDeleted = true;
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
