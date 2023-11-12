using System.ComponentModel.DataAnnotations;

namespace Academico.Models
{
    public class Disciplina
    {
        [Key]
        public int DisciplinaId { get; set; }
        public string Nome { get; set; }
        // outras propriedades da disciplina

        public virtual ICollection<CursoDisciplina> CursoDisciplinas { get; set; }
        public virtual ICollection<AlunoDisciplina> AlunoDisciplinas { get; set; }
    }
}
