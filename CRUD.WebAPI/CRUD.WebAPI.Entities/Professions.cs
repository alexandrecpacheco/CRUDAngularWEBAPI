using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.WebAPI.Entities
{
    [Table("Profissoes")]
    public class Professions
    {
        //Programador, Analista, Gerente, Estagiário e QA.
        [Key]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public int? Id { get; set; }

        [DisplayName("Profissao")]
        public string Profession { get; set; }
    }
}
