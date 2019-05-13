using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Reservas.Models
{
    public class Clientes
    {
        public int ID { get; set; }

        public string Nome { get; set; }

        public string BI { get; set; }

        public string NIF { get; set; }

        public string Telemovel { get; set; }

        public string Email { get; set; }

        public DateTime DataNascimento { get; set; }

        public string NumCartaConducao { get; set; }

        public string LocalEmissao { get; set; }

        public DateTime DataValidadeCarta { get; set; }

        public string MetodoDePagamento { get; set; }

        //  *************************************
        //  Criação das chaves Forasteiras
        //  *************************************

        //  FK para Viatura
        //[ForeignKey("Viatura")]  //Anotações são feitas sobre o objeto que está por baixo
        //public int ViaturaFK { get; set; }  //Base de Dados


        public ICollection<Reservas> ListaDeReservas { get; set; }

    }
}