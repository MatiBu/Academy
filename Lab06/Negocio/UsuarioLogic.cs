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

        public List<Usuario> GetAll(int tipo = 2)
        {
            try
            {
                return UsuarioData.GetAll(tipo);
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
            if (!ValidateUnique(user))
            {
                UsuarioData.Insert(user);
            }
        }

        public List<ModuloUsuario> GetModulesByUser(int ID)
        {
            return UsuarioData.GetModulesByUser(ID);
        }

        public Usuario Login(Usuario usuario)
        {
            return UsuarioData.Login(usuario);
        }

        public bool ValidateUnique(Usuario usuario)
        {
            return UsuarioData.ValidateUnique(usuario);
        }

    }
}
