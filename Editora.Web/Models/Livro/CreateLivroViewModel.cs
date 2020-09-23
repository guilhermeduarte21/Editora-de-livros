using Editora.Web.Models.Autor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Editora.Web.Models.Livro
{
    public class CreateLivroViewModel
    {
        public String Titulo { get; set; }
        public String ISBN { get; set; }
        public int Ano { get; set; }
        public AutorViewModel AutorId { get; set; }
    }
}
