using System;
using System.Collections.Generic;
using System.Text;

namespace Videoclub
{
    class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public int GeneroId { get; set; }
        public Genero Genero { get; set; }
        public int EdadRecomendada { get; set; }
        public EdadRecomendada EdadRecomen { get; set; }
        public bool Estado { get; set; }

    }
}
