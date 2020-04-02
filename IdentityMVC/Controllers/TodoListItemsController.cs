using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IdentityMVC.Models;
using Microsoft.AspNet.Identity;

namespace IdentityMVC.Controllers
{
    [Authorize]
    public class TodoListItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TodoListItems
        public ActionResult Index()
        {
            List<TodoListItems> lists = new List<TodoListItems>();

            foreach(TodoListItems x in db.TodoListItemss.ToList()) // filter dari semua todolist
            {
                if (x.user_todolist_id == User.Identity.GetUserId()) 
                {
                    lists.Add(x);
                }
            }

            return View(lists.ToList());


        }

        // GET: TodoListItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TodoListItems todoListItems = db.TodoListItemss.Find(id);
            if (todoListItems == null)
            {
                return HttpNotFound();
            }
            return View(todoListItems);
        }

        // GET: TodoListItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TodoListItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,isCompleted,user_todolist_id")] TodoListItems todoListItems)
        {
            if (ModelState.IsValid)
            {

                todoListItems.user_todolist_id = User.Identity.GetUserId(); // get userid
                db.TodoListItemss.Add(todoListItems);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(todoListItems);
        }

        // GET: TodoListItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TodoListItems todoListItems = db.TodoListItemss.Find(id);
            if (todoListItems == null)
            {
                return HttpNotFound();
            }
            return View(todoListItems);
        }

        // POST: TodoListItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,isCompleted,user_todolist_id ")] TodoListItems todoListItems)
        {
            if (ModelState.IsValid)
            {
                todoListItems.user_todolist_id = User.Identity.GetUserId(); // get userid
                db.Entry(todoListItems).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(todoListItems);
        }

        // GET: TodoListItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TodoListItems todoListItems = db.TodoListItemss.Find(id);
            if (todoListItems == null)
            {
                return HttpNotFound();
            }
            return View(todoListItems);
        }

        // POST: TodoListItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TodoListItems todoListItems = db.TodoListItemss.Find(id);
            db.TodoListItemss.Remove(todoListItems);
            db.SaveChanges();
            return RedirectToAction("Index");
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
