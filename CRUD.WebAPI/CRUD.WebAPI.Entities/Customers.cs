using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.WebAPI.Entities
{
    [Table("Clientes")]
    public class Customers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

        [ForeignKey("Professions")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("IdProfissao")]
        public int IdProfession { get; set; }

        public Professions Professions { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [MaxLength(30)]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [MaxLength(100)]
        [DisplayName("Sobrenome")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [MaxLength(11)]
        [DisplayName("CPF")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Data de Nascimento")]
        public DateTime Birthday { get; set; }

        [DisplayName("Idade")]
        public int? Age { get; set; }
    }
}
