using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HospitalWeb.Data;
using HospitalWeb.Models;

namespace HospitalWeb.Controllers
{{
    public class PacientesController : Controller
    {{
        private readonly HospitalContext _context;

        public PacientesController(HospitalContext context)
        {{
            _context = context;
        }}

        public async Task<IActionResult> Index()
        {{
            return View(await _context.Pacientes.ToListAsync());
        }}

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Paciente paciente)
        {{
            if (ModelState.IsValid)
            {{
                _context.Add(paciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }}
            return View(paciente);
        }}
    }}
}}