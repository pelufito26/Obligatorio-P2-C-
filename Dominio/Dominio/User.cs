using System;
using Dominio.Interface;

namespace Dominio
{
	public abstract class User: Ivalidable
	{
		private string _email;
		private string _contrasena;

		public User(string email, string contrasena)
		{
			_email = email;
			_contrasena = contrasena;
		}

		public string Email
		{
			get { return _email; }
		}


        public string Contrasena
        {
            get { return _contrasena; }
        }

        public virtual void Validar()
		{
			if (string.IsNullOrEmpty(_email)) throw new Exception("Email no puede ser nulo o vacio!");
			if (string.IsNullOrEmpty(_contrasena)) throw new Exception("Contraseña no puede ser nula o vacia!");

		}

		public abstract string Tipo();



		
	}
}

