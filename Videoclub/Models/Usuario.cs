using System;
using System.Collections.Generic;
using System.Text;

namespace Videoclub
{
    class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public DateTime FNac { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Estado { get; set; }

        public Usuario()
        {
        }

        public Usuario(string nombre, string primerApellido, string segundoApellido, DateTime fNac, string email, string password)
        {

            Nombre = nombre;
            PrimerApellido = primerApellido;
            SegundoApellido = segundoApellido;
            FNac = fNac;
            Email = email;
            Password = password;
        }

        public int Edad()
        {
         return new DateTime( (DateTime.Now - this.FNac).Ticks).Year-1;
            
        }
    }
}
