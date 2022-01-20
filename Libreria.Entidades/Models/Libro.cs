using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Libreria.Entidades.Models
{
    [Table("libro", Schema = "libreria")]
    public class Libro
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("isbn")]
        [Required(ErrorMessage ="ISBN requerido.")]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        [StringLength(13, MinimumLength = 10, ErrorMessage = "Maximo {1} digitos, Minimo {2} digitos.")]
        public string ISBN { get; set; }
        [Column("nombre")]
        [Required(ErrorMessage = "Nombre requerido.")]
        public string Nombre { get; set; }
        [Column("autor_id")]
        public int AutorId { get; set; }
        [Column("numero_paginas")]
        public short NumeroDePaginas { get; set; }
        [Required(ErrorMessage = "Descripción requerida.")]
        [Column("descripcion")]
        public string Descripcion { get; set; }
        [Required]
        [Column("fecha_salida")]
        public DateTime FechaSalida { get; set; }

    }

}
