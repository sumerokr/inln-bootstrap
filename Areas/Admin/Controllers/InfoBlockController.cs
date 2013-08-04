using inln_bootstrap.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace inln_bootstrap.Areas.Admin.Controllers
{
    public class InfoBlockController : Controller
    {
        private ContextDb db = new ContextDb();

        public ActionResult Index(int id)
        {
            IEnumerable<InfoBlockModel> infoBlocks = db.InfoBlocks.Where(ib => ib.ProjectId == id).OrderByDescending(ib => ib.InfoBlockId);
            ViewBag.ProjectId = id;

            return View(infoBlocks);
        }

        public ActionResult Create(int id)
        {
            ViewBag.ProjectId = id;

            return View();
        }

        [HttpPost]
        public ActionResult Create(int id, InfoBlockModel infoBlock, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {
                infoBlock.ProjectId = id;
                infoBlock.EntryCreated = DateTime.Now;
                infoBlock.Image = Utils.FileManager.UploadFile(imageFile, "Projects", infoBlock.Project.Guid);
                db.Entry(infoBlock).State = EntityState.Added;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            InfoBlockModel infoBlock = db.InfoBlocks.Find(id);
            return View(infoBlock);
        }

        [HttpPost]
        public ActionResult Edit(InfoBlockModel infoBlock, HttpPostedFileBase imageFile)
        {
            InfoBlockModel dbInfoBlock = db.InfoBlocks.Find(infoBlock.InfoBlockId);
            if (ModelState.IsValid)
            {
                infoBlock.EntryCreated = dbInfoBlock.EntryCreated;

                if (infoBlock.ImageToDelete == false)
                {
                    infoBlock.Image = Utils.FileManager.UpdateFile(dbInfoBlock.Image, imageFile, "Projects", dbInfoBlock.Project.Guid);
                }
                else
                {
                    infoBlock.Image = Utils.FileManager.DeleteFile(dbInfoBlock.Image);
                    infoBlock.ImageToDelete = false;
                }

                db.Entry(dbInfoBlock).State = EntityState.Detached;
                db.Entry(infoBlock).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(dbInfoBlock);
            }
        }

        public ActionResult Details(int id)
        {
            InfoBlockModel infoBlock = db.InfoBlocks.Find(id);
            return View(infoBlock);
        }

        public ActionResult Delete(int id)
        {
            InfoBlockModel infoBlock = db.InfoBlocks.Find(id);
            return View(infoBlock);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            InfoBlockModel infoBlock = db.InfoBlocks.Find(id);
            Utils.FileManager.DeleteFile(infoBlock.Image);
            db.Entry(infoBlock).State = EntityState.Deleted;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
