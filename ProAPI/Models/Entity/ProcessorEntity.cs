using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPI.Models.Entity
{
    public class ProcessorEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Marca { get; set; }

        [Required]
        [Range(1970, 2100, ErrorMessage = "El año debe estar entre 1970 y 2100.")]
        public int Año { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser un valor positivo.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Precio { get; set; }

        // Additional properties and relationships specific to the entity
    }
}
