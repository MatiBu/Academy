using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Logic;
using Business.Entities;

namespace UI.Consola
{
    public class Usuarios
    {
        private UsuarioLogic UsuarioNegocio;

        public Usuarios()
        {
            UsuarioNegocio = new UsuarioLogic();
        }

        public void Menu()
        {
            int opcion = -1;
            while (opcion != 0)
            {
                Console.Clear();
                Console.WriteLine("1 - Listado General");
                Console.WriteLine("2 - Consulta");
                Console.WriteLine("3 - Agregar");
                Console.WriteLine("4 - Modificar");
                Console.WriteLine("5 - Eliminar");
                Console.WriteLine("6 - Salir");
                Console.Write("Seleccion: ");
                Console.WriteLine();

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        {
                            opcion = 1;
                            ListadoGeneral();
                            break;
                        }
                    case ConsoleKey.D2:
                        {
                            opcion = 2;
                            Consultar();
                            break;
                        }
                    case ConsoleKey.D3:
                        {
                            opcion = 3;
                            Agregar();
                            break;
                        }
                    case ConsoleKey.D4:
                        {
                            opcion = 4;
                            Modificar();
                            break;
                        }
                    case ConsoleKey.D5:
                        {
                            opcion = 5;
                            Eliminar();
                            break;
                        }
                    case ConsoleKey.D6:
                        {
                            opcion = 0;
                            break;
                        }
                    default:
                        {
                            opcion = -1;
                            break;
                        }
                }
            }
        }

        public void ListadoGeneral()
        {
            Console.Clear();
            List<Usuario> usuarios = UsuarioNegocio.GetAll();
            foreach (var u in usuarios)
            {
                MostrarDatos(u);
            }
            Console.ReadKey();
        }
        public void Consultar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese el ID del usuario a consultar: ");
                int ID = int.Parse(Console.ReadLine());
                this.MostrarDatos(UsuarioNegocio.GetOne(ID));
            }
            catch (FormatException exception)
            {
                Console.WriteLine("La ID ingresada debe ser un número entero");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }
        public void Agregar()
        {
            Console.Clear();
            Usuario usuario = new Usuario();
            construirUsuario(usuario);
            usuario.State = BusinessEntity.States.New;
            UsuarioNegocio.Save(usuario);
            Console.WriteLine();
            Console.WriteLine("Usuario creado correctamente con el ID: {0}", usuario.ID);
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();

        }
        public void Modificar()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese el ID del usuario a modificar: ");
                int ID = int.Parse(Console.ReadLine());
                Usuario usuario = UsuarioNegocio.GetOne(ID);
                construirUsuario(usuario);
                usuario.State = BusinessEntity.States.Modified;
                UsuarioNegocio.Save(usuario);
            }
            catch (FormatException exception)
            {
                Console.WriteLine("La ID ingresada debe ser un número entero");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }
        private void construirUsuario(Usuario usuario)
        {
            Console.WriteLine("Ingrese el nombre: ");
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el apellido: ");
            usuario.Apellido = Console.ReadLine();
            Console.WriteLine("Ingrese el nombre de usuario: ");
            usuario.NombreUsuario = Console.ReadLine();
            Console.WriteLine("Ingrese la clave: ");
            usuario.Clave = Console.ReadLine();
            Console.WriteLine("Ingrese el email: ");
            usuario.EMail = Console.ReadLine();
            Console.WriteLine("Ingrese habilitacion de usuario (1-Si / otro-No): ");
            usuario.Habilitado = (Console.ReadLine() == "1");
        }
        public void Eliminar()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese el ID del usuario a eliminar: ");
                int ID = int.Parse(Console.ReadLine());
                UsuarioNegocio.Delete(ID);
                Console.WriteLine("El usuario se elminó correctamente.");
            }
            catch (FormatException exception)
            {
                Console.WriteLine("La ID ingresada debe ser un número entero");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }

        public void MostrarDatos(Usuario usr)
        {
            Console.WriteLine("Usuario {0}", usr.ID);
            Console.WriteLine("\t\tNombre {0}", usr.Nombre);
            Console.WriteLine("\t\tApellido {0}", usr.Apellido);
            Console.WriteLine("\t\tNombre de usuario {0}", usr.NombreUsuario);
            Console.WriteLine("\t\tClave {0}", usr.Clave);
            Console.WriteLine("\t\tEmail {0}", usr.EMail);
            Console.WriteLine("\t\tHabilitado {0}", usr.Habilitado);
            Console.WriteLine();
        }

    }
}
