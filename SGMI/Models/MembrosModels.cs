using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SGMI.Models
{
    public class MembrosModels
    {
        [Key]
        public int Id { get; set; }
         
        [Required (ErrorMessage = "* Obrigatório!")]
        [StringLength(100,
                      ErrorMessage = "* O campo {0} tem no máximo {1} e no mínimo {2} caracteres",
                      MinimumLength = 10)]

        [Display(Name = "Nome do Membro:")]
        public string Nome { get; set; }

        [StringLength(15,
                      ErrorMessage = "O campo {0} tem no máximo {1} e no mínimo {2} caracteres!",
                      MinimumLength = 10)]
        public string Telefone { get; set; }

        public string Email { get; set; }
    
        [Required(ErrorMessage = "* Obrigatório")]
        [StringLength(14,
                      ErrorMessage = "O campo {0} tem no máximo {1} e no mínimo {2} caracteres!",
                      MinimumLength = 14)]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "* Obrigatório")]
        public int CidadeId { get; set; }

        public virtual CidadeModels Cidade{ get; set; }


    }
}