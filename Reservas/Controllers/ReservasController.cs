using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reservas.Controllers
{
    [Authorize]
    public class ReservasController : Controller
    {
        [Authorize(Roles = "Clientes")]
        // GET: Reservas
        public ActionResult Index()
        {
            return View();
        }
    }
}