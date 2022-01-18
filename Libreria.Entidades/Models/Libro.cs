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
        [Required]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        [StringLength(13, MinimumLength = 10)]
        public string ISBN { get; set; }
        [Column("nombre")]
        public string Nombre { get; set; }
        [Column("autor_id")]
        public int AutorId { get; set; }
        [Column("numero_paginas")]
        public short NumeroDePaginas { get; set; }
        [Required]
        [Column("descripcion")]
        public string Descripcion { get; set; }
        [Required]
        [Column("fecha_salida")]
        public DateTime FechaSalida { get; set; }
        public Autor Autor { get; set; }

    }

}
