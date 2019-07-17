using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Reservas.Models
{
    public class Reservas
    {
        public int ID { get; set; }

        [Display(Name = "Local da reserva")]
        public string LocalDaReserva { get; set; }

        [Display(Name = "Data da reserva")]
        public DateTime DataDaReserva { get; set; }

        //  *************************************
        //  Criação das chaves Forasteiras
        //  *************************************

        //  FK para Viatura
        [ForeignKey("Viatura")]  //Anotações são feitas sobre o objeto que está por baixo
        public int ViaturaFK { get; set; }  //Base de Dados

        public virtual Viaturas Viatura { get; set; }   // C#


        [ForeignKey("Tecnico")]  //Anotações são feitas sobre o objeto que está por baixo
        public int TecnicoFK { get; set; }  //Base de Dados

        public virtual Tecnicos Tecnico { get; set; }   // C#

        
        [ForeignKey("Cliente")]  //Anotações são feitas sobre o objeto que está por baixo
        public int ClienteFK { get; set; }  //Base de Dados

        public virtual Clientes Cliente { get; set; }   // C#

    }
}
 