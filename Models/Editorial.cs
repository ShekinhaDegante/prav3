using System.ComponentModel.DataAnnotations;

namespace prav3.Models
{
    public class Editorial
    {
        [Key]
        public int IDEditorial { get; set; }

        public string Nombre { get; set; }

        public string NombreDelContacto { get; set; }

        public string Direccion { get; set; }

        public string Ciudad { get; set; }


        public string Telefono { get; set; }


        public string Email { get; set; }

        public string Comentario { get; set; }
    }
}
