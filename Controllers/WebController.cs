using inln_bootstrap.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace inln_bootstrap.Controllers
{
    public class WebController : Controller
    {
        private ContextDb db = new ContextDb();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Portfolio()
        {
            IEnumerable<ProjectModel> projects = db.Projects.Where(p => p.IsVisible == true).OrderByDescending(p => p.ProjectId).Take(4);
            return View(projects);
        }

        //public ActionResult PortfolioPage(int id)
        //{
        //    IEnumerable<ProjectModel> projects = db.Projects.Where(p => p.IsVisible == true).OrderByDescending(p => p.ProjectId).Skip(id).Take(4);
        //    return Json(
        //        projects.Select(p => new
        //        {
        //            Guid = p.Guid,
        //            MainImage = p.MainImage,
        //            MainImageAlt = p.MainImageAlt,
        //            MainImageTitle = p.MainImageTitle,
        //            Name = p.Name,
        //            IntroText = p.IntroText,
        //            UrlAddress = p.UrlAddress
        //        }), JsonRequestBehavior.AllowGet);
        //}

        public ActionResult Project(Guid id)
        {
            ProjectModel project = db.Projects.FirstOrDefault(p => p.Guid == id);
            return View(project);
        }

        public ActionResult Facebook()
        {
            return View();
        }

        public ActionResult Stages()
        {
            return View();
        }

        public ActionResult Support()
        {
            return View();
        }

        public ActionResult Cms()
        {
            return View();
        }
    }
}
