using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Reservas.Models
{
    public class ReservaLugares
    {

        public ReservaLugares()
        {
            ListaDeLugares = new HashSet<Lugares>();
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


        [ForeignKey("Tecnico")]  //Anotações são feitas sobre o objeto que está por baixo
        [DisplayName("Tecnico")]
        public int TecnicoFK { get; set; }  //Base de Dados
        public virtual Tecnicos Tecnico { get; set; }   // C#

        
        [ForeignKey("Cliente")]  //Anotações são feitas sobre o objeto que está por baixo
        [DisplayName("Cliente")]
        public int ClienteFK { get; set; }  //Base de Dados
        public virtual Clientes Cliente { get; set; }   // C#


        // *************************************
        /// <summary>
        ///  lista das multas associadas ao Tecnicos
        /// </summary>
        public virtual ICollection<Lugares> ListaDeLugares { get; set; }
        // este termo 'virtual' vai ativar a funcionalidade de 'lazy loading'


    }
}
 