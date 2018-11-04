using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class UsuarioLogic : BusinessLogic
    {
        private UsuarioAdapter UsuarioData;

        public UsuarioLogic()
        {
            UsuarioData = new UsuarioAdapter();
        }

        public Usuario GetOne(int ID)
        {
            return UsuarioData.GetOne(ID);
        }

        public List<Usuario> GetAll()
        {
            try
            {
                return UsuarioData.GetAll();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
        }

        public void Save(Usuario usuario)
        {
            UsuarioData.Save(usuario);
        }

        public void Delete(int ID)
        {
            UsuarioData.Delete(ID);
        }

        public void Insert(Usuario user)
        {
            UsuarioData.Insert(user);
        }

        public List<ModuloUsuario> GetModulesByUser(int ID)
        {
            return UsuarioData.GetModulesByUser(ID);
        }

        public Usuario Login(Usuario usuario)
        {
            return UsuarioData.Login(usuario);
        }

    }
}
