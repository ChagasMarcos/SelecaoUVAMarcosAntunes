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

        //[Required(ErrorMessage = "O CFP é obrigatório!")]
        //[StringLength(11, MinimumLength = 11, ErrorMessage ="O CPF deve conter 11 dígitos!")]
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
        public string Email { get; set; }

        [Display(Name = "Criado Em")]
        [Column("CREATIONDATE")]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Status")]
        [Column("ACTIVE")]
        public bool  Active { get; set; }

    }
}
