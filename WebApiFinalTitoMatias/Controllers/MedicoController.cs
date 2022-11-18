using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections;
using WebApiFinalTitoMatias.Data;
using WebApiFinalTitoMatias.Models;
using System.Linq;

namespace WebApiFinalTitoMatias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly DbHospitalContext context;

        public MedicoController(DbHospitalContext context)
        {
            this.context = context;
        }

        //GET /api/Medico/
        [HttpGet]
        public IEnumerable Get()
        {
            IEnumerable<Doctor> doctores = (from d in context.Doctores select d).ToList();
            return doctores;

        }

        //GET /api/Medico/id
        [HttpGet("{id}")]
        public Doctor Get(int id)
        {
            Doctor doctor = (from d in context.Doctores where d.Doctor_No == id select d).SingleOrDefault();
            return doctor;
        }

        //GET /api/Medico/espec/especialidad
        [HttpGet("espec/{especialidad}")]
        public dynamic Get(string especialidad)
        {
            dynamic doctores = (from d in context.Doctores where d.Especialidad.ToLower() == especialidad.ToLower() select d).ToList();
            return doctores;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Doctor doctor)
        {
            context.Doctores.Add(doctor);
            context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Doctor doctor)
        {
            if (id != doctor.Doctor_No)
            {
                return BadRequest();
            }
            context.Entry(doctor).State = EntityState.Modified;
            context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Doctor> Delete(int id)
        {
            var doctor = context.Doctores.Find(id);

            if (doctor == null)
            {
                return NotFound();
            }
            context.Doctores.Remove(doctor);
            context.SaveChanges();

            return doctor;

        }
    }
}
