using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelecaoUVA.Application.DTOs
{
    public class UserViewDTO
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "CPF")]    
        public string CPF { get; set; }

        [Display(Name = "Nome Completo")]
        public string FullName { get; set; }

        [Display(Name = "Telefone")]
        public string Phone { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Criado Em")]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Status")]
        public bool Active { get; set; }
    }
}
