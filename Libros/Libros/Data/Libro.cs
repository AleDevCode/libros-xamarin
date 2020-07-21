using System;
using System.Collections.Generic;
using System.Text;

namespace Libros.Data
{
    public class Libro
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Autor { get; set; }
        public string Genero { get; set; }
    }
}
