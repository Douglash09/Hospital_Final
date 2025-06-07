using Microsoft.EntityFrameworkCore;
using Hospital_Final.Models;
using HospitalWeb.Models;

namespace Hospital_Final.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options)
        {
        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Cita> Citas { get; set; }
    }
}
