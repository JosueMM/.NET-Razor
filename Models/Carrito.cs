using System;

namespace ASPRazor.Models
{
    public class Carrito
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public string Correo { get; set; }
        public string Contrasenna { get; set; }
        public char Activo { get; set; }
        public int Admin { get; set; }
    }
}