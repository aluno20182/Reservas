using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reservas.Models
{
    public class Reservas
    {
        public int ID { get; set; }

        public string IdCliente { get; set; }

        public string LocalDaReservas { get; set; }

        public DateTime DataDaReservas { get; set; }


    }
}