using System;
using Dominio.Interface;

namespace Dominio
{
    public abstract class Publicacion : Ivalidable, IComparable<Publicacion>
    {

        private static int s_idPubli = 1;
        private int _idPubli;
        private string _tituloPubli;
        private Miembro _autorPubli;
        private DateTime _fechaPubli;
        private string _contenido;
        protected Visibilidad _visibilidad;
        protected List<Reaccion> _listaReacciones = new List<Reaccion>();

        public Publicacion(string tituloPubli, Miembro autor, DateTime fechaPubli, string contenido, Visibilidad visibilidad)
        {
            _idPubli = s_idPubli; 
            _tituloPubli = tituloPubli;
            _autorPubli = autor;
            _fechaPubli = fechaPubli;
            _contenido = contenido;
            _visibilidad = visibilidad;
            s_idPubli++;
           
        }

        public Miembro AutorPubli
        {
            get { return _autorPubli; }
        }

        public string Contenido
        {
            get { return _contenido; }
            set { _contenido = value; }
        }
        public int IdPubli
        {
            get { return _idPubli; }
        }

        public Miembro Autor
        {
            get { return _autorPubli; }
        }

        public DateTime fechaPubli
        {
            get { return _fechaPubli; }
        }

        public string TituloPubli
        {
            get { return _tituloPubli; }
        }

        public List<Reaccion> ListaReaccion
        {
            get { return _listaReacciones; }
        }
       

        public virtual void Validar()
        {
            if (_visibilidad == null) throw new Exception("Visibilidad no puede ser nula!");
            if (_idPubli < 0) throw new Exception("El id de la publicación no puede ser menor a 0!");
            if (string.IsNullOrEmpty(_tituloPubli)) throw new Exception("Titulo inválido!");
            if (string.IsNullOrEmpty(_contenido)) throw new Exception("El contenido no puede ser vacio!");
            if (_autorPubli == null) throw new Exception("Autor no puede ser nulo!");
         

        }





        public virtual double CalcularVA()
        {

            double contadorLike = 0;
            double contadorDislike = 0;
            double valorFinal;

            foreach (Reaccion reac in _listaReacciones)
            {
                if (reac.Tipo == ReaccionEnum.like)
                {
                    contadorLike++;
                }
            }

            foreach (Reaccion reac in _listaReacciones)
            {
                if (reac.Tipo == ReaccionEnum.dislike)
                {
                    contadorDislike++;
                }
            }

            valorFinal = (contadorLike * 5) + (contadorDislike * -2);

           

            return valorFinal;
        }



        public int CompareTo(Publicacion? other) // Utilizar en Post para ordenar la lista en forma descendente.
        {
            return _tituloPubli.CompareTo(other.TituloPubli) * - 1;

        
        }


        public override string ToString()
        {
            return $"id post: {_idPubli} - Titulo: {_tituloPubli}";
        }

        public override bool Equals(object? obj)
        {
            Publicacion pub = obj as Publicacion;
            return pub != null && this.IdPubli.Equals(pub.IdPubli);
        }

        public int CantidadLikes() // Actualizar en el diagrama
        {
            int contador = 0;
            foreach (Reaccion r in _listaReacciones)
            {
                if(r.Tipo == ReaccionEnum.like)
                {
                    contador++;
                }
            }

            return contador;
        }

        public int CantidadDislikes() // Actualizar en el diagrama
        {
            int contador = 0;
            foreach (Reaccion r in _listaReacciones)
            {
                if (r.Tipo == ReaccionEnum.dislike)
                {
                    contador++;
                }
            }

            return contador;
        }

        public abstract string tipoPublicacion();  // Actualizar en el diagrama
    }
}
