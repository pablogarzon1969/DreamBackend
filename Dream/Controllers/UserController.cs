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
    [Route("api/User")]
    public class UserController : Controller
    {
        NegocioUsuario negocioUsuario;
        private readonly IConfiguration _Iconfiguration;
        public UserController(IConfiguration iconfiguration)
        {
            negocioUsuario = new NegocioUsuario();
            _Iconfiguration = iconfiguration;
        }

        [HttpGet("{idApplication}", Name = "GetUsersByApplication")]
        public IEnumerable<Usuario> GetUsersByApplication(int idApplication)
        {
            return negocioUsuario.GetUsers();
        }

        [HttpGet("{idApplication}&{user}", Name = "GetUserByApplication")]
        public IEnumerable<Usuario> GetUserByApplication(int idApplication, String user)
        {
            return negocioUsuario.GetUser(idApplication, user);
        }

        // POST: api/User
        [HttpPost("PostCreateUser")]
        public void PostCreateUser([FromBody]dynamic Entuser)
        {
            if (Entuser != null)
            {
                var idRol = Entuser.rolId.Value;
                var name = Entuser.usuarioAutorizado.Value;
                var empresaId = Entuser.empresaId.Value;
                var password = Entuser.password.Value;
                Usuario user = new Usuario
                {
                    rolId = Convert.ToInt32(idRol),
                    Username = name,
                     empresaId= Convert.ToInt32(empresaId)
                };

                negocioUsuario.CreateUser(user, password);
            }
        }

        // PUT: api/User/5
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
