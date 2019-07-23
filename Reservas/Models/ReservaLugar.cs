using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Reservas.Models
{
    public class ReservaLugar
    {

        public ReservaLugar()
        {
            ListaDeReservas = new HashSet<ReservaLugar>();
        }
        [Key]
        public int ID { get; set; }

        [Display(Name = "Local da reserva")]
        public string LocalDaReserva { get; set; }

        [Display(Name = "Data da reserva")]
        public DateTime DataDaReserva { get; set; }

        //  *************************************
        //  Criação das chaves Forasteiras
        //  *************************************

        //  FK para Viatura
        //[ForeignKey("Lugar")]  //Anotações são feitas sobre o objeto que está por baixo
        //public int LugarFK { get; set; }  //Base de Dados

        //public virtual Lugares Lugar { get; set; }   // C#


        [ForeignKey("Tecnico")]  //Anotações são feitas sobre o objeto que está por baixo
        public int TecnicoFK { get; set; }  //Base de Dados
        public virtual Tecnicos Tecnico { get; set; }   // C#

        
        [ForeignKey("Cliente")]  //Anotações são feitas sobre o objeto que está por baixo
        public int ClienteFK { get; set; }  //Base de Dados
        public virtual Clientes Cliente { get; set; }   // C#


        //[ForeignKey("Lugar")]  //Anotações são feitas sobre o objeto que está por baixo
        //public int LugarFK { get; set; }  //Base de Dados
        //public virtual Lugares Lugar { get; set; }   // C#


        // *************************************
        /// <summary>
        ///  lista das multas associadas ao Tecnicos
        /// </summary>
        public virtual ICollection<ReservaLugar> ListaDeReservas { get; set; }
        // este termo 'virtual' vai ativar a funcionalidade de 'lazy loading'

        // *************************************
        // criar uma 'chave forasteira' para ligar um Tecnicos
        // ao respetivo UserName
        //  [Required]
        public string UserNameID { get; set; }

    }
}
 