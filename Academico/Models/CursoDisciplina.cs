namespace Academico.Models
{
    public class CursoDisciplina
    {
        public int CursoDisciplinaId { get; set; }
        public int CursoId { get; set; }
        public int DisciplinaId { get; set; }        
        public Curso? Curso { get; set; }
        public Disciplina? Disciplina { get; set; }
    }
}
