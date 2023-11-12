namespace Academico.Models
{
    public class Instituicao
    {
        public long? InstituicaoId { get; set; }
        public string? Nome { get; set; }
        public string? Endereco { get; set; }

        public ICollection<Departamento>? Departamentos { get; set; }
        public ICollection<InstituicaoDepartamento>? InstituicaoDepartamentos { get; set; }
    }
}
