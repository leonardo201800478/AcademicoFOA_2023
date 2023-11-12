using System.ComponentModel.DataAnnotations;

namespace Academico.Models
{
    public class Curso
    {
        [Key]
        public int CursoId { get; set; }
        public string Nome { get; set; }
        // outras propriedades do curso

        public virtual ICollection<CursoDisciplina> CursoDisciplinas { get; set; }
    }
}
