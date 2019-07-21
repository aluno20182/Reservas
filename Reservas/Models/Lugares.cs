using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reservas.Models
{
    public class Lugares
    {
        public int ID { get; set; }

        public string Cidade { get; set; }

        public bool livre { get; set; }

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
        public string UserNameID { get; set; }
    }
}