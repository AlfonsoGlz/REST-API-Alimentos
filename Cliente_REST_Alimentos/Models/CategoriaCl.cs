using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Cliente_REST_Alimentos.Models
{
    public class CategoriaCl
    {
        public int IdCategoria { get; set; }
        public string NombreCategoria { get; set; } = null!;

        public virtual ICollection<AlimentosCl>? Alimentos { get; set; }
    }
}
