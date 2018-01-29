using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Business;
using Entities;

namespace Dream.Controllers
{
    [Route("api/TypeNovelty")]
    public class TypeNoveltyController : Controller
    {
        NegocioTipoNovedad businessTypeNovelty;
        private readonly IConfiguration _Iconfiguration;
        public TypeNoveltyController(IConfiguration iconfiguration)
        {
            businessTypeNovelty = new NegocioTipoNovedad();
            _Iconfiguration = iconfiguration;
        }

        [HttpGet]
        public IEnumerable<TipoNovedad> GetTypeNovelties()
        {
            return businessTypeNovelty.GetTypeNovelties();
        }

        [HttpGet("{id}", Name = "GetTypeNoveltyById")]
        public TipoNovedad GetTypeNoveltyById(int id)
        {
            return businessTypeNovelty.GetTypeNoveltyById(id);
        }

        [HttpPost]
        public void Post([FromBody]dynamic EnttypeNovelty)
        {
            if (EnttypeNovelty != null)
            {
                var description = EnttypeNovelty.description.Value;
                var active = EnttypeNovelty.active.Value;
                TipoNovedad typeNovelty = new TipoNovedad
                {
                    Activa = active,
                    Descripcion = description
                };

                businessTypeNovelty.TypeNoveltyCreate(typeNovelty);
            }
        }

        [HttpPut]
        public void Put([FromBody]TipoNovedad typeNovelty)
        {
            businessTypeNovelty.UpdateTypeNovelty(typeNovelty);
        }

        [HttpDelete("{id}")]
        public void Delete(Int32 id)
        {
            businessTypeNovelty.DeleteTypeNovelty(id);
        }
    }
}
