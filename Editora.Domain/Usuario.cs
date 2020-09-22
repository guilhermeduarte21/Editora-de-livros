using System;

namespace Editora.Domain
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public String Login { get; set; }
        public String Password { get; set; }
    }
}
