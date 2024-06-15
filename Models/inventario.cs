using System.ComponentModel.DataAnnotations;

namespace prav3.Models
{
    public class inventario
    {
        [Key]
        public int IDInventario { get; set; }

        public int FKIDLibro { get; set; }

        public int FKIDSucursal { get; set; }

        public int Existencia { get; set; }
    }
}
