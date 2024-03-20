using System;
namespace Dominio
{
	public class Administrador: User
	{
		//private List<Miembro> _listaMiembrosAdm = new List<Miembro>();

		public Administrador(string email, string contrasena):base(email, contrasena)
		{
		
		}

        public override void Validar()
        {
            base.Validar();
           

        }

        public void BloquearMiembro(Miembro miem)
		{	if (miem == null) throw new Exception("Miembro no puede ser nulo!");
            miem.Validar();
            miem.Status = false;
		}

        public void desBloquearMiembro(Miembro miem) // Atualizar en el diagrama 
        {
            if (miem == null) throw new Exception("Miembro no puede ser nulo!");
            miem.Validar();
            miem.Status = true;
        }

        public void CensuraPost(Post post)
		{
            if (post == null) throw new Exception("Post no puede ser nulo!");
			post.Validar();
			post.CambiaCensura();
            // Parecido con el método BloquearMiembro
        }

        public void DesbloquearPost(Post post)
        {
            if (post == null) throw new Exception("Post no puede ser nulo!");
            post.Validar();
            post.CambiaCensuraFalse();
            // Parecido con el método BloquearMiembro
        }

        public override string ToString()
        {
			return $"ADM: mail - {this.Email}";

		}

        public override string Tipo()
        {
            return "Administrador";

        }
    }

}

