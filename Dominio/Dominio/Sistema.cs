using System;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dominio // Oficial versión 22NOV
{
    public class Sistema
    {
        private static Sistema _instancia;
        private List<User> _listaUsuarios = new List<User>();
        private List<Invitacion> _listaInvitaciones = new List<Invitacion>();
        private List<Post> _listaPosts = new List<Post>();



        public static Sistema Instancia // Singleton
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new Sistema();
                }
                return _instancia;
            }
        }


        public List<Post> ListaPost
        {
            get { return _listaPosts; }
        }

        public List<User> ListaUsers
        {
            get { return _listaUsuarios; }
        }

        public List<Invitacion> ListaInvitaciones
        {
            get { return _listaInvitaciones; }
        }



        private Sistema()
        {
            PreCargaMiembro();
            PreCargaAdm();
            PreCargaInvitaciones();
            PreCargaPost();
            PreCargaReaccionComentario();
            PreCargaReaccionPost();
          

            PreCargaVinculos();

        }



        public void PreCargaMiembro()
        {
            // PrecargaMiembro
            AltaMiembro(new Miembro("matheus.caique21@gmail.com", "mat123", "Matheus", "Melo", new DateTime(1994, 12, 08), true));
            AltaMiembro(new Miembro("facupelu26@gmail.com", "facu123", "Facundo", "Pelufo", new DateTime(1996, 12, 08), true));
            AltaMiembro(new Miembro("johndoe@gmail.com", "password1", "John", "Doe", new DateTime(1985, 7, 25), true));
            AltaMiembro(new Miembro("janedoe@gmail.com", "password2", "Jane", "Doe", new DateTime(1990, 9, 10), true));
            AltaMiembro(new Miembro("alice.smith@gmail.com", "password3", "Alice", "Smith", new DateTime(1980, 5, 3), true));
            AltaMiembro(new Miembro("bob.johnson@gmail.com", "password4", "Bob", "Johnson", new DateTime(1975, 2, 18), true));
            AltaMiembro(new Miembro("susan.wilson@gmail.com", "password5", "Susan", "Wilson", new DateTime(1992, 11, 8), true));
            AltaMiembro(new Miembro("kevin.martin@gmail.com", "password6", "Kevin", "Martin", new DateTime(1988, 4, 12), true));
            AltaMiembro(new Miembro("lperez@gmail.com", "password7", "Laura", "Perez", new DateTime(1987, 6, 30), true));
            AltaMiembro(new Miembro("michael.jackson@gmail.com", "password8", "Michael", "Jackson", new DateTime(1995, 1, 22), true));
            //AltaAdm(new Administrador("ernesto.perez@gmail.com", "mat123"));



        }



        public int RetornaUltimoID()
        {
            int max = int.MinValue;
            foreach(Invitacion inv in _listaInvitaciones)
            {
                if(inv.IdInv > max)
                {
                    max = inv.IdInv;
                }
            }

            return max += 1;
        }


        public void PreCargaInvitaciones()
        {
            // Invitaciones Matheus con tod*s
            Invitacion inv1 = new Invitacion(1,RetornaMiembroPorMail("matheus.caique21@gmail.com"), RetornaMiembroPorMail("facupelu26@gmail.com"));
            Invitacion inv2 = new Invitacion(2, RetornaMiembroPorMail("matheus.caique21@gmail.com"), RetornaMiembroPorMail("johndoe@gmail.com"));
            Invitacion inv3 = new Invitacion(3, RetornaMiembroPorMail("matheus.caique21@gmail.com"), RetornaMiembroPorMail("janedoe@gmail.com"));
            Invitacion inv4 = new Invitacion(4, RetornaMiembroPorMail("matheus.caique21@gmail.com"), RetornaMiembroPorMail("alice.smith@gmail.com"));
            Invitacion inv5 = new Invitacion(5, RetornaMiembroPorMail("matheus.caique21@gmail.com"), RetornaMiembroPorMail("susan.wilson@gmail.com"));
            Invitacion inv6 = new Invitacion(6, RetornaMiembroPorMail("matheus.caique21@gmail.com"), RetornaMiembroPorMail("kevin.martin@gmail.com"));
            Invitacion inv7 = new Invitacion(7, RetornaMiembroPorMail("matheus.caique21@gmail.com"), RetornaMiembroPorMail("lperez@gmail.com"));
            Invitacion inv8 = new Invitacion(8, RetornaMiembroPorMail("matheus.caique21@gmail.com"), RetornaMiembroPorMail("bob.johnson@gmail.com"));
            Invitacion inv9 = new Invitacion(9, RetornaMiembroPorMail("matheus.caique21@gmail.com"), RetornaMiembroPorMail("michael.jackson@gmail.com"));


            //// Invitaciones Facundo con tod*s
            Invitacion inv10 = new Invitacion(10, RetornaMiembroPorMail("facupelu26@gmail.com"), RetornaMiembroPorMail("michael.jackson@gmail.com"));
            Invitacion inv11 = new Invitacion(11, RetornaMiembroPorMail("facupelu26@gmail.com"), RetornaMiembroPorMail("johndoe@gmail.com"));
            Invitacion inv12 = new Invitacion(12, RetornaMiembroPorMail("facupelu26@gmail.com"), RetornaMiembroPorMail("janedoe@gmail.com"));
            Invitacion inv13 = new Invitacion(13, RetornaMiembroPorMail("facupelu26@gmail.com"), RetornaMiembroPorMail("alice.smith@gmail.com"));
            Invitacion inv14 = new Invitacion(14, RetornaMiembroPorMail("facupelu26@gmail.com"), RetornaMiembroPorMail("susan.wilson@gmail.com"));
            Invitacion inv15 = new Invitacion(15, RetornaMiembroPorMail("facupelu26@gmail.com"), RetornaMiembroPorMail("kevin.martin@gmail.com"));
            Invitacion inv16 = new Invitacion(16, RetornaMiembroPorMail("facupelu26@gmail.com"), RetornaMiembroPorMail("lperez@gmail.com"));
            Invitacion inv17 = new Invitacion(17, RetornaMiembroPorMail("facupelu26@gmail.com"), RetornaMiembroPorMail("bob.johnson@gmail.com"));


            //// Invitaciones rechazadas
            Invitacion inv18 = new Invitacion(18, RetornaMiembroPorMail("alice.smith@gmail.com"), RetornaMiembroPorMail("bob.johnson@gmail.com"));
            Invitacion inv19 = new Invitacion(19, RetornaMiembroPorMail("johndoe@gmail.com"), RetornaMiembroPorMail("janedoe@gmail.com"));

            // Invitaciones Pendientes
            Invitacion inv20 = new Invitacion(20, RetornaMiembroPorMail("michael.jackson@gmail.com"), RetornaMiembroPorMail("lperez@gmail.com"));
            Invitacion inv21 = new Invitacion(21, RetornaMiembroPorMail("lperez@gmail.com"), RetornaMiembroPorMail("kevin.martin@gmail.com"));


            AltaInvitacion(inv1);
            AltaInvitacion(inv2);
            AltaInvitacion(inv3);
            AltaInvitacion(inv4);
            AltaInvitacion(inv5);
            AltaInvitacion(inv6);
            AltaInvitacion(inv7);
            AltaInvitacion(inv8);
            AltaInvitacion(inv9);
            AltaInvitacion(inv10);
            AltaInvitacion(inv11);
            AltaInvitacion(inv12);
            AltaInvitacion(inv13);
            AltaInvitacion(inv14);
            AltaInvitacion(inv15);
            AltaInvitacion(inv16);
            AltaInvitacion(inv17);
            AltaInvitacion(inv18);
            AltaInvitacion(inv19);
            AltaInvitacion(inv20);
            AltaInvitacion(inv21);


        }

        public void PreCargaVinculos()
        {


            // Aceptadas
            AceptarInvitacion(1, "facupelu26@gmail.com");
            AceptarInvitacion(2, "johndoe@gmail.com");
            AceptarInvitacion(3, "janedoe@gmail.com");
            AceptarInvitacion(4, "alice.smith@gmail.com");
            AceptarInvitacion(5, "susan.wilson@gmail.com");
            AceptarInvitacion(6, "kevin.martin@gmail.com");
            AceptarInvitacion(7, "lperez@gmail.com");
            AceptarInvitacion(8, "bob.johnson@gmail.com");
            AceptarInvitacion(9, "michael.jackson@gmail.com");
            AceptarInvitacion(10, "michael.jackson@gmail.com");
            AceptarInvitacion(11, "johndoe@gmail.com");
            AceptarInvitacion(12, "janedoe@gmail.com");
            AceptarInvitacion(13, "alice.smith@gmail.com");
            AceptarInvitacion(14, "susan.wilson@gmail.com");
            AceptarInvitacion(15, "kevin.martin@gmail.com");
            AceptarInvitacion(16, "lperez@gmail.com");
            AceptarInvitacion(17, "bob.johnson@gmail.com");

            //Rechazadas
            RechazarInvitacion(18);
            RechazarInvitacion(19);


        }


        public void PreCargaAdm()
        {
            // PrecargaAdm
            AltaAdm(new Administrador("ernesto.perez@gmail.com", "mat123"));

        }

        public void PreCargaReaccionPost() // HAY QUE AGREGAR MAS 
        {
            Post post = RetornaPostPorId(1);
            Miembro miem = RetornaMiembroPorMail("matheus.caique21@gmail.com");
            if (!HayReaccionPost(1, "matheus.caique21@gmail.com"))
            {
                post.AgregarReaccionAPost(new Reaccion(ReaccionEnum.like, miem));

            }

            Post post2 = RetornaPostPorId(5);
            Miembro miem2 = RetornaMiembroPorMail("facupelu26@gmail.com");
            if (!HayReaccionPost(5, "facupelu26@gmail.com"))
            {
                post2.AgregarReaccionAPost(new Reaccion(ReaccionEnum.like, miem2));

            }



        }

        public void PreCargaReaccionComentario()
        {

            Comentario com = RetornaComentariosPorId(2);
            Miembro miem = RetornaMiembroPorMail("facupelu26@gmail.com");

            if (!HayReaccionComentario(2, "facupelu26@gmail.com"))
            {
                com.AgregarReaccionAComent(new Reaccion(ReaccionEnum.like, miem));

            }

            Comentario com2 = RetornaComentariosPorId(3);
            Miembro miem3 = RetornaMiembroPorMail("facupelu26@gmail.com");

            if (!HayReaccionComentario(3, "facupelu26@gmail.com"))
            {
                com2.AgregarReaccionAComent(new Reaccion(ReaccionEnum.like, miem3));

            }

            //Comentario com5 = RetornaComentariosPorId(3);
            //Miembro miem5 = RetornaMiembroPorMail("facupelu26@gmail.com");

            //if (!HayReaccionComentario(3, "facupelu26@gmail.com"))
            //{
            //    com5.AgregarReaccionAComent(new Reaccion(ReaccionEnum.like, miem5));

            //}


        }


        public void PreCargaPost() // Falta ingresar mas datos acá
        {

            Post post1 = (new Post("Post 1", RetornaMiembroPorMail("matheus.caique21@gmail.com"), DateTime.Now, "Contenido post 1: It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).", Visibilidad.Publico, "imagenPost1.jpg", false));
            post1.AgregarComentario(
                new Comentario("Titulo comentario 2", RetornaMiembroPorMail("matheus.caique21@gmail.com"), DateTime.Now, "Contenido comentario 2 post 1", Visibilidad.Publico));

            post1.AgregarComentario(
                new Comentario("Titulo comentario 2", RetornaMiembroPorMail("matheus.caique21@gmail.com"), DateTime.Now, "Contenido comentario 2 post 1", Visibilidad.Publico));
            post1.AgregarComentario(
                new Comentario("Titulo comentario 3", RetornaMiembroPorMail("facupelu26@gmail.com"), DateTime.Now, "Contenido comentario 3 post 1", Visibilidad.Publico));



            Post post2 = (new Post("Post 2", RetornaMiembroPorMail("matheus.caique21@gmail.com"), DateTime.Now, "Contenido post 2", Visibilidad.Publico, "imagenPost2.jpg", false));
            post2.AgregarComentario(
                new Comentario("Titulo comentario 1", RetornaMiembroPorMail("facupelu26@gmail.com"), DateTime.Now, "Contenido comentario 1 post 2", Visibilidad.Publico));

            post2.AgregarComentario(
                new Comentario("Titulo comentario 2", RetornaMiembroPorMail("facupelu26@gmail.com"), DateTime.Now, "Contenido comentario 1 post 2", Visibilidad.Publico));

            post2.AgregarComentario(
                new Comentario("Titulo comentario 3", RetornaMiembroPorMail("facupelu26@gmail.com"), DateTime.Now, "Contenido comentario 1 post 2", Visibilidad.Publico));

            post2.AgregarComentario(
                new Comentario("Titulo comentario 4", RetornaMiembroPorMail("facupelu26@gmail.com"), DateTime.Now, "Contenido comentario 1 post 2", Visibilidad.Publico));

            post2.AgregarComentario(
                new Comentario("Titulo comentario 5 ", RetornaMiembroPorMail("facupelu26@gmail.com"), DateTime.Now, "Contenido comentario 2 post 2", Visibilidad.Publico));

            post2.AgregarComentario(
                new Comentario("Titulo comentario 6", RetornaMiembroPorMail("matheus.caique21@gmail.com"), DateTime.Now, "Contenido comentario 3 post 2", Visibilidad.Publico));




            Post post3 = (new Post("Post 3", RetornaMiembroPorMail("susan.wilson@gmail.com"), DateTime.Now, "Contenido post 3", Visibilidad.Publico, "imagenPost3.jpg", false));
            post3.AgregarComentario(
                new Comentario("Titulo comentario 1", RetornaMiembroPorMail("kevin.martin@gmail.com"), DateTime.Now, "Contenido comentario 1 post 3", Visibilidad.Publico));
            post3.AgregarComentario(
                new Comentario("Titulo comentario 2", RetornaMiembroPorMail("janedoe@gmail.com"), DateTime.Now, "Contenido comentario 2 post 3", Visibilidad.Publico));
            post3.AgregarComentario(
                new Comentario("Titulo comentario 3", RetornaMiembroPorMail("matheus.caique21@gmail.com"), DateTime.Now, "Contenido comentario 3 post 3", Visibilidad.Publico));



            Post post4 = (new Post("Post 4", RetornaMiembroPorMail("facupelu26@gmail.com"), DateTime.Now, "Contenido post 4", Visibilidad.Publico, "imagenPost4.jpg", false));
            post4.AgregarComentario(
                new Comentario("Titulo comentario 1", RetornaMiembroPorMail("kevin.martin@gmail.com"), DateTime.Now, "Contenido comentario 1 post 4", Visibilidad.Publico));
            post4.AgregarComentario(
                new Comentario("Titulo comentario 2", RetornaMiembroPorMail("matheus.caique21@gmail.com"), DateTime.Now, "Contenido comentario 2 post 4", Visibilidad.Publico));
            post4.AgregarComentario(
                new Comentario("Titulo comentario 3", RetornaMiembroPorMail("matheus.caique21@gmail.com"), DateTime.Now, "Contenido comentario 3 post 4", Visibilidad.Publico));



            Post post5 = (new Post("Post 5", RetornaMiembroPorMail("facupelu26@gmail.com"), DateTime.Now, "Contenido post 4", Visibilidad.Publico, "imagenPost5.jpg", false));
            post5.AgregarComentario(
                new Comentario("Titulo comentario 1", RetornaMiembroPorMail("kevin.martin@gmail.com"), DateTime.Now, "Contenido comentario 1 post 5", Visibilidad.Publico));
            post5.AgregarComentario(
                new Comentario("Titulo comentario 2", RetornaMiembroPorMail("matheus.caique21@gmail.com"), DateTime.Now, "Contenido comentario 2 post 5", Visibilidad.Publico));
            post5.AgregarComentario(
                new Comentario("Titulo comentario 3", RetornaMiembroPorMail("matheus.caique21@gmail.com"), DateTime.Now, "Contenido comentario 3 post 5", Visibilidad.Publico));
            post5.AgregarComentario(
                new Comentario("Titulo comentario 5 ", RetornaMiembroPorMail("facupelu26@gmail.com"), DateTime.Now, "Contenido comentario 2 post 2", Visibilidad.Publico));
            post5.AgregarComentario(
                new Comentario("Titulo comentario 5 ", RetornaMiembroPorMail("facupelu26@gmail.com"), DateTime.Now, "Contenido comentario 2 post 2", Visibilidad.Publico));

            AltaPost(post1);
            AltaPost(post2);
            AltaPost(post3);
            AltaPost(post4);
            AltaPost(post5);

        }




        public bool HayReaccionPost(int id, string email)
        // Para validar que no haya una reaccion del miembro que quiere reaccionar en el POST
        {

            Miembro m = RetornaMiembroPorMail(email);
            Post publi = RetornaPostPorId(id);
            bool hayReaccion = false;

            foreach (Reaccion r in publi.ListaReaccion)
            {
                if (r.MiembroReacciono.Email == email)
                {
                    hayReaccion = true;
                    throw new Exception("Ya hay una reaccion de esta persona");
                }
                else
                {
                    hayReaccion = false;
                }
            }

            return hayReaccion;

        }

        public bool HayReaccionComentario(int id, string email)
        // Para validar que no haya una reaccion del miembro que quiere reaccionar
        {
            Miembro m = RetornaMiembroPorMail(email);
            Comentario comen = RetornaComentariosPorId(id);
            bool hayReaccion = false;

            foreach (Reaccion r in comen.ListaReaccion)
            {
                if (r.MiembroReacciono.Email == m.Email)
                {
                    hayReaccion = true;
                    throw new Exception("Ya hay una reaccion de esta persona");
                }
                else
                {
                    hayReaccion = false;

                }

            }

            return hayReaccion;

        }




        public void AltaPost(Post post)
        {
            if (post == null) throw new Exception("Post no puede ser nulo!");
            if (_listaPosts.Contains(post)) throw new Exception("Ya existe un post en la lista!");
            post.Validar();
            _listaPosts.Add(post);

        }


        public void AltaAdm(Administrador adm)
        {
            //if (adm == null) throw new Exception("Adm recibido por parametro no es válido!");
            adm.Validar();
            //if (_listaUsuarios.Contains(adm)) throw new Exception("Ya existe un adm con este email!");
            _listaUsuarios.Add(adm);
        }


        public void AltaMiembro(Miembro miembro) // Menu 1
        {
            if (miembro == null) throw new Exception("Miembro recibido por parametro no es válido!");
            miembro.Validar();
            if (_listaUsuarios.Contains(miembro)) throw new Exception("Ya existe un miembro con este email!");
            _listaUsuarios.Add(miembro);

        }

        public void AltaInvitacion(Invitacion invitacion)
        {
            if (invitacion == null) throw new Exception("Invitación recibida por parametro!");
            //if(_listaInvitaciones.Contains(invitacion)) throw new Exception("Invitación ya enviada!");
            invitacion.Validar();
            if (HayInvitacion(invitacion)) throw new Exception("Ya hay una invitacion");
            _listaInvitaciones.Add(invitacion);
        }

        public void AceptarInvitacion(int Idinvitacion, string emailAprobador)
        {
            if (Idinvitacion < 0) throw new Exception("El id de la invitación pasado por parametro no es válido!");
            Invitacion invitacionBuscado = RetornaIdInv(Idinvitacion);
            if (invitacionBuscado == null) throw new Exception("La invitación no puede ser nula!");

            //
            Miembro m1 = RetornaMiembroPorMail(emailAprobador);

            invitacionBuscado.AceptarSolicitud(m1);

        }

        public void AltaComentario(Comentario coment, int idPost)
        {
            if (coment == null) throw new Exception("El comentario no puede ser nulo");
            if (idPost < 0) throw new Exception("Id de post no puede ser menor a 0!");
            coment.Validar();
            Post postBuscado = RetornaPostPorId(idPost);

            postBuscado.AgregarComentario(coment);


        }


        public Invitacion RetornaIdInv(int id)
        {
            Invitacion invBuscada = null;
            foreach (Invitacion inv in _listaInvitaciones)
            {
                if (inv.IdInv == id)
                {
                    invBuscada = inv;
                }
            }
            return invBuscada;
        }





        public void BloquearMiembro(Administrador adm, Miembro miem) // Bloquear miembro
        {
            adm.BloquearMiembro(miem); // BloquearMiembro está en Adminiestrador.
        }




        public void RechazarInvitacion(int Idinvitacion)
        {
            if (Idinvitacion < 0) throw new Exception("El id de la invitación pasado por parametro no es válido!");
            Invitacion invitacionBuscado = RetornaIdInv(Idinvitacion);
            if (invitacionBuscado == null) throw new Exception("La invitación no puede ser nula!");
            invitacionBuscado.Validar();
            invitacionBuscado.RechazarInvitacion();
        }





        public Miembro BuscarMiembro(Miembro miembro)
        {
            Miembro miembroBuscado = null;

            foreach (Miembro miem in _listaUsuarios)
            {
                if (miem.Email == miembro.Email)
                {
                    miembroBuscado = miem;
                }
            }

            return miembroBuscado;
        }



        //public Miembro RetornaMiembroPorMail(string email) // retorna un miembro
        //{
        //    Miembro miembroBuscado = null;

        //    foreach (Miembro miem in _listaUsuarios)
        //    {
        //        if (miem.Email == email)
        //        {
        //            miembroBuscado = miem;
        //        }
        //    }

        //    return miembroBuscado;
        //}

        public Miembro RetornaMiembroPorMail(string email) // Editar en el DIAGRAMA! 
        {
            Miembro miembroBuscado = null;
            int i = 0;

            while (miembroBuscado == null && i < _listaUsuarios.Count)
            {
                User usuario = _listaUsuarios[i];

                if (usuario is Miembro miem && miem.Email == email) // Casteo para poder iterar sobre la lista de Usuario
                {
                    miembroBuscado = miem;
                }

                i++;
            }

            return miembroBuscado;
        }


        public Administrador RetornaAdmPorMail(string email) // Editar en el DIAGRAMA! 
        {
            Administrador admBuscado = null;
            int i = 0;

            while (admBuscado == null && i < _listaUsuarios.Count)
            {
                User usuario = _listaUsuarios[i];

                if (usuario is Administrador adm && adm.Email == email) // Casteo para poder iterar sobre la lista de Usuario
                {
                   admBuscado = adm;
                }

                i++;
            }

            return admBuscado;
        }




        public Comentario RetornaComentariosPorId(int id)
        // retorna Comentario buscado en la lista de comentarios de un post
        {
            Comentario comentarioBuscado = null;

            foreach (Post pub in _listaPosts)
            {
                foreach (Comentario comen in pub.ListaComentario)
                {
                    if (comen.IdPubli == id) comentarioBuscado = comen;
                }

            }

            return comentarioBuscado;

        }


        // PARA EL POST

        public Post RetornaPostPorId(int id) // retorna Posts
        {
            Post publiBuscada = null;

            foreach (Post pub in _listaPosts)
            {
                if (pub.IdPubli == id)
                {
                    publiBuscada = pub;
                }
            }

            return publiBuscada;

        }

        public List<Publicacion> RetornaPublicaciones(string email) // Menu 2
        {
            Miembro miembroBuscado = RetornaMiembroPorMail(email);
            if (miembroBuscado == null) throw new Exception("Miembro no existe en la lista de usuarios!");


            List<Publicacion> listaFinal = new List<Publicacion>();

            foreach (Post post in _listaPosts)
            {

                if (post.AutorPubli.Email == email)
                {
                    listaFinal.Add(post);
                }

                listaFinal.AddRange(post.BuscarComentariosMiembro(email));



            }

            return listaFinal;
        }




        public List<Post> RetornaPostsConComentariosDeMiembro(string email) // Menu 3
        {
            if (RetornaMiembroPorMail(email) == null) throw new Exception("Miembro no existe!"); // Validación exite miembro o no (utilizando método auxiliar para buscar el miembro en la lista).

            List<Post> postsConComentarios = new List<Post>();



            foreach (Post post in _listaPosts)
            {
                if (post.HayComentarioDelMiemibro(email)) postsConComentarios.Add(post);
            }


            // if (postsConComentarios.Count == 0) throw new Exception("no hay registros!");

            return postsConComentarios;
        }


        public List<Publicacion> RetornaListaPostFechas(DateTime fechaInic, DateTime fechaFinal) // Menu 4
        {
            if (fechaInic == null || fechaFinal == null) throw new Exception("Fecha no válida!");

            List<Publicacion> listaAuxPost = new List<Publicacion>();

            foreach (Publicacion publi in _listaPosts)
            {
                if (publi is Post)
                {

                    Post post = ((Post)publi); // casteando


                    if (post.fechaPubli.Date >= fechaInic.Date && post.fechaPubli.Date <= fechaFinal.Date) // Utilizando DateTime.Date para implementar la condición de las fechas.
                    {
                        listaAuxPost.Add(post);

                    }
                }
            }

            if (listaAuxPost.Count == 0) throw new Exception("no hay registros!");
            listaAuxPost.Sort();

            return listaAuxPost;
        }


        public int RetornaCantidadPostPorMiembro(string email) // Método auxiliar para RetornaMiembrosConMasPublicaciones
        {
            int contador = 0;

            foreach (Publicacion pub in _listaPosts)
            {
                if (pub.AutorPubli.Email == email)
                {
                    contador++;
                }

                if (pub is Post)
                {

                    Post post = ((Post)pub);

                    foreach (Comentario comen in post.ListaComentario) // casteando acá // Iterando sobre la lista de comentario del post.
                    {
                        if (comen.AutorPubli.Email == email)
                        {
                            contador++;
                        }
                    }
                }
            }

            return contador;

        }



        public List<Miembro> RetornaMiembrosConMasPublicaciones() // Menu 5
        {
            List<Miembro> miembrosConMasPublicaciones = new List<Miembro>();
            int maximoPublicaciones = int.MinValue;

            foreach (Miembro miembro in _listaUsuarios)
            {
                int totalPublicaciones = RetornaCantidadPostPorMiembro(miembro.Email);


                if (totalPublicaciones > maximoPublicaciones)
                {

                    maximoPublicaciones = totalPublicaciones;
                    miembrosConMasPublicaciones.Clear();
                    miembrosConMasPublicaciones.Add(miembro);
                }
                else if (totalPublicaciones == maximoPublicaciones)
                {
                    miembrosConMasPublicaciones.Add(miembro);
                }
            }
            if (miembrosConMasPublicaciones.Count <= 0) throw new Exception("No hay registros!");

            return miembrosConMasPublicaciones;
        }


        public List<Miembro> RetornaListaAmigos(Miembro m)
        {
            List<Miembro> listaAmigos = new List<Miembro>();
            Miembro miembroBuscado = null;

            foreach (Miembro miem in ListaUsers)
            {
                if (m.Email == miem.Email)
                {
                    miembroBuscado = miem;
                }
            }

            foreach (Miembro miembroFound in miembroBuscado.ListaAmigos)
            {
                listaAmigos.Add(miembroFound);
            }

            return listaAmigos;
        }


        public List<Reaccion> ListarReacciones()
        {
            List<Reaccion> lista = new List<Reaccion>();

            foreach (Post post in _listaPosts)
            {
                foreach (Reaccion reac in post.ListaReaccion)
                {
                    lista.Add(reac);
                }

                foreach (Comentario c in post.ListaComentario)
                {
                    foreach (Reaccion r in c.ListaReaccion)
                    {
                        lista.Add(r);
                    }
                }
            }
            return lista;
        }


        public User Login(string email, string pass)  // Actualizar en el diagrama
        {
            User usuario = null;
            int i = 0;
            while (usuario == null && i < _listaUsuarios.Count)
            {
                if (_listaUsuarios[i].Email == email && _listaUsuarios[i].Contrasena == pass) usuario = _listaUsuarios[i];
                i++;
            }

            return usuario;
        }

        public bool HayLikeMiembro(Miembro m, Publicacion p) // Actualizar en el diagrama
        {
            bool flag = false;
           
                foreach (Reaccion reac in p.ListaReaccion) 
                {
                    if(reac.MiembroReacciono.Email == m.Email && reac.Tipo == ReaccionEnum.like)
                    {
                        flag = true;
                    }
                }
            

            return flag;
        }


        public bool HayDislikeMiembro(Miembro m, Publicacion p) // Actualizar en el diagrama
        {
            bool flag = false;

            foreach (Reaccion reac in p.ListaReaccion)
            {
                if (reac.MiembroReacciono.Email == m.Email && reac.Tipo == ReaccionEnum.dislike)
                {
                    flag = true;
                }
            }


            return flag;
        }


        public List<Publicacion> retornaPostsConTexto(string texto, double numero)
        {
            List<Publicacion> listaAux = new List<Publicacion>();

            foreach (Post p in _listaPosts)
            {
                if(p.Contenido.Contains(texto) && p.CalcularVA() > numero)
                {
                    listaAux.Add(p);
                }

                foreach (Comentario c  in p.ListaComentario)
                {
                    if(c.Contenido.Contains(texto) && c.CalcularVA() > numero)
                    {
                        listaAux.Add(c);
                    }
                }
            }

            return listaAux;
        }

        public List<Miembro> RetornaSoloMiembros() // Actualizar el diagrama
        {
            List<Miembro> miembros = new List<Miembro>();

            foreach (User u in _listaUsuarios )
            {
                if(u is Miembro miem)
                {
                    miembros.Add(miem);
                }
               
            }

            return miembros;
        }


        public List<Invitacion> RetornaInvitacionesPendientesMiembro(string email)
        {
            List<Invitacion> listAux = new List<Invitacion>();

            foreach (Invitacion inv in _listaInvitaciones)
            {
                if(inv.MiembroSolicitado.Email == email)
                {
                    listAux.Add(inv);
                }
            }

            return listAux;
        }


       public bool HayInvitacion(Invitacion inv)
        {
            bool hay = false; // flag 

            foreach (Invitacion i in ListaInvitaciones)
            {

                if (inv.MiembroSolicitante.Equals(i.MiembroSolicitante) && inv.MiembroSolicitado.Equals(i.MiembroSolicitado) && (i.Status == Status.APROBADA || i.Status == Status.PENDIENTE_APROBACION)) hay = true;
                // i.Status.PENDIENTE_APROBACION
            }

            return hay;

        }


        public List<User> retornaUsuarioConTexto(string texto)
        {
            List<User> listaAux = new List<User>();

            foreach (User u in _listaUsuarios)
            {
                if (u.Email.Contains(texto))
                {
                    listaAux.Add(u);
                }

            }

            return listaAux;

        }




    }
}
