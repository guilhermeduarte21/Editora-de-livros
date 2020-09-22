using System;
using System.Text.Json.Serialization;

namespace Editora.Domain
{
    public class Livro
    {
        public Guid Id { get; set; }
        public String Titulo { get; set; }
        public String ISBN { get; set; }
        public int Ano { get; set; }
        [JsonIgnore]
        public Autor Autor { get; set; }
        public Guid AutorId { get; set; }
    }
}
