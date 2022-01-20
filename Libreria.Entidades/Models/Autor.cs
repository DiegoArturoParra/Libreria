using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Libreria.Entidades.Models
{
    [Table("autor", Schema = "libreria")]
    public class Autor
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("nombre")]
        public string Nombre { get; set; }
        [Required]
        [Column("apellido")]
        public string Apellido { get; set; }
        [Required]
        [Column("edad")]
        public short Edad { get; set; }
    }
}
