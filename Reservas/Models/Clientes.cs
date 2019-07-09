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
        [Key] // identifica este atributo como Primary Key
        public int ID { get; set; }

        [Required(ErrorMessage = "O Nome é de preenchimento obrigatório.")]
        [StringLength(50, ErrorMessage = "O {0} deve ter, no máximo, {1} caracteres.")]
        [RegularExpression("[A-ZÁÉÍÓÚ][a-záéíóúàèìòùäëïöüãõâêîôûçñ]+(( | e | de | do | dos | da | das |-|')[A-ZÁÉÍÓÚ][a-záéíóúàèìòùäëïöüãõâêîôûçñ]+)*",
                    ErrorMessage = "O {0} só pode conter letras. Cada palavra deve começar com uma Maiúscula.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A Esquadra é de preenchimento obrigatório.")]
        [StringLength(20, ErrorMessage = "A {0} deve ter, no máximo, {1} caracteres.")]
        [RegularExpression("[A-Z][a-z]+(( |-)[A-Z][a-z]+)*",
                    ErrorMessage = "O {0} só pode conter letras. Cada palavra deve começar com uma Maiúscula.")]
        public string BI { get; set; }

        public string NIF { get; set; }

        public string Telemovel { get; set; }

        public string Email { get; set; }

        public DateTime DataNascimento { get; set; }

        public string NumCartaConducao { get; set; }

        public string LocalEmissao { get; set; }

        public DateTime DataValidadeCarta { get; set; }

        public string MetodoDePagamento { get; set; }

        //  *************************************
        //  Criação das chaves Forasteiras
        //  *************************************

        //  FK para Viatura
        //[ForeignKey("Viatura")]  //Anotações são feitas sobre o objeto que está por baixo
        //public int ViaturaFK { get; set; }  //Base de Dados


        public ICollection<Reservas> ListaDeReservas { get; set; }

    }
}