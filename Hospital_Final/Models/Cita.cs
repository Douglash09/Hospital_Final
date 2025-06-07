using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalWeb.Models
{{
    public class Cita
    {{
        public int Id {{ get; set; }}

        [Required]
        public int PacienteId {{ get; set; }}

        [DataType(DataType.Date)]
        public DateTime Fecha {{ get; set; }}

        [DataType(DataType.Time)]
        public TimeSpan Hora {{ get; set; }}

        public string Doctor {{ get; set; }}

        public string Motivo {{ get; set; }}

        public Paciente Paciente {{ get; set; }}
    }}
}}