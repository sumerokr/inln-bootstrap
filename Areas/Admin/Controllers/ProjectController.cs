using inln_bootstrap.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace inln_bootstrap.Areas.Admin.Controllers
{
    public class ProjectController : Controller
    {
        private ContextDb db = new ContextDb();

        public ActionResult Index()
        {
            IEnumerable<ProjectModel> projects = db.Projects.OrderByDescending(p => p.ProjectId);

            return View(projects);
        }

        public ActionResult Create(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(int id, ProjectModel project, HttpPostedFileBase logoFile, HttpPostedFileBase mainFile, HttpPostedFileBase sliderFile, HttpPostedFileBase responseFile)
        {
            project.ClientId = id;
            project.EntryCreated = DateTime.Now;
            project.Guid = Guid.NewGuid();
            project.Logo = Utils.FileManager.UploadFile(logoFile, "Projects", project.Guid, "logo");
            project.MainImage = Utils.FileManager.UploadFile(mainFile, "Projects", project.Guid, "main");
            project.SliderImage = Utils.FileManager.UploadFile(sliderFile, "Projects", project.Guid, "slider");
            project.ResponseImage = Utils.FileManager.UploadFile(responseFile, "Projects", project.Guid, "response");
            db.Entry(project).State = EntityState.Added;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ProjectModel project = db.Projects.Find(id);
            return View(project);
        }

        [HttpPost]
        public ActionResult Edit(ProjectModel project, HttpPostedFileBase logoFile, HttpPostedFileBase mainFile, HttpPostedFileBase sliderFile, HttpPostedFileBase responseFile)
        {
            ProjectModel dbProject = db.Projects.Find(project.ProjectId);
            project.EntryCreated = dbProject.EntryCreated;
            project.Guid = dbProject.Guid;
            project.ClientId = dbProject.ClientId;

            if (project.LogoToDelete == false)
            {
                project.Logo = Utils.FileManager.UpdateFile(dbProject.Logo, logoFile, "Projects", dbProject.Guid, "logo");
            }
            else
            {
                project.Logo = Utils.FileManager.DeleteFile(dbProject.Logo);
                project.LogoToDelete = false;
            }

            if (project.MainImageToDelete == false)
            {
                project.MainImage = Utils.FileManager.UpdateFile(dbProject.MainImage, mainFile, "Projects", dbProject.Guid, "main");
            }
            else
            {
                project.MainImage = Utils.FileManager.DeleteFile(dbProject.MainImage);
                project.MainImageToDelete = false;
            }

            if (project.SliderImageToDelete == false)
            {
                project.SliderImage = Utils.FileManager.UpdateFile(dbProject.SliderImage, sliderFile, "Projects", dbProject.Guid, "slider");
            }
            else
            {
                project.SliderImage = Utils.FileManager.DeleteFile(dbProject.SliderImage);
                project.SliderImageToDelete = false;
            }

            if (project.ResponseImageToDelete == false)
            {
                project.ResponseImage = Utils.FileManager.UpdateFile(dbProject.ResponseImage, responseFile, "Projects", dbProject.Guid, "response");
            }
            else
            {
                project.ResponseImage = Utils.FileManager.DeleteFile(dbProject.ResponseImage);
                project.ResponseImageToDelete = false;
            }

            db.Entry(dbProject).State = EntityState.Detached;
            db.Entry(project).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            ProjectModel project = db.Projects.Find(id);
            return View(project);
        }

        public ActionResult Delete(int id)
        {
            ProjectModel project = db.Projects.Find(id);
            return View(project);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            ProjectModel project = db.Projects.Find(id);
            Utils.FileManager.DeleteFile(project.Logo);
            Utils.FileManager.DeleteFile(project.MainImage);
            Utils.FileManager.DeleteFile(project.SliderImage);
            Utils.FileManager.DeleteFile(project.ResponseImage);
            db.Entry(project).State = EntityState.Deleted;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
