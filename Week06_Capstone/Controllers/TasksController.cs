using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Week06_Capstone.Models;

namespace Week06_Capstone.Controllers
{
    public class TasksController : Controller
    {
        private TaskListEntities db = new TaskListEntities();

        // GET: Tasks
        public ActionResult Index()
        {
            var tasks = db.Tasks.Include(t => t.User);
            return View(tasks.ToList());
        }

        // GET: Tasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // GET: Tasks/Create
        public ActionResult Create()
        {
            ViewBag.Owner = new SelectList(db.Users, "ID", "Name");
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Description,DueDate,Status,TaskID,Owner")] Task task)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Tasks.Add(task);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.Owner = new SelectList(db.Users, "ID", "Name", task.Owner);
            }
            catch (Exception e)
            {

                ViewBag.Message = $"Hmm, something went wrong. {e.Message}";
            }
            return View(task);
        }

        // GET: Tasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            ViewBag.Owner = new SelectList(db.Users, "ID", "Name", task.Owner);
            return View(task);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Description,DueDate,Status,TaskID,Owner")] Task task)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(task).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.Owner = new SelectList(db.Users, "ID", "Name", task.Owner);
            }
            catch (Exception e)
            {

                ViewBag.Message = $"Hmm, something went wrong. {e.Message}";
            }
            return View(task);
        }

        // GET: Tasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Task task = db.Tasks.Find(id);
            db.Tasks.Remove(task);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult TaskSearch(string word)
        {

            TaskListEntities orm = new TaskListEntities();
            
            ViewBag.Items = orm.Tasks.Where(x => x.Description.Contains(word)).ToList();
            if (ViewBag.Items == null)
            {
                ViewBag.Message = "No tasks matching that description";
                return View();
            }
            else
            {
                return View();
            }           
           


        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
