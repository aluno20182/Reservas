using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Reservas.Models;

namespace Reservas.Controllers
{
    [Authorize]//Só pessoas autenticadas podem executar esas tarefas
    public class ClientesController : Controller    {

        // cria VAR que representa a BD
        private ReservasDB db = new ReservasDB();

        // GET: Clientes
        [Authorize(Roles = "Cliente")] // além de AUTENTICADO,
        // só os utilizadores do tipo RecursosHumanos ou Clientes têm acesso
        // só precisa de pertencer a uma delas...
        //*****************************************************
        ////[Authorize(Roles = "RecursosHumanos")]  // exemplo de uma situação em que 
        ////[Authorize(Roles = "Clientes")]          // os utilizadores TÊM AS DUAS Roles
        public ActionResult Index()
        {

            Session["Metodo"] = "";

            // procura a totalidade dos Clientes na BD

            // Instrução feita em LINQ
            // SELECT * FROM Clientes ORDER BY nome
            var lista = db.Clientes.OrderBy(a => a.Nome).ToList();
            // filtrar os dados se a pessoa
            // NÃO pertence ao role 'RecursoHumanos' 
            if (!User.IsInRole("Cliente"))
            {
                // mostrar apenas os dados da pessoa
                string bi = User.Identity.GetUserId();
                lista = lista.Where(a => a.BI == bi).ToList();
            }

            return View(lista);
        }

        // GET: Clientes/Details/5
        /// <summary>
        /// Mostra os dados de um Cliente 
        /// </summary>
        /// <param name="id">identifica o Cliente</param>
        /// <returns>devolve a View com os dados</returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }


            /// quem pode aceder aos dados:
            ///    - quem pertencer à role RecursosHumanos ou à role GestorMultas
            ///        - neste caso em concreto, acede aos dados de qq Cliente
            ///    - é o Cliente, q só acede aos seus dados

            Clientes cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return RedirectToAction("Index");
            }
            Session["Metodo"] = "";

            // se cheguei aqui, o Cliente foi encontrado na BD
            // será que tenho autorização para aceder aos seus dados?
            if (User.IsInRole("Cliente"))
            {
                // se isto se verifica , posso ver os dados do Cliente
                return View(cliente);
            }
            else
            {
                // não tenho autorização
                return RedirectToAction("Index");
            }
        }

        // GET: Clientes/Create
        /// <summary>
        /// mostra a view para carregar os dados de um novo Cliente
        /// </summary>
        /// <returns></returns>
        /// 
        [Authorize(Roles = "Cliente")]

        public ActionResult Create()
        {
            return View();
        }


        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Cidade,Fotografia")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientes);
        }

        // GET: Clientes/Delete/5
        /// <summary>
        /// mostra na view os dados de um Cliente para porterior, eventual, remoção
        /// </summary>
        /// <param name="id">identificador do Cliente a remover</param>
        /// <returns></returns>
        public ActionResult Delete(int? id)
        {
            // o ID do Cliente não foi fornecido
            // não é possível procurar o Cliente
            // o que devo fazer?
            if (id == null)
            {
                ///  opção por defeito do 'template'
                ///  return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                /// e não há ID do Cliente, uma de duas coisas aconteceu:
                ///   - há um erro nos links da aplicação
                ///   - há um 'chico experto' a fazer asneiras no URL

                /// redireciono o utilzador para o ecrã incial
                return RedirectToAction("Index");
            }

            // procura os dados do Clientes, cujo ID é fornecido
            Clientes cliente = db.Clientes.Find(id);


            /// se o Cliente não fôr encontrado
            if (cliente == null)
            {
                // ou há um erro,
                // ou há um 'chico experto'...
                //   return HttpNotFound();

                /// redireciono o utilzador para o ecrã incial
                return RedirectToAction("Index");
            }

            /// para o caso do utilizador alterar, de forma fraudulenta,
            /// os dados do Cliente, vamos guardá-los internamente
            /// Para isso, vou guardar o valor do ID do Cliente
            /// - guardar o ID do Cliente num cookie cifrado
            /// - guardar o ID numa var. de sessão 
            ///      (quem estiver a usar o Asp .Net Core já não tem esta ferramenta...)
            /// - outras opções...
            Session["IdCliente"] = cliente.ID;
            Session["Metodo"] = "Clientes/Delete";

            // envia para a View os dados do Cliente encontrado
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        /// <summary>
        /// concretizar a operação de remoção de um Cliente
        /// </summary>
        /// <param name="id"> identificador do Cliente</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {

            if (id == null)
            {
                // se entrei aqui,é porque é pq há um erro
                // nao se sabe o ID do Cliente a remover
                return RedirectToAction("Index");
            }

            // avaliar se o ID do Cliente que é fornecido
            // é o mesmo ID do Cliente que foi apresentado no ecrã
            if (id != (int)Session["IdCliente"])
            {
                // há um ataque!
                // redirecionar para a página de Index
                return RedirectToAction("Index");
            }

            // avaliar se o método é o que é esperado
            string operacao = "Clientes/Delete";
            if (operacao != (string)Session["Metodo"])
            {
                // há um ataque!
                // redirecionar para a página de Index
                return RedirectToAction("Index");
            }

            // procura os dados do Cliente, na BD
            Clientes cliente = db.Clientes.Find(id);

            if (cliente == null)
            {
                // não foi possível encontrar o Cliente
                return RedirectToAction("Index");
            }

            try
            {
                db.Clientes.Remove(cliente);
                db.SaveChanges();
            }
            catch (Exception)
            {
                // captura a excessão e processa o código para resolver o problema
                // pode haver mais do que um 'catch' associado a um 'try'

                // enviar mensagem de erro para o utilizador
                ModelState.AddModelError("", "Ocorreu um erro com a eliminação do Cliente "
                                            + cliente.Nome +
                                            ". Provavelmente relacionado com o facto do " +
                                            "cliente ter gerido uma reserva...");
                // devolver os dados do Cliente à View
                return View(cliente);
            }

            // redireciona o interface para a view INDEX associada ao controller Clientes
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
