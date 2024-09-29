using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RESTAPI_Alimentos.Models
{
    public partial class Alimento
    {
        public int IdAlimentos { get; set; }
        public string NombreAlimento { get; set; } = null!;
        public decimal Cantidad { get; set; }
        public decimal Calorias { get; set; }
        public decimal Proteinas { get; set; }
        public decimal Carbohidratos { get; set; }
        public decimal Grasas { get; set; }
        public decimal Fibra { get; set; }
        public decimal Sodio { get; set; }
        public int? CategoriaId { get; set; }
        public int? UnidadId { get; set; }

        [JsonIgnore]
        public virtual Categoria? Categoria { get; set; }

        [JsonIgnore]
        public virtual Unidad? Unidad { get; set; }
    }
}
