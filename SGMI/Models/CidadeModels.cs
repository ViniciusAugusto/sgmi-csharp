using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SGMI.Models
{
    public class CidadeModels
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
        [Display(Name = "Estado")]
        public int EstadoId { get; set; }

        public virtual EstadoModels Estado { get; set; }

        public IEnumerable<MembrosModels> Membros { get; set; }
    }
}
