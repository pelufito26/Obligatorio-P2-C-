using System;
namespace Dominio
{
	public class Post: Publicacion
	{
		private string _imagenPost;
		private List<Comentario> _listaComentarios = new List<Comentario>();
		private bool _esCensurado;


		public Post(string tituloPubli, Miembro autor, DateTime fechaPubli, string contenido, Visibilidad visibilidad, string imagen, bool censurado) : base(tituloPubli, autor, fechaPubli, contenido, visibilidad)
		{
			_imagenPost = imagen;
			_esCensurado = censurado;
		}

		public List<Comentario> ListaComentario
		{
			get { return _listaComentarios; }
		}

        public override void Validar()
        {
            base.Validar();
            if (this._esCensurado != true && this._esCensurado != false) throw new Exception("Censura tiene que ser true o false");
            if (string.IsNullOrEmpty(this._imagenPost)) throw new Exception("Nombre de la imagen no puede estar vacia!");
            string ultimosCuatroCaracteres = this._imagenPost.Substring(this._imagenPost.Length - 4);
            string ultimosCuatroCaracteresUpper = ultimosCuatroCaracteres.ToUpper();
            if (ultimosCuatroCaracteresUpper != ".PNG" && ultimosCuatroCaracteresUpper != ".JPG")
            {
                throw new Exception("Imagen del post tiene que ser .png o .jpg");
            }
        }

        public bool Censurado
        {
            get { return  _esCensurado; }
        }

        public string Imagen
        {
            get { return _imagenPost; }
            set { _imagenPost = value; }
        }

        public Visibilidad Visibilidad
        {
            get { return _visibilidad; }
        }

        private void ValidarImagen() // Atualizar el diagrama
        {
            if (!_imagenPost.EndsWith(".png") && !_imagenPost.EndsWith(".JPG")) throw new Exception("Extension inválida!");
        }

        public override double CalcularVA()
        {
            double valorFinal = base.CalcularVA();

            if (this._visibilidad == Visibilidad.Publico)
            {
                valorFinal += 10;
            }

            return valorFinal;

        }


        public override string ToString()  //this.Contenido.Substring(0, 49);
        {
            if (this.Contenido.Length > 50)
            {
                string maxContenido = string.Empty;


                int i = 0;
                while (i < 50)
                {
                    maxContenido += this.Contenido[i];
                    i++;
                }

                this.Contenido = maxContenido;

            }

            return $"POST:\n ID:  {this.IdPubli} - Fecha Post:{this.fechaPubli} -  Titulo: {this.TituloPubli} - Contenido: {this.Contenido}.";

        }

        public void AgregarComentario(Comentario coment)
        {
            if (_visibilidad == Visibilidad.Privado)
            {
                coment.visibilidadComentario = Visibilidad.Privado;
            }


            if (_visibilidad == Visibilidad.Publico)
            {
                coment.visibilidadComentario = Visibilidad.Publico;
            }

            _listaComentarios.Add(coment);
        }

        public void CambiaCensura()
        {
            _esCensurado = true;
        }

        public void CambiaCensuraFalse() // Atualizar en el diagrama
        {
            _esCensurado = false;
        }



        public void AgregarReaccionAPost(Reaccion reaccion)
        {
            _listaReacciones.Add(reaccion);

        }

      

        public List<Comentario> BuscarComentariosMiembro(string email)
        {
            List<Comentario> listaAuxComentariosMiembro = new List<Comentario>();
            foreach (Comentario com in _listaComentarios)
            {
                if (com.AutorPubli.Email == email)
                {
                    listaAuxComentariosMiembro.Add(com);
                }
            }

            return listaAuxComentariosMiembro;
        }


        public bool HayComentarioDelMiemibro(string email)
        {
            bool hayComent = false;
            foreach(Comentario com in ListaComentario)
            {
                if (com.Autor.Email == email) hayComent = true;
            }

            return hayComent;
        }

        public override string tipoPublicacion()
        {
            return "Post";
        }
    }


}


