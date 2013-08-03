using inln_bootstrap.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace inln_bootstrap.Controllers
{
    public class HomeController : Controller
    {
        private ContextDb db = new ContextDb();

        public ActionResult Index()
        {
            MainPageModel model = new MainPageModel();
            model.Clients = db.Clients.Where(c => c.IsVisible == true && c.IsSpecial == true && c.Logo != "").OrderByDescending(c => c.ClientId);
            model.Projects = db.Projects.Where(p => p.IsVisible == true && p.IsSpecial == true).OrderByDescending(p => p.ProjectId);
            return View(model);
        }

    }
}
