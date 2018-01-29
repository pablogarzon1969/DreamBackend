using Business;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Dream.Controllers
{
   // [Produces("application/json")]
    [Route("api/Application")]
    public class ApplicationController : Controller
    {

        NegocioAplicacion businessApplication;
        private readonly IConfiguration _Iconfiguration;
        public ApplicationController(IConfiguration iconfiguration)
        {
            businessApplication = new NegocioAplicacion();
            _Iconfiguration = iconfiguration;
        }
        // GET: api/Application
        [HttpGet]
        public IEnumerable<Aplicacion> GetApplications()
        {
            return businessApplication.GetApplications();
        }

        // GET: api/Application/5
        [HttpGet("{id}", Name = "GetApplicationByID")]
        public Aplicacion GetApplicationByID(int id)
        {
            return businessApplication.GetApplicationById(id);
        }

        [HttpPost]
        public void Post([FromBody]dynamic Entapplication)
        {
            if (Entapplication != null)
            {
                var NombreAplicacion = Entapplication.nombreAplicacion.Value;
                var activo = Entapplication.activo.Value;
                Aplicacion application = new Aplicacion
                {
                    Activo = activo,
                    NombreAplicacion = NombreAplicacion
                };

                businessApplication.ApplicationCreate(application);
            }
        }



        // PUT: api/Application/5
        [HttpPut]
        public void Put([FromBody]Aplicacion application)
        {
            businessApplication.UpdateApplication(application);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{idApplication}")]
        public void Delete(Int32 idApplication)
        {
            businessApplication.DeleteApplication(idApplication);
        }
    }
}
