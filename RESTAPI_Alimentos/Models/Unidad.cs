using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RESTAPI_Alimentos.Models
{
    public partial class Unidad
    {
        public Unidad()
        {
            Alimentos = new HashSet<Alimento>();
        }

        public int IdUnidad { get; set; }
        public string NombreUnidad { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<Alimento> Alimentos { get; set; }
    }
}
