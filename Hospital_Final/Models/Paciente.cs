using System.ComponentModel.DataAnnotations;

namespace HospitalWeb.Models
{{
    public class Paciente
    {{
        public int Id {{ get; set; }}

        [Required]
        public string Nombre {{ get; set; }}

        [Required]
        public string Apellido {{ get; set; }}

        [Range(0, 120)]
        public int Edad {{ get; set; }}

        [Required]
        public string Sexo {{ get; set; }}

        public string Diagnostico {{ get; set; }}
    }}
}}