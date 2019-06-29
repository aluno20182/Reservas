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
    public class TecnicosController : Controller    {

        // cria VAR que representa a BD
        private ReservasDB db = new ReservasDB();

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
                return RedirectToAction("Index");
            }
            Tecnicos tecnico = db.Tecnicos.Find(id);
            if (tecnico == null)
            {
                return RedirectToAction("Index");
            }
            Session["Metodo"] = "";

            return View(tecnico);
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
        public ActionResult Create([Bind(Include = "Nome,Cidade")] Tecnicos tecnico, HttpPostedFileBase fotografia)
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
                tecnico.Fotografia = "Default_Avatar.png";
            }
            else
            {
                // há ficheiro
                // será correto?
                if (fotografia.ContentType == "image/jpeg" ||
                   fotografia.ContentType == "image/png")
                {
                    // estamos perante uma foto correta?
                    string extensao = Path.GetExtension(fotografia.FileName).ToLower();
                    Guid g;
                    g = Guid.NewGuid();
                    // nome do ficheiro
                    string nome = g.ToString() + extensao;
                    // onde guardar o ficheiro
                    caminho = Path.Combine(Server.MapPath("~/imagens"), nome);
                    // atribuir ao agente o nome do ficheiro
                    tecnico.Fotografia = nome;
                    // assinalar q há foto
                    haFoto = true;
                }
                else
                {
                    // o ficheiro fornecido não é válido
                    // atribuo a imagem por defeito ao Agente
                    tecnico.Fotografia = "Default_Avatar.png";
                }
            }

            /// confronta os dados q vêm da view com a forma que os dados devem ter.
            /// ie, valida os dados com o Modelo
            if (ModelState.IsValid)
            {
                try
                {
                    db.Tecnicos.Add(tecnico);
                    db.SaveChanges();

                    /// 5º como o guardar no disco rígido? e onde?
                    if (haFoto) fotografia.SaveAs(caminho);

                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    throw;
                }
            }

             return View(tecnico);
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
        /// <summary>
        /// mostra na view os dados de um agente para porterior, eventual, remoção
        /// </summary>
        /// <param name="id">identificador do agente a remover</param>
        /// <returns></returns>
        public ActionResult Delete(int? id)
        {
            // o ID do agente não foi fornecido
            // não é possível procurar o Tecnico
            // o que devo fazer?
            if (id == null)
            {
                ///  opção por defeito do 'template'
                ///  return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                /// e não há ID do Tecnico, uma de duas coisas aconteceu:
                ///   - há um erro nos links da aplicação
                ///   - há um 'chico experto' a fazer asneiras no URL

                /// redireciono o utilzador para o ecrã incial
                return RedirectToAction("Index");
            }

            // procura os dados do Agentes, cujo ID é fornecido
            Tecnicos tecnico = db.Tecnicos.Find(id);


            /// se o agente não fôr encontrado
            if (tecnico == null)
            {
                // ou há um erro,
                // ou há um 'chico experto'...
                //   return HttpNotFound();

                /// redireciono o utilzador para o ecrã incial
                return RedirectToAction("Index");
            }

            /// para o caso do utilizador alterar, de forma fraudulenta,
            /// os dados do Tecnico, vamos guardá-los internamente
            /// Para isso, vou guardar o valor do ID do Tecnico
            /// - guardar o ID do Tecnico num cookie cifrado
            /// - guardar o ID numa var. de sessão 
            ///      (quem estiver a usar o Asp .Net Core já não tem esta ferramenta...)
            /// - outras opções...
            Session["IdAgente"] = tecnico.ID;
            Session["Metodo"] = "Tecnicos/Delete";

            // envia para a View os dados do Agente encontrado
            return View(tecnico);
        }

        // POST: Tecnicos/Delete/5
        /// <summary>
        /// concretizar a operação de remoção de um agente
        /// </summary>
        /// <param name="id"> identificador do agente</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {

            if (id == null)
            {
                // se entrei aqui,é porque é pq há um erro
                // nao se sabe o ID do tecnico a remover
                return RedirectToAction("Index");
            }

            // avaliar se o ID do tecnico que é fornecido
            // é o mesmo ID do tecnico que foi apresentado no ecrã
            if (id != (int)Session["IdTecnico"])
            {
                // há um ataque!
                // redirecionar para a página de Index
                return RedirectToAction("Index");
            }

            // avaliar se o método é o que é esperado
            string operacao = "Tecnicos/Delete";
            if (operacao != (string)Session["Metodo"])
            {
                // há um ataque!
                // redirecionar para a página de Index
                return RedirectToAction("Index");
            }

            // procura os dados do Agente, na BD
            Tecnicos tecnico = db.Tecnicos.Find(id);

            if (tecnico == null)
            {
                // não foi possível encontrar o Agente
                return RedirectToAction("Index");
            }

            try
            {
                db.Tecnicos.Remove(tecnico);
                db.SaveChanges();
            }
            catch (Exception)
            {
                // captura a excessão e processa o código para resolver o problema
                // pode haver mais do que um 'catch' associado a um 'try'

                // enviar mensagem de erro para o utilizador
                ModelState.AddModelError("", "Ocorreu um erro com a eliminação do Agente "
                                            + tecnico.Nome +
                                            ". Provavelmente relacionado com o facto do " +
                                            "tecnico ter gerido uma reserva...");
                // devolver os dados do Tecnico à View
                return View(tecnico);
            }

            // redireciona o interface para a view INDEX associada ao controller Tecnicos
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
