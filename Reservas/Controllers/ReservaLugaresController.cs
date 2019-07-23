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
    public class ReservaLugaresController : Controller
    {

        // cria VAR que representa a BD
        private ReservasDB db = new ReservasDB();

        // GET: ReservaLugares
        [Authorize(Roles = "Administrador, Tecnico, Cliente")] // além de AUTENTICADO,
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
            var lista = db.ReservaLugares.OrderBy(m => m.ID).ToList();
            // filtrar os dados se a pessoa
            // NÃO pertence ao role 'RecursoHumanos' 
            //if (!User.IsInRole("RecursoHumanos, Administrador, Tecnico"))
            //{
            //    // mostrar apenas os dados da pessoa
            //    string userID = User.Identity.GetUserId();
            //    lista = lista.Where(m => m.UserNameID == userID).ToList();
            //}

            return View(lista);
        }

        // GET: ReservaLugares/Details/5
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

            ReservaLugares reservaLugar = db.ReservaLugares.Find(id);

            Clientes cliente = db.Clientes.Find(id); ;
            if (reservaLugar == null)
            {
                return RedirectToAction("Index");
            }
            Session["Metodo"] = "";

            // se cheguei aqui, o Cliente foi encontrado na BD
            // será que tenho autorização para aceder aos seus dados?
            if (User.IsInRole("RecursosHumanos") ||
                User.IsInRole("GestorReservas") ||
                cliente.UserNameID == User.Identity.GetUserId())
            {
                // se isto se verifica , posso ver os dados do Cliente
                return View(reservaLugar);
            }
            else
            {
                // não tenho autorização
                return RedirectToAction("Index");
            }
        }

        // GET: ReservaLugares/Create
        /// <summary>
        /// mostra a view para carregar os dados de um novo Cliente
        /// </summary>
        /// <returns></returns>
        /// 
        [Authorize(Roles = "Administrador, Cliente")]

        public ActionResult Create()
        {
            return View();
        }

        // POST: ReservaLugares/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        /// <summary>
        /// recolhe os dados da View, sobre um novo Cliente
        /// </summary>
        /// <param name="reservaLugar">dados da nova Reserva</param>
        /// <returns></returns>
        [Authorize(Roles = "Administrador, Cliente")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LocalDaReserva, DataDaReserva")] ReservaLugares reservaLugar)
        {

            /// confronta os dados q vêm da view com a forma que os dados devem ter.
            /// ie, valida os dados com o Modelo
            if (ModelState.IsValid)
            {
                db.ReservaLugares.Add(reservaLugar);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(reservaLugar);
        }



        // GET: ReservaLugares/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservaLugares reservaLugar = db.ReservaLugares.Find(id);
            if (reservaLugar == null)
            {
                return View();
            }
            return View(reservaLugar);
        }

        // POST: ReservaLugares/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LocalDaReserva, DataDaReserva")] ReservaLugares reservaLugar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservaLugar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reservaLugar);
        }

        // GET: ReservaLugares/Delete/5
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

                /// e não há ID da Reserva, uma de duas coisas aconteceu:
                ///   - há um erro nos links da aplicação
                ///   - há um 'chico experto' a fazer asneiras no URL

                /// redireciono o utilzador para o ecrã incial
                return RedirectToAction("Index");
            }

            // procura os dados do Clientes, cujo ID é fornecido
            ReservaLugares reservaLugar = db.ReservaLugares.Find(id);


            /// se a reserva não fôr encontrado
            if (reservaLugar == null)
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
            Session["IdReserva"] = reservaLugar.ID;
            Session["Metodo"] = "ReservaLugares/Delete";

            // envia para a View os dados do Cliente encontrado
            return View(reservaLugar);
        }

        // POST: ReservaLugares/Delete/5
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
            string operacao = "ReservaLugares/Delete";
            if (operacao != (string)Session["Metodo"])
            {
                // há um ataque!
                // redirecionar para a página de Index
                return RedirectToAction("Index");
            }

            // procura os dados do Cliente, na BD
            ReservaLugares reservaLugar = db.ReservaLugares.Find(id);

            if (reservaLugar == null)
            {
                // não foi possível encontrar o Cliente
                return RedirectToAction("Index");
            }

            try
            {
                db.ReservaLugares.Remove(reservaLugar);
                db.SaveChanges();
            }
            catch (Exception)
            {
                // captura a excessão e processa o código para resolver o problema
                // pode haver mais do que um 'catch' associado a um 'try'

                // enviar mensagem de erro para o utilizador
                ModelState.AddModelError("", "Ocorreu um erro com a eliminação do Cliente "
                                            + reservaLugar.LocalDaReserva +
                                            ". Provavelmente relacionado com o facto do " +
                                            "cliente ter gerido uma reserva...");
                // devolver os dados do Cliente à View
                return View(reservaLugar);
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
