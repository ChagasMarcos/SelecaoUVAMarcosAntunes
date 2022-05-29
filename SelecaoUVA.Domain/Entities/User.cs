using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SelecaoUVA.Domain.Entities
{
    [Table("USERS")]
    public class User
    {
        [Display(Name = "Código")]
        [Column("ID")]
        public int Id { get; set; }

        [Display(Name = "CPF")]
        [Column("CPF")]
        [Required(ErrorMessage ="Este campo é obrigatório")]
        [StringLength(14, MinimumLength = 11, ErrorMessage = "CPF deve conter {2} digitos.")]
        public string CPF { get; set; }

        [Display(Name = "Nome Completo")]
        [Column("FULLNAME")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string FullName { get; set; }

        [Display(Name = "Telefone")]
        [Column("PHONE")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Phone { get; set; }

        [Display(Name = "E-mail")]
        [Column("EMAIL")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Criado Em")]
        [Column("CREATIONDATE")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Status")]
        [Column("ACTIVE")]
        public bool Active { get; set; }

    }
}
