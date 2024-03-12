using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePuntoVenta.Domain.Camionetas.Models
{
    [Table("camionetas")]
    public class Camioneta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("nombre")]
        public string Nombre {  get; set; }

        [Column("placas")]
        public string Placas {  get; set; }
    }
}
