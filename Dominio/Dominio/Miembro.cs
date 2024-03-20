using System;
namespace Dominio
{
	public class Miembro : User, IComparable<Miembro> // Atualizar en el Diagrama
    {
		private string _nombre;
		private string _apellido;
		private DateTime _fechaNacimiento;
		private bool _status;
		private List<Miembro> _listaAmigos = new List<Miembro>();

		public Miembro(string email, string contrasena, string nombre, string apellido, DateTime fechaNacimiento, bool status) : base(email, contrasena)
		{
			_nombre = nombre;
			_apellido = apellido;
			_fechaNacimiento = fechaNacimiento;
			_status = status;
		}

		public bool Status
		{
			get { return _status; }
			set { _status = value; }

		}
		public List<Miembro> ListaAmigos
		{
			get { return _listaAmigos; }
		}

		public string Nombre
		{
			get { return _nombre; }
		}


		public string Apellido
		{
			get { return _apellido; }
		}


		public DateTime FechaN
		{
			get { return _fechaNacimiento; }
		}

		public override void Validar()
		{
			base.Validar();
			if (string.IsNullOrEmpty(_nombre)) throw new Exception("El nombre no puede ser vacio");
			if (string.IsNullOrEmpty(_apellido)) throw new Exception("El apellido no puede ser vacio");

		}

		public void AgregarMiembro(Miembro miembro)
		{
			_listaAmigos.Add(miembro);
		}

		public override bool Equals(object? obj)
		{
			Miembro miembro = obj as Miembro;
			return miembro != null && this.Email.Equals(miembro.Email);
		}

		public override string ToString()
		{
			return $" Nombre: {_nombre} - Apellido: {_apellido} - Fecha de Nacimiento: {_fechaNacimiento.ToString("dd/MM/yyyy")} - Status: {_status}. ";
		}

		public override string Tipo()
		{
			return "Miembro";

		}

        public int CompareTo(Miembro m)
        {
            // Primero comparamos con el nombre

            int nombreComparacion = _apellido.CompareTo(m.Apellido);
            if (nombreComparacion != 0)
            {
                return nombreComparacion;
            }

            // Si los nombres son iguales, entonces comparamos por el apellido
            return _nombre.CompareTo(m.Nombre);
        }



        public bool EsAmigo(string emailAmigo) // Actualizar en el diagrama
        {
           
            bool resultado = false;

            foreach (Miembro miem in _listaAmigos)
            {
                if (miem.Email == emailAmigo)
                {
                    resultado = true;
                }
            }


            return resultado;
        }



    }
}

