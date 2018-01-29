using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class NegocioUsuario
    {
        private UnitOfWork unit;

        public NegocioUsuario()
        {
            unit = new UnitOfWork();
        }

        /// <summary>
        /// Permite obtener el usuario que hacen parte del modulo de autorizacion
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Usuario> GetUser(int idApplication, String user)
        {
            IEnumerable<Usuario> usuario;
            return usuario = unit.UsuarioRepository.Get(usu =>  usu.Username == user).AsEnumerable();
        }

        /// <summary>
        /// Permite obtener los usuarios que hacen parte del modulo de autorizacion
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Usuario> GetUsers()
        {
            IEnumerable<Usuario> usuarios;
            return usuarios = unit.UsuarioRepository.Get().AsEnumerable();
        }

        /// <summary>
        /// Permite crear el usuario que tendran el usuario
        /// </summary>
        /// <param name="aplicacion"></param>
        /// <returns></returns>
        public Usuario CreateUser(Usuario user,String password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            unit.UsuarioRepository.Insert(user);
            unit.Save();
            return user;
        }


        /// <summary>
        /// Permite eliminar el usuario que utilizara la autorizacion
        /// </summary>
        /// <param name="id"></param>
        public void DeleteUser(Int32 id)
        {
            var user = unit.UsuarioRepository.GetByID(id);
            if (user != null)
            {
                unit.UsuarioRepository.Delete(user);
                unit.Save();
            }
        }
        /// <summary>
        /// Permite actualizar la informacion correspondiente al usuario creado para el modulo de autorizacion
        /// </summary>
        /// <param name="aplicacion"></param>
        /// <returns></returns>
        public String UpdateUser(Usuario user)
        {
            String msg;
            var usuarioconsulta = unit.UsuarioRepository.GetByID(user.Id);

            if (usuarioconsulta == null)
            {
                msg = "El usuario no encontrada";
            }
            else
            {
                usuarioconsulta.Username = user.Username;

                unit.UsuarioRepository.Update(usuarioconsulta);
                unit.Save();
                msg = "Dato Guardado satifactoriamente";
            }
            return msg;
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
