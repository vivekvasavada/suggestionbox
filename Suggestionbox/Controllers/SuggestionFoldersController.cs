using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Suggestionbox.Models;

namespace Suggestionbox.Controllers
{
    public class SuggestionFoldersController : Controller
    {
        private SuggestionboxContext db = new SuggestionboxContext();

        // GET: SuggestionFolders
        public ActionResult Index()
        {
            return View(db.SuggestionFolders.ToList());
        }

        // GET: SuggestionFolders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuggestionFolder suggestionFolder = db.SuggestionFolders.Find(id);
            if (suggestionFolder == null)
            {
                return HttpNotFound();
            }
            return View(suggestionFolder);
        }

        // GET: SuggestionFolders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuggestionFolders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecordNum,Topic,Suggestion")] SuggestionFolder suggestionFolder)
        {
            if (ModelState.IsValid)
            {
                db.SuggestionFolders.Add(suggestionFolder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(suggestionFolder);
        }

        // GET: SuggestionFolders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuggestionFolder suggestionFolder = db.SuggestionFolders.Find(id);
            if (suggestionFolder == null)
            {
                return HttpNotFound();
            }
            return View(suggestionFolder);
        }

        // POST: SuggestionFolders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecordNum,Topic,Suggestion")] SuggestionFolder suggestionFolder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suggestionFolder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(suggestionFolder);
        }

        // GET: SuggestionFolders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuggestionFolder suggestionFolder = db.SuggestionFolders.Find(id);
            if (suggestionFolder == null)
            {
                return HttpNotFound();
            }
            return View(suggestionFolder);
        }

        // POST: SuggestionFolders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SuggestionFolder suggestionFolder = db.SuggestionFolders.Find(id);
            db.SuggestionFolders.Remove(suggestionFolder);
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
