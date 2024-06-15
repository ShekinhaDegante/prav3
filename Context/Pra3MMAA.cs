using Microsoft.EntityFrameworkCore;
using prav3.Models;
using System.Collections.Generic;

namespace prav3.Context
{ 
    public class Pra3MMAA : DbContext

    {
        public Pra3MMAA()
        { }

        public Pra3MMAA(DbContextOptions<Pra3MMAA> options)
        : base(options)
        { }

        public DbSet<Editorial> tEditorial { get; set; }
        public DbSet<Libro> tLibro { get; set; }
        public DbSet<inventario> tInventarios { get; set; }
        public DbSet<Sucursal> tSucursal { get; set; }
    }
}
