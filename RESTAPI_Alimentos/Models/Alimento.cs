using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RESTAPI_Alimentos.Models
{
    public partial class Alimento
    {
        public int IdAlimentos { get; set; }

        [MaxLength(90, ErrorMessage = "El campo debe tener maximo 90 caracteres")]
        [Required]
        public string NombreAlimento { get; set; } = null!;

        [Required]
        public decimal Cantidad { get; set; }

        [Required]
        public decimal Calorias { get; set; }

        [Required]
        public decimal Proteinas { get; set; }

        [Required]
        public decimal Carbohidratos { get; set; }

        [Required]
        public decimal Grasas { get; set; }

        [Required]
        public decimal Fibra { get; set; }

        [Required]
        public decimal Sodio { get; set; }

        [Required]
        public int? CategoriaId { get; set; }

        [Required]
        public int? UnidadId { get; set; }

        [JsonIgnore]
        public virtual Categoria? Categoria { get; set; }

       
        public virtual Unidad? Unidad { get; set; }
    }
}
