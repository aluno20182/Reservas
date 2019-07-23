using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Reservas.Models
{
    public class Tecnicos
    {
        public Tecnicos()
        {
            ListaDeReservas = new HashSet<ReservaLugar>();
        }

        [Key] // identifica este atributo como Primary Key
        public int ID { get; set; }

        //[Required(ErrorMessage = "O Nome é de preenchimento obrigatório.")]
        //[StringLength(50, ErrorMessage = "O {0} deve ter, no máximo, {1} caracteres.")]
        //[RegularExpression("[A-ZÁÉÍÓÚ][a-záéíóúàèìòùäëïöüãõâêîôûçñ]+(( | e | de | do | dos | da | das |-|')[A-ZÁÉÍÓÚ][a-záéíóúàèìòùäëïöüãõâêîôûçñ]+)*",
        //                    ErrorMessage = "O {0} só pode conter letras. Cada palavra deve começar com uma Maiúscula.")]
        public string Nome { get; set; }

        //[Required(ErrorMessage = "A Cidade é de preenchimento obrigatório.")]
        //[StringLength(20, ErrorMessage = "A {0} deve ter, no máximo, {1} caracteres.")]
        //[RegularExpression("[A-Z][a-z]+(( |-)[A-Z][a-z]+)*",
        //                    ErrorMessage = "O {0} só pode conter letras. Cada palavra deve começar com uma Maiúscula.")]

        public string Cidade { get; set; }

        public string Fotografia { get; set; }


        // *************************************
        /// <summary>
        ///  lista das multas associadas ao Tecnicos
        /// </summary>
        /// 
        //[ForeignKey("ReservaLugar")]
        //public int  ReservaFK { get; set; }
        //public virtual ReservaLugar ReservaLugar { get; set; }

        public virtual ICollection<ReservaLugar> ListaDeReservas { get; set; }
        // este termo 'virtual' vai ativar a funcionalidade de 'lazy loading'

        // *************************************
        // criar uma 'chave forasteira' para ligar um Tecnicos
        // ao respetivo UserName
        //  [Required]
        public string UserNameID { get; set; }


    }
}