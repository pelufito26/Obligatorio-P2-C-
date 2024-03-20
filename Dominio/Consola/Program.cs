using Dominio;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Consola
{
    public class Program
    {
        private static Sistema sistema = Sistema.Instancia;

        static void Main(string[] args)
        {
            int opcion = int.MinValue;
            do
            {
                MostrarTitulo("Menu de opciones");
                MostrarMenu();
                int.TryParse(Console.ReadLine(), out opcion);

                switch (opcion)
                {
                    case 1:
                        AltaMiembro();
                        break;
                    case 2:
                        RetornaPublicacionesMiembro();
                        break;
                    case 3:
                        RetornaPostMiembro();
                        break;
                    case 4:
                        RetornaPostFechas();
                        break;
                    case 5:
                        RetornaMiembrosConMasPublicaciones();
                        break;
                    case 6:
                        Usuarios();
                        break;
                    case 7:
                        ListaAmigos();
                        break;
                    case 8:
                        Invitaciones();
                        break;
                    case 9:
                        Publicaciones();
                        break;
                    case 10:
                        Reacciones();
                        break;
                    case 0:
                        MostrarMensaje("Saliendo...");
                        break;
                    default:
                        MostrarError("Debe seleccionar una opcion valida");
                        break;
                }

            } while (opcion != 0);
        }

        static void MostrarMenu()
        {
            MostrarMensaje("Ingrese una opcion");
            MostrarMensaje("1 - Alta miembro");
            MostrarMensaje("2 - Dado un email de miembro listar todas las publicaciones ...");
            MostrarMensaje("3 - Dado un email de miembro, listar los posts ...");
            MostrarMensaje("4 - Dadas dos fechas listar los posts realizados ...");
            MostrarMensaje("5 - Obtener los miembros que hayan realizados más publicaciones ...");
            MostrarMensaje("0 - Salir");
        }

        static void MostrarTitulo(string titulo)
        {
            Console.WriteLine();
            Console.WriteLine("--------------------");
            Console.WriteLine($"**** {titulo}  ****");
            Console.WriteLine("--------------------");
            Console.WriteLine();
        }

        static void MostrarSeparador()
        {
            Console.WriteLine();
            Console.WriteLine("----------------------");
            Console.WriteLine();
        }

        static void MostrarError(string error)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"**** {error}  ****");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        static void MostrarExito(string exito)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"**** {exito}  ****");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        static void MostrarMensaje(string mensaje)
        {
            Console.WriteLine(mensaje);
        }

        static string PedirPalabras(string mensaje)
        {
            string palabra;
            bool exito = false;
            do
            {
                MostrarMensaje(mensaje);
                palabra = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(palabra) && !EsNumero(palabra))
                {
                    exito = true;
                }
                else if (string.IsNullOrWhiteSpace(palabra))
                {
                    MostrarError("Debe ingresar una palabra válida");
                }
                else
                {
                    MostrarError("No debe ingresar números, solo palabras");
                }
            } while (!exito);



            return palabra;
        }



        static bool EsNumero(string texto)
        {
            int numero;
            return int.TryParse(texto, out numero);
        }




        static int PedirNumeros(string mensaje)
        {
            int numero;
            bool exito = false;
            do
            {
                MostrarMensaje(mensaje);
                exito = int.TryParse(Console.ReadLine(), out numero);
                if (!exito)
                {
                    MostrarError("Debe ingresar solo numeros");
                }
            } while (!exito);

            return numero;
        }
      

        static void AltaMiembro() // Menu 1
        {
            Console.Clear();
            Console.WriteLine("Alta miembro");
            Console.WriteLine();



            try
            {

                string nombre = PedirPalabras("Ingrese el nombre:");
                string apellido = PedirPalabras("Ingrese el apellido:");
                MostrarMensaje("Fecha de nacimiento");

                int mes = PedirNumeros("Ingresa el mes:");

                int dia = PedirNumeros("Ingresa el dia:");

                int anho = PedirNumeros("Ingresa el año:");

                DateTime fechaNacimiento = new DateTime(anho, mes, dia);

                string email = PedirPalabras("Ingrese el mail:");
                string contrasena = PedirPalabras("Ingrese el password:");

                Miembro m = new Miembro(email, contrasena, nombre, apellido, fechaNacimiento, false);
                sistema.AltaMiembro(m);
                MostrarExito("Miembro dado de alta");
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
        }





        static void Usuarios()
        {
            List<User> lista = sistema.ListaUsers;

            foreach (User user in lista)
            {
               
                Console.WriteLine(user);
            }
        }

        static void Invitaciones()
        {
            Console.Clear();
            Console.WriteLine("Invitaciones:");
            Console.WriteLine();

            List<Invitacion> lista = sistema.ListaInvitaciones;
            if (lista.Count == 0)
            {
                MostrarError("No se encontraron resultados");
            }
            else
            {
                foreach (Invitacion inv in lista)
                {
                    Console.WriteLine(inv);
                }
            }

            Console.ReadKey();
        }

        static void Publicaciones()
        {
            List<Post> lista = sistema.ListaPost;

            foreach (Post pub in lista)
            {
                Console.WriteLine(pub);

                foreach (Comentario com in pub.ListaComentario)
                {
                    Console.WriteLine(com);
                }

            }
        }

        static void RetornaPublicacionesMiembro() // Menu 2
        {
            try
            {
                string email = PedirPalabras("Ingrese el mail del miembro:");
                List<Publicacion> lista = sistema.RetornaPublicaciones(email);

                foreach (Publicacion pub in lista)
                {
                    Console.WriteLine(pub);
                }

            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);


                Console.ReadKey();
            }


        }


        static void RetornaPostMiembro() // Menu 3
        {

            try
            {
                string email = PedirPalabras("Ingrese el mail del miembro:");
                List<Post> lista = sistema.RetornaPostsConComentariosDeMiembro(email);

                foreach (Publicacion pub in lista)
                {
                    Console.WriteLine(pub);
                }
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);


                Console.ReadKey();

            }

        }

        static void RetornaPostFechas()
        {
            try
            {
                Console.WriteLine("Ingrese la fecha inicial:");

                int mes = PedirNumeros("Ingresa el mes:");
                int dia = PedirNumeros("Ingresa el dia:");
                int anho = PedirNumeros("Ingresa el año:");

                DateTime fechaInicial = new DateTime(anho, mes, dia);


                Console.WriteLine("Ingrese la fecha final:");

                int mesFinal = PedirNumeros("Ingresa el mes:");

                int diaFinal = PedirNumeros("Ingresa el dia:");
            
                int anhoFinal = PedirNumeros("Ingresa el año:");

                DateTime fechaFinal = new DateTime(anhoFinal, mesFinal, diaFinal);

           
                List<Publicacion> listaPost = sistema.RetornaListaPostFechas(fechaInicial, fechaFinal);

                foreach (Publicacion post in listaPost)
                {
                    Console.WriteLine(post);
                }
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);


                Console.ReadKey();

            }

        }

        static void RetornaMiembrosConMasPublicaciones()
        {
            try
            {
                List<Miembro> listaMiembro = sistema.RetornaMiembrosConMasPublicaciones();


                foreach (Miembro miem in listaMiembro)
                {
                    Console.WriteLine(miem);
                }

            }
            catch 
            {
                MostrarError("No hay registros!");
            }
          

        }

        static void ListaAmigos()
        {
            string inputEmail = PedirPalabras("Ingrese un mail");
            Miembro miembroElegido = sistema.RetornaMiembroPorMail(inputEmail);

            List<Miembro> lista = sistema.RetornaListaAmigos(miembroElegido);

            foreach(Miembro m in lista)
            {
                Console.WriteLine(m);
            }

            if (lista.Count <= 0) Console.WriteLine("La lista esta vacia");
        }


        static void Reacciones()
        {
            List<Reaccion> lista = sistema.ListarReacciones();

                foreach (Reaccion r in lista)
                {
                    Console.WriteLine(r);
                }
            
        }
    }
}