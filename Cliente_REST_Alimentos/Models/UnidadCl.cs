using System.Text.Json.Serialization;

namespace Cliente_REST_Alimentos.Models
{
    public class UnidadCl
    {
        public UnidadCl()
        {
            Alimentos = new HashSet<AlimentosCl>();
        }

        public int IdUnidad { get; set; }
        public string NombreUnidad { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<AlimentosCl>? Alimentos { get; set; }
    }
}
