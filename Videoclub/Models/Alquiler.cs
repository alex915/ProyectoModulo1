using System;
using System.Collections.Generic;
using System.Text;
using Videoclub.Models;

namespace Videoclub
{
    class Alquiler
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int PeliculaId { get; set; }
        public Pelicula Pelicula { get; set; }
        public DateTime FechaAlquiler { get; set; }
        public int TiempoReserva { get; set; }
        public TiempoPrestamo TiempoPrestamo { get; set; }
        public Nullable< DateTime> FechaDevolucion { get; set ; }

        public bool Retraso() {
            double days = (this.FechaAlquiler - DateTime.Now).TotalDays;
            if (this.TiempoPrestamo.Dias > days)
            {
                return false;
            }
            return true;
        }

    }
}
