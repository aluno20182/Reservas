using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reservas.Models
{
    public class Viaturas
    {
        public int ID { get; set; }

        public string Matricula { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public string NomeDono { get; set; }

        public string  MoradaDono { get; set; }

        public string CodPostalDono { get; set; }
        //***************************************
        //Lista das multas associadas ao Tecnico
        //***************************************

        //lista das multas associadas à viatura
        public ICollection<ReservaLugar> ListaDeReservas { get; set; }


    }
}