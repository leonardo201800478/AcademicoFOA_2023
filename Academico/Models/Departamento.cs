using System.ComponentModel.DataAnnotations;

namespace Academico.Models
{
    public class Departamento
    {
        [Key]
        public int DepartamentoId { get; set; }
        public string Nome { get; set; }
        // outras propriedades do departamento

        public virtual ICollection<InstituicaoDepartamento> InstituicaoDepartamentos { get; set; }
    }
}
