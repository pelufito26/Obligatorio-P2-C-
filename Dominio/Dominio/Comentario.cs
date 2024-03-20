using System;
namespace Dominio
{
	public class Comentario: Publicacion
	{
        
        public Comentario(string tituloPubli, Miembro autorPubli, DateTime fechaPubli, string contenido, Visibilidad visibilidad) : base(tituloPubli, autorPubli ,fechaPubli, contenido, visibilidad)
		{

		}

        public Visibilidad Visibilidad
        {
            get { return _visibilidad; }
        }

       


        public Visibilidad visibilidadComentario
        {
            set { _visibilidad = value; }
        }

        public override void Validar()
        {
            base.Validar();
        }


        public void AgregarReaccionAComent(Reaccion reaccion)
        {
            _listaReacciones.Add(reaccion);
        }


        public override string ToString()
        {
            return $"COMENTARIO:\n ID:  {this.IdPubli} - Fecha Post:{this.fechaPubli} -  Titulo: {this.TituloPubli} - Contenido: {this.Contenido}.";
        }

        public override double CalcularVA()
        {
           return base.CalcularVA();
           

        }

        public override string tipoPublicacion()  // Actualizar en el diagrama
        {
            return "Comentario";
        }
    }
}

