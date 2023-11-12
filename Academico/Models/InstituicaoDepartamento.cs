using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Academico.Models
{
    public class InstituicaoDepartamento
    {
        [Key]
        public int InstituicaoDepartamentoId { get; set; }

        [ForeignKey("Instituicao")]
        public int InstituicaoId { get; set; }
        [ForeignKey("Departamento")]
        public int DepartamentoId { get; set; }

        public virtual Instituicao Instituicao { get; set; }
        public virtual Departamento Departamento { get; set; }
    }

}
