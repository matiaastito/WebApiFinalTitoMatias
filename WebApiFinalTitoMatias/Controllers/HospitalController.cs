using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApiFinalTitoMatias.Data;
using WebApiFinalTitoMatias.Models;
using System.Collections;
using System.Linq;

namespace WebApiFinalTitoMatias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private readonly DbHospitalContext context;

        public HospitalController(DbHospitalContext context)
        {
            this.context = context;
        }

        //GET /api/Hospital/
        [HttpGet]
        public dynamic Get()
        {
            dynamic hospitales = (from h in context.Hospitales select new { h.Nombre, h.Telefono, h.Num_Cama }).ToList();
            return hospitales;

        }

        //GET /api/Hospital/numCama
        [HttpGet("{numCama}")]
        public dynamic Get(int numCama)
        {
            dynamic hospitales = (from h in context.Hospitales where numCama < h.Num_Cama select new { h.Nombre, h.Telefono, h.Num_Cama }).ToList();
            return hospitales;
        }
            
    }
}
