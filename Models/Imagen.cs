using System;

namespace ASPRazor.Models
{
    public class Imagen
    {
        public int Id { get; set; }
        public byte[] ImagenArray { get; set; }
        public char Activo { get; set; }
    }
}