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
        [Authorize(Roles = "RecursosHumanos, Administrador")] // além de AUTENTICADO,
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
            var lista = db.Clientes.OrderBy(cc => cc.Nome).ToList();
            // filtrar os dados se a pessoa
            // NÃO pertence ao role 'RecursoHumanos' 
            //if (!User.IsInRole("RecursoHumanos, Administrador"))
            //{
            //    // mostrar apenas os dados da pessoa
            //    string userID = User.Identity.GetUserId();
            //    lista = lista.Where(cc => cc.UserNameID == userID).ToList();
            //    return RedirectToAction("Details", new { id = userID });
            //}

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
            if (User.IsInRole("RecursosHumanos") ||
                User.IsInRole("GestorReservas") ||
                cliente.UserNameID == User.Identity.GetUserId())
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
        [Authorize(Roles = "RecursoHumanos, Administrador, Cliente")]

        public ActionResult Create()
        {
            return View();
        }

        // POST: Tecnicos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        /// <summary>
        /// recolhe os dados da View, sobre um novo Cliente
        /// </summary>
        /// <param name="cliente">dados do novo Cliente</param>
        /// <param name="fotografia">ficheiro com a foto do novo Cliente</param>
        /// <returns></returns>
        [Authorize(Roles = "RecursosHumanos, Administrador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nome, CC, NIF, Telemovel, Email, LocalEmissao")] Clientes cliente, HttpPostedFileBase fotografia)
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
            if (haFoto == false)
            {
                // não há ficheiro,
                // atribui-se-lhe o avatar
                cliente.Fotografia = "Default_Avatar.png";
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
                    // atribuir ao tecnico o nome do ficheiro
                    cliente.Fotografia = nome;
                    // assinalar q há foto
                    haFoto = true;
                }
                else
                {
                    // o ficheiro fornecido não é válido
                    // atribuo a imagem por defeito ao Tecnico
                    cliente.Fotografia = "Default_Avatar.png";
                }
            }

            /// confronta os dados q vêm da view com a forma que os dados devem ter.
            /// ie, valida os dados com o Modelo
            if (ModelState.IsValid)
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                /// 5º como o guardar no disco rígido? e onde?

                return RedirectToAction("Index");
            }

            return View(cliente);
        }



        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Clientes cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return View(cliente);
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]

        public ActionResult Edit([Bind(Include = "ID, Nome, CC, NIF, Telemovel, Email, LocalEmissao")] Clientes cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
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
        [Authorize(Roles = "RecursosHumanos, Administrador")]
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
