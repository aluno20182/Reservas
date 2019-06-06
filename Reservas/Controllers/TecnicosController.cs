using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Reservas.Models;

namespace Reservas.Controllers
{
    [Authorize]//Só pessoas autenticadas podem executar esas tarefas
    public class TecnicosController : Controller
    {

        // cria VAR que representa a BD
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tecnicos
        public ActionResult Index()
        {
            // procura a totalidade dos Agentes na BD

            // Instrução feita em LINQ
            // SELECT * FROM Agentes ORDER BY nome
            var listaTecnicos = db.Tecnicos.OrderBy(a => a.Nome).ToList();

            return View(listaTecnicos);
        }

        // GET: Tecnicos/Details/5
        /// <summary>
        /// Mostra os dados de um Agente 
        /// </summary>
        /// <param name="id">identifica o Tecnico</param>
        /// <returns>devolve a View com os dados</returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tecnicos tecnicos = db.Tecnicos.Find(id);
            if (tecnicos == null)
            {
                return HttpNotFound();
            }
            return View(tecnicos);
        }

        // GET: Tecnicos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tecnicos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nome,Cidade")] Tecnicos tecnicos, HttpPostedFileBase fotografia)
        {
            /// precisamos de processar a fotografia
            /// 1º será q foi fornecido um ficheiro?
            /// 2º será do tipo correto?
            /// 3º se for do tipo correto, guarda-se
            ///    se não for, atribui-se um 'avatar genérico' ao utilizador

            // var auxiliar
            string caminho = "";
            bool haFoto = false;

            // há ficheiro?
            if (fotografia == null)
            {
                // não há ficheiro,
                // atribui-se-lhe o avatar
                tecnicos.Fotografia = "Default_Avatar.png";
            }
            else
            {
                // há ficheiro
                // será correto?
                if (fotografia.ContentType == "image/jpeg" ||
                   fotografia.ContentType == "image/png")
                {
                    // estamos perante uma foto correta
                    string extensao = Path.GetExtension(fotografia.FileName).ToLower();
                    Guid g;
                    g = Guid.NewGuid();
                    // nome do ficheiro
                    string nome = g.ToString() + extensao;
                    // onde guardar o ficheiro
                    caminho = Path.Combine(Server.MapPath("~/imagens"), nome);
                    // atribuir ao agente o nome do ficheiro
                    tecnicos.Fotografia = nome;
                    // assinalar q há foto
                    haFoto = true;
                }
            }


            if (ModelState.IsValid)
            {
                db.Tecnicos.Add(tecnicos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tecnicos);
        }

        // GET: Tecnicos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tecnicos tecnicos = db.Tecnicos.Find(id);
            if (tecnicos == null)
            {
                return HttpNotFound();
            }
            return View(tecnicos);
        }

        // POST: Tecnicos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Cidade,Fotografia")] Tecnicos tecnicos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tecnicos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tecnicos);
        }

        // GET: Tecnicos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tecnicos tecnicos = db.Tecnicos.Find(id);
            if (tecnicos == null)
            {
                return HttpNotFound();
            }
            return View(tecnicos);
        }

        // POST: Tecnicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tecnicos tecnicos = db.Tecnicos.Find(id);
            db.Tecnicos.Remove(tecnicos);
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
