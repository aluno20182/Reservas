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
        [RegularExpression("^[1-9][0-9]{1,8}$", ErrorMessage = "Inserção inválida, colocar o primeiro número de 1 a 9 e os restantes de 0 a 9 complentando 8 numeros")]
        [Display(Name = "Cartão de Cidadão")]
        public string CC { get; set; }

        [RegularExpression("^([1-9][0-9]{1,9}$)", ErrorMessage = "Inserção inválida, colocar o primeiro número de 1 a 9 e os restantes de 0 a 9 complentando 9 numeros")]
        public string NIF { get; set; }

        [RegularExpression("^9[1236]{1}[0-9]{7}$|^2[3-9]{2}[0-9]{6}$|^2[12]{1}[0-9]{7}$", ErrorMessage = "Inserção inválida, colocar os primeiros números(92,96,91) e os restantes de 0 a 9 complentando 9 numeros")]
        public string Telemovel { get; set; }
        //Esta regular expression falha se:
        //houver outro subdominio depois do @ .
        //Se depois do ponto houver mais que 3 caracteres, como por exemplo .info

        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Coloque o endereço de email correto(não cologque outro subdominio depois do @, e não coloque correios eletronicos que depois do ponto tiverem mais que 3 caracteres, como por exemplo .info")]
        public string Email { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DataNascimento { get; set; }

        public string Fotografia { get; set; }


        
        public string NumCartaConducao { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        public string LocalEmissao { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DataValidadeCarta { get; set; }

        public string UserNameID { get; set; }

        // *************************************
        /// <summary>
        ///  lista das reservas associadas aos Clientes
        /// </summary>
        public virtual ICollection<ReservaLugares> ListaDeReservas { get; set; }
        // este termo 'virtual' vai ativar a funcionalidade de 'lazy loading'

    }
}