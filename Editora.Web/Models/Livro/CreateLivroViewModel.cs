using Editora.Web.Models.Autor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Editora.Web.Models.Livro
{
    public class CreateLivroViewModel
    {
        [Required]
        public String Titulo { get; set; }
        [Required]
        public String ISBN { get; set; }
        [Required]
        public int Ano { get; set; }
        public AutorViewModel AutorId { get; set; }
        public Guid Id { get; set; }
        public List<AutorSimplesViewModel> ListaAutores { get; set; }
    }
}
