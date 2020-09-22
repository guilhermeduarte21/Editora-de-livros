using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Editora.Web.Models.Usuario
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Login é um campo obrigátorio")]
        public String Login { get; set; }

        [Required(ErrorMessage = "Password é um campo obrigátorio")]
        public String Password { get; set; }
    }
}
