using System;
using Dominio.Interface;

namespace Dominio
{
	public class Reaccion: Ivalidable // El miembro que reacciono a una publicacion, tiene que estar en el constructor?
	{
		private ReaccionEnum _tipo;
		private Miembro _miembroReaccion;

		public ReaccionEnum Tipo
		{
			get { return _tipo; }
		}

		public Miembro MiembroReacciono
		{
			get { return _miembroReaccion; }
		}

		public Reaccion(ReaccionEnum tipo, Miembro miembro)
		{
			_tipo = tipo;
			_miembroReaccion = miembro;
		}

		public void Validar()
		{
			//?
		}

        public override string ToString()
        {
			return $"Tipo {_tipo} - Miembro: {_miembroReaccion}";
        }
    }
}

