using System.ComponentModel.DataAnnotations;

namespace Cliente_REST_Alimentos.Models
{
    public class AlimentosCl
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

        public virtual CategoriaCl? Categoria { get; set; }

        public virtual UnidadCl? Unidad { get; set; }

    }
}
