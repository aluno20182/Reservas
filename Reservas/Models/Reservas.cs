using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Reservas.Models
{
    public class Reservas
    {
        public int ID { get; set; }

        public string IdCliente { get; set; }

        public string LocalDaReserva { get; set; }

        public DateTime DataDaEntrada { get; set; }

        public DateTime? DataDaSaida { get; set; }

        //  *************************************
        //  Criação das chaves Forasteiras
        //  *************************************

        //  FK para Viatura
        [ForeignKey("Viatura")]  //Anotações são feitas sobre o objeto que está por baixo
        public int ViaturaFK { get; set; }  //Base de Dados

        public Viaturas Viatura { get; set; }   // C#

        [ForeignKey("Tecnico")]  //Anotações são feitas sobre o objeto que está por baixo
        public int TecnicoFK { get; set; }  //Base de Dados

        public Tecnicos Tecnico { get; set; }   // C#

        [ForeignKey("Cliente")]  //Anotações são feitas sobre o objeto que está por baixo
        public int ClienteFK { get; set; }  //Base de Dados

        public Clientes Cliente { get; set; }   // C#



        public ICollection<Reservas> ListaDeReserva { get; set; }

    }
}