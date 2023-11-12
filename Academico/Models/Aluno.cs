using System.ComponentModel.DataAnnotations;

namespace Academico.Models
{
    public class Aluno
    {
        [Key]
        public int AlunoId { get; set; }
        public string Nome { get; set; }
        // outras propriedades do aluno

        public virtual ICollection<AlunoDisciplina> AlunoDisciplinas { get; set; }
    }
}
