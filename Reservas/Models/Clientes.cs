using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Reservas.Models
{
    public class Clientes
    {

        public Clientes()
        {
            ListaDeReservas = new HashSet<ReservaLugares>();
        } 

        [Key] // identifica este atributo como Primary Key
        public int ID { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CC é de preenchimento obrigatório.")]
        public string CC { get; set; }

        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Count must be a natural number")]
        public string NIF { get; set; }

        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Count must be a natural number")]
        public string Telemovel { get; set; }

        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Count must be a natural number")]
        public string Email { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Fotografia { get; set; }

        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Count must be a natural number")]
        public string NumCartaConducao { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        public string LocalEmissao { get; set; }

        public DateTime DataValidadeCarta { get; set; }

        // *************************************
        /// <summary>
        ///  lista das reservas associadas aos Clientes
        /// </summary>
        public virtual ICollection<ReservaLugares> ListaDeReservas { get; set; }
        // este termo 'virtual' vai ativar a funcionalidade de 'lazy loading'

        // *************************************
        // criar uma 'chave forasteira' para ligar um Cliente
        // ao respetivo UserName
        //  [Required]
        public string UserNameID { get; set; }
    }
}