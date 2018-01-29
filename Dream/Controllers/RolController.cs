using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business;
using Microsoft.Extensions.Configuration;
using Entities;

namespace Dream.Controllers
{
    [Produces("application/json")]
    [Route("api/Rol")]
    public class RolController : Controller
    {
        NegocioRol businessRol;
        private readonly IConfiguration _Iconfiguration;

        public RolController(IConfiguration iconfiguration)
        {
            businessRol = new NegocioRol();
            _Iconfiguration = iconfiguration;
        }

        // GET: api/Rol
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Rol/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Rol
        [HttpPost("PostCreateRol")]
        public void PostCreateRol([FromBody]dynamic Entrol)
        {
            if (Entrol != null)
            {
                var activo = Entrol.Activo.Value;
                var nombreRol = Entrol.NombreRol.Value;
                var aplicacionId = Entrol.aplicacionId.Value;
                Rol rol = new Rol
                {
                    Activo = activo,
                    NombreRol = nombreRol,
                    aplicacionId = Convert.ToInt32(aplicacionId)
                };

                businessRol.CreateRol(rol);
            }
        }

        // PUT: api/Rol/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
