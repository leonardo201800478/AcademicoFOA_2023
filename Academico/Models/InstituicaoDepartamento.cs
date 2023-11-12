using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academico.Models
{
    public class InstituicaoDepartamento
    {
       
        public int? InstituicaoDepartamentoId { get; set; }        
        public int? InstituicaoId { get; set; }       
        public int? DepartamentoId { get; set; }
        public Instituicao? Instituicao { get; set; }
        public Departamento? Departamento { get; set; }
    }
}
