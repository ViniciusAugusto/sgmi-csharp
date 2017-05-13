using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SGMI.Models;

namespace SGMI.Controllers
{
    public class EstadoController : Controller
    {
        private ContextoDb db = new ContextoDb();

        // GET: Estado
        public async Task<ActionResult> Index()
        {
            return View(await db.Estado.ToListAsync());
        }

        // GET: Estado/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoModels estadoModels = await db.Estado.FindAsync(id);
            if (estadoModels == null)
            {
                return HttpNotFound();
            }
            return View(estadoModels);
        }

        // GET: Estado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nome,Sigla")] EstadoModels estadoModels)
        {
            if (ModelState.IsValid)
            {
                db.Estado.Add(estadoModels);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(estadoModels);
        }

        // GET: Estado/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoModels estadoModels = await db.Estado.FindAsync(id);
            if (estadoModels == null)
            {
                return HttpNotFound();
            }
            return View(estadoModels);
        }

        // POST: Estado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nome,Sigla")] EstadoModels estadoModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estadoModels).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(estadoModels);
        }

        // GET: Estado/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoModels estadoModels = await db.Estado.FindAsync(id);
            if (estadoModels == null)
            {
                return HttpNotFound();
            }
            return View(estadoModels);
        }

        // POST: Estado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            EstadoModels estadoModels = await db.Estado.FindAsync(id);
            db.Estado.Remove(estadoModels);
            await db.SaveChangesAsync();
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
