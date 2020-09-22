using System;

namespace Editora.Web.Models.Livro
{
    public class LivroViewModel
    {
        public Guid Id { get; set; }
        public String Titulo { get; set; }
        public String ISBN { get; set; }
        public int Ano { get; set; }
        public Guid AutorId { get; set; }
    }
}
