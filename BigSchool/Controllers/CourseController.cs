using BigSchool.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BigSchool.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Create()
        {
            // GET list categoty
            BigSchoolConnect context = new BigSchoolConnect();
            Course objCourse = new Course();
            objCourse.ListCategory = context.Categories.ToList();

            return View(objCourse);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Create(Course objcourse)
        {
            BigSchoolConnect context = new BigSchoolConnect();

            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            objcourse.LecturerId = user.Id;
            context.Courses.Add(objcourse);

            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}