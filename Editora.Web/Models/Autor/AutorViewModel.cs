using Editora.Web.Models.Livro;
using System;
using System.Collections.Generic;

namespace Editora.Web.Models.Autor
{
    public class AutorViewModel
    {
        public Guid Id { get; set; }
        public String Nome { get; set; }
        public String UltimoNome { get; set; }
        public String Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public virtual List<LivroViewModel> Livros { get; set; }
    }
}
