using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Reservas.Models
{
    public class Lugares
    {
        public Lugares()
        {
            ListaDeReservas = new HashSet<ReservaLugar>();
        }
        [Key]
        public int ID { get; set; }

        [Required]

        public string Cidade { get; set; }

        [Required]
        public bool Livre { get; set; }

        // *************************************
        /// <summary>
        ///  lista das lugares associadas aos Clientes
        /// </summary>
        public virtual ICollection<ReservaLugar> ListaDeReservas { get; set; }
        // este termo 'virtual' vai ativar a funcionalidade de 'lazy loading'

        // *************************************
        // criar uma 'chave forasteira' para ligar um Cliente
        // ao respetivo UserName
        //  [Required]
        //public string UserNameID { get; set; }
    }
}