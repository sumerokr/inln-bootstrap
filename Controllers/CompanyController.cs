using inln_bootstrap.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace inln_bootstrap.Controllers
{
    public class CompanyController : Controller
    {
        private ContextDb db = new ContextDb();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contacts()
        {
            return View();
        }

        public ActionResult Garanty()
        {
            return View();
        }

        [ActionName("Response")]
        public ActionResult Responce()
        {
            IEnumerable<ProjectModel> projects = db.Projects.Where(p => p.IsVisible == true && p.ResponseImage != null).OrderByDescending(p => p.ProjectId);
            return View(projects);
        }

        public ActionResult Customers()
        {
            IEnumerable<ClientModel> clients = db.Clients.Where(c => c.IsVisible == true).OrderByDescending(c => c.ClientId);
            return View(clients);
        }
    }
}
