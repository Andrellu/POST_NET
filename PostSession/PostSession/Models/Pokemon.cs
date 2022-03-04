using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PostSession.Models
{
    [Table("Pokemon")]
    public class Pokemon
    {
        [Key]
        [Column("NumeroPokedex")]
        public int NumeroPokedex { get; set; }
        [Column("Nombre")]
        public String Nombre { get; set; }
        [Column("Tipo")]
        public String Tipo { get; set; }
        [Column("Imagen")]
        public String Imagen { get; set; }
    }
}
