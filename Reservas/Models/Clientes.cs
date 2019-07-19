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
            ListaDeReservas = new HashSet<Reservas>();
        } 

        [Key] // identifica este atributo como Primary Key
        public int ID { get; set; }

        //[Required(ErrorMessage = "O Nome é de preenchimento obrigatório.")]
        //[StringLength(50, ErrorMessage = "O {0} deve ter, no máximo, {1} caracteres.")]
        //[RegularExpression("[A-ZÁÉÍÓÚ][a-záéíóúàèìòùäëïöüãõâêîôûçñ]+(( | e | de | do | dos | da | das |-|')[A-ZÁÉÍÓÚ][a-záéíóúàèìòùäëïöüãõâêîôûçñ]+)*",
        //            ErrorMessage = "O {0} só pode conter letras. Cada palavra deve começar com uma Maiúscula.")]
        public string Nome { get; set; }

        //[Required(ErrorMessage = "O CC é de preenchimento obrigatório.")]
        //[StringLength(8, ErrorMessage = "O {0} deve ter, no máximo, {1} caracteres.")]
        //[RegularExpression("[A-Z][a-z]+(( |-)[A-Z][a-z]+)*",
        //            ErrorMessage = "O {0} só pode conter números.")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Count must be a natural number")]
        public string CC { get; set; }

        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Count must be a natural number")]
        public string NIF { get; set; }

        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Count must be a natural number")]
        public string Telemovel { get; set; }

        public string Email { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Fotografia { get; set; }

        public string NumCartaConducao { get; set; }

        public string LocalEmissao { get; set; }

        public DateTime DataValidadeCarta { get; set; }

        public string MetodoDePagamento { get; set; }

        // *************************************
        /// <summary>
        ///  lista das reservas associadas aos Clientes
        /// </summary>
        public virtual ICollection<Reservas> ListaDeReservas { get; set; }
        // este termo 'virtual' vai ativar a funcionalidade de 'lazy loading'

        // *************************************
        // criar uma 'chave forasteira' para ligar um Cliente
        // ao respetivo UserName
        //  [Required]
        public string UserNameID { get; set; }
    }
}