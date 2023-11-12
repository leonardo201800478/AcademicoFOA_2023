using System.ComponentModel.DataAnnotations;

namespace Academico.Models
{
    public class Instituicao
    {
        [Key]
        public int InstituicaoId { get; set; }
        public string Nome { get; set; }
        // outras propriedades da instituicao

        public virtual ICollection<InstituicaoDepartamento> InstituicaoDepartamentos { get; set; }
    }
}
