using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HospitalWeb.Data;
using HospitalWeb.Models;

namespace HospitalWeb.Controllers
{{
    public class CitasController : Controller
    {{
        private readonly HospitalContext _context;

        public CitasController(HospitalContext context)
        {{
            _context = context;
        }}

        public async Task<IActionResult> Index()
        {{
            var citas = _context.Citas.Include(c => c.Paciente);
            return View(await citas.ToListAsync());
        }}

        public IActionResult Create()
        {{
            ViewBag.Pacientes = new SelectList(_context.Pacientes, "Id", "Nombre");
            return View();
        }}

        [HttpPost]
        public async Task<IActionResult> Create(Cita cita)
        {{
            if (ModelState.IsValid)
            {{
                _context.Add(cita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }}
            ViewBag.Pacientes = new SelectList(_context.Pacientes, "Id", "Nombre", cita.PacienteId);
            return View(cita);
        }}
    }}
}}