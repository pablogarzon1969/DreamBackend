using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business;
using Microsoft.Extensions.Configuration;
using Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Dream.Controllers
{
    [Produces("application/json")]
    [Route("api/Authorization")]
    public class AuthorizationController : Controller
    {
        NegocioAutorizacion negocioAutorizacion;
        private readonly IConfiguration _Iconfiguration;
        public AuthorizationController(IConfiguration iconfiguration)
        {
            negocioAutorizacion = new NegocioAutorizacion();
            _Iconfiguration = iconfiguration;
        }
        // GET: api/Autorizacion
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        [HttpGet("UsuarioPorRol")]
        public IEnumerable<Usuario> ObtenerUsuarioPorRol(string rol)
        {      
            return negocioAutorizacion.ObtenerUsuarioPorRol(Convert.ToInt32(rol));
        }

        [HttpGet("ObtenerUsuarioConPerfil")]
        public IEnumerable<dynamic> ObtenerUsuarioConPerfil(int aplicacion, string user)
        {
            return negocioAutorizacion.ObtenerUsuarioPorAplicacion(Convert.ToInt32(aplicacion), user);
        }


        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]Usuario userDto)
        {
            negocioAutorizacion = new NegocioAutorizacion();
            var user = negocioAutorizacion.Authenticate(userDto.Username, userDto.Password);

            if (user == null)
                return Unauthorized();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_Iconfiguration.GetSection("AppSettings").GetSection("Secret").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new
            {
                Id = user.Id,
                Username = user.Username,
                Token = tokenString,
                rolId=user.rolId
            });
        }



        // POST: api/Autorizacion
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Autorizacion/5
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
