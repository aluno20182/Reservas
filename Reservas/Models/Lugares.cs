using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Reservas.Models
{
    public class Lugares
    {
        public Lugares()
        {
            ListaDeLugares = new HashSet<Lugares>();
        }
        [Key]
        public int ID { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public bool Livre { get; set; }

        /*******************************************************************************/

        [ForeignKey("Cliente")]  //Anotações são feitas sobre o objeto que está por baixo
        public int ClienteFK { get; set; }  //Base de Dados
        public virtual Clientes Cliente { get; set; }   // C#

        [ForeignKey("ReservaLugar")]  //Anotações são feitas sobre o objeto que está por baixo
        public int ReservaLugarFK { get; set; }  //Base de Dados
        public virtual ReservaLugares ReservaLugar { get; set; }   // C#



        // *************************************
        /// <summary>
        ///  lista das lugares associadas aos Clientes
        /// </summary>
        public virtual ICollection<Lugares> ListaDeLugares { get; set; }
        // este termo 'virtual' vai ativar a funcionalidade de 'lazy loading'
    }
}