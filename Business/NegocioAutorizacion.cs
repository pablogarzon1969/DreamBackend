using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class NegocioAutorizacion
    {
        private UnitOfWork unit;
        public NegocioAutorizacion()
        {
            unit = new UnitOfWork();
        }

        public IEnumerable<Usuario> ObtenerUsuarioPorRol(Int32 idRol)
        {
            IEnumerable<Usuario> usuariosPorRol;
            return usuariosPorRol = unit.UsuarioRepository.Get(x => x.rol.Id == idRol).AsEnumerable<Usuario>();
            ///return usuariosPorRol = unit.UsuarioAuthorizationRecursoRepository.GetUserByRol(idRol,idAplicacion).AsEnumerable();
        }

        public IEnumerable<dynamic> ObtenerUsuarioPorAplicacion(Int32 idAplicacion, String user)
        {
            // IEnumerable<Usuario> usuario;
            var usuario = from s in unit.UsuarioRepository.Get()
                          join rol in unit.RolRepository.Get() on s.rolId equals rol.Id
                          join permiso in unit.PermisoRepository.Get() on rol.Id equals permiso.rolId
                          where  s.Username == user
                          select new
                          {
                              s.Username,
                              rol.NombreRol,
                              idrol = rol.Id,
                              permiso.NombrePermiso,
                              idpermiso = permiso.Id
                          };
            return usuario.ToList();

        }

        public Usuario Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var userSearch = unit.UsuarioRepository.FindSingleBy(x => x.Username == username);

            // check if username exists
            if (userSearch == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, userSearch.PasswordHash, userSearch.PasswordSalt))
                return null;

            // authentication successful
            return userSearch;
        }


        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}
