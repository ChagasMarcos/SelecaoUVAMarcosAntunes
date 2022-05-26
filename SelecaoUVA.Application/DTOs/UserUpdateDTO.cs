using System.ComponentModel.DataAnnotations;

namespace SelecaoUVA.Application.DTOs
{
    public class UserUpdateDTO
    {

        [Display(Name = "Nome Completo")]
        public string FullName { get; set; }

        [Display(Name = "Telefone")]
        public string Phone { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }
}
