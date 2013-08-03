using inln_bootstrap.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace inln_bootstrap.Areas.Admin.Controllers
{
    public class ClientController : Controller
    {
        private ContextDb db = new ContextDb();

        public ActionResult Index()
        {
            IEnumerable<ClientModel> clients = db.Clients.OrderByDescending(c => c.ClientId);

            return View(clients);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ClientModel client, HttpPostedFileBase file)
        {
            client.EntryCreated = DateTime.Now;
            client.Guid = Guid.NewGuid();
            client.Logo = Utils.FileManager.UploadFile(file, "Clients", client.Guid, "logo");
            db.Entry(client).State = EntityState.Added;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ClientModel client = db.Clients.Find(id);

            return View(client);
        }

        [HttpPost]
        public ActionResult Edit(ClientModel client, HttpPostedFileBase file)
        {
            ClientModel dbClient = db.Clients.Find(client.ClientId);
            client.EntryCreated = dbClient.EntryCreated;
            client.Guid = dbClient.Guid;

            if (client.LogoToDelete == false)
            {
                client.Logo = Utils.FileManager.UpdateFile(dbClient.Logo, file, "Clients", dbClient.Guid, "logo");
            }
            else
            {
                client.Logo = Utils.FileManager.DeleteFile(dbClient.Logo);
                client.LogoToDelete = false;
            }

            db.Entry(dbClient).State = EntityState.Detached;
            db.Entry(client).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            ClientModel client = db.Clients.Find(id);

            return View(client);
        }

        public ActionResult Delete(int id)
        {
            ClientModel client = db.Clients.Find(id);

            return View(client);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            ClientModel client = db.Clients.Find(id);
            Utils.FileManager.DeleteFile(client.Logo);
            db.Entry(client).State = EntityState.Deleted;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Order()
        {
            IEnumerable<ClientModel> clients = db.Clients.OrderBy(c => c.Order);

            return View(clients);
        }

        public void OrderSave(int[] client) //3, 1, 2, 10, 15...
        {
            int counter = 1;
            ClientModel tempClient;
            foreach (int cl in client)
            {
                tempClient = db.Clients.Find(cl);
                tempClient.Order = counter;
                db.Entry(tempClient).State = EntityState.Modified;
                counter++;
            }
            db.SaveChanges();
        }
    }
}
