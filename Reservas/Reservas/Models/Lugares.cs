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

        public decimal ValorMulta { get; set; }

        public DateTime DataDaReservas { get; set; }

        //  *************************************
        //  Criação das chaves Forasteiras
        //  *************************************

        //  FK para Viatura
        [ForeignKey("Viatura")]  //Anotações são feitas sobre o objeto que está por baixo
        public int ViaturaFK { get; set; }  //Base de Dados

        public Viaturas Viatura { get; set; }   // C#

        [ForeignKey("Tecnico")]  //Anotações são feitas sobre o objeto que está por baixo
        public int TecnicoFK { get; set; }  //Base de Dados

        public Agentes Agente { get; set; }   // C#

        [ForeignKey("Cliente")]  //Anotações são feitas sobre o objeto que está por baixo
        public int ClienteFK { get; set; }  //Base de Dados

        public Clientes Cliente { get; set; }   // C#


        //lista das multas associadas à viatura
        public ICollection<Reservas> ListaDeReservas { get; set; }

    }
}