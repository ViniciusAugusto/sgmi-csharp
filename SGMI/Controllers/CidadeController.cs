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
    public class CidadeController : Controller
    {
        private ContextoDb db = new ContextoDb();

        // GET: Cidade
        public async Task<ActionResult> Index()
        {
            var cidade = db.Cidade.Include(c => c.Estado);
            return View(await cidade.ToListAsync());
        }

        // GET: Cidade/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CidadeModels cidadeModels = await db.Cidade.FindAsync(id);
            if (cidadeModels == null)
            {
                return HttpNotFound();
            }
            return View(cidadeModels);
        }

        // GET: Cidade/Create
        public ActionResult Create()
        {
            ViewBag.EstadoId = new SelectList(db.Estado, "Id", "Nome");
            return View();
        }

        // POST: Cidade/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nome,EstadoId")] CidadeModels cidadeModels)
        {
            if (ModelState.IsValid)
            {
                db.Cidade.Add(cidadeModels);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EstadoId = new SelectList(db.Estado, "Id", "Nome", cidadeModels.EstadoId);
            return View(cidadeModels);
        }

        // GET: Cidade/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CidadeModels cidadeModels = await db.Cidade.FindAsync(id);
            if (cidadeModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstadoId = new SelectList(db.Estado, "Id", "Nome", cidadeModels.EstadoId);
            return View(cidadeModels);
        }

        // POST: Cidade/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nome,EstadoId")] CidadeModels cidadeModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cidadeModels).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EstadoId = new SelectList(db.Estado, "Id", "Nome", cidadeModels.EstadoId);
            return View(cidadeModels);
        }

        // GET: Cidade/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CidadeModels cidadeModels = await db.Cidade.FindAsync(id);
            if (cidadeModels == null)
            {
                return HttpNotFound();
            }
            return View(cidadeModels);
        }

        // POST: Cidade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CidadeModels cidadeModels = await db.Cidade.FindAsync(id);
            db.Cidade.Remove(cidadeModels);
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
