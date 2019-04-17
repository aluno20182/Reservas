using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reservas.Models
{
    public class Tecnicos
    {
        public int ID { get; set; }

        public string Nome { get; set; }

        public string Cidade { get; set; }

        public string Fotografia { get; set; }


        //***************************************
        //Lista das multas associadas ao agente
        //***************************************

        //lista das multas associadas à viatura
        public ICollection<Reservas> ListaDeReservas { get; set; }

    }
}