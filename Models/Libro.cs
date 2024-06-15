using System.ComponentModel.DataAnnotations;

namespace prav3.Models
{
    public class Libro
    {
        [Key]
        public int IDLibro { get; set; }


        public string ISBN { get; set; }


        public string Titulo { get; set; }


        public string Autor { get; set; }

        public int FKIDEditorial { get; set; }

        public int Año { get; set; }

        public decimal Precio { get; set; }

        public string Comentarios { get; set; }

        public string Foto { get; set; }
    }
}
