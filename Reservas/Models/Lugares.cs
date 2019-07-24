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

        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O Lugar está ocupado ou foi inserido de forma errada")]
        public bool Livre { get; set; }

        /*******************************************************************************/

        [ForeignKey("ReservaLugar")]  //Anotações são feitas sobre o objeto que está por baixo
        public int ReservaLugarFK { get; set; }  //Base de Dados
        public virtual ReservaLugares ReservaLugar { get; set; }   // C#


    }
}