using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SGMI.Models
{
    public class EstadoModels
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "* Obrigatório!")]
        [StringLength(
            100,
            ErrorMessage = "* O campo {0} aceita o máximo de {1} e o mínimo de {2} caracteres!",
            MinimumLength = 1
        )]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "* Obrigatório!")]
        [StringLength(
            2,
            ErrorMessage = "* O campo {0} aceita o máximo de {1} e o mínimo de {2} caracteres!",
            MinimumLength = 0
        )]
        [Display(Name = "Sigla (UF)")]
        public string Sigla { get; set; }

        public IEnumerable<CidadeModels> Cidades { get; set; }
    }
}
