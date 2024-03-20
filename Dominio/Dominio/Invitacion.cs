using System;
using Dominio.Interface;

namespace Dominio
{
	public class Invitacion: Ivalidable
	{

		private int _idInv;
		private Miembro _miembroSolicitante;
		private Miembro _miembroSolicitado;
		private Status _estadoSolicitud;
		private DateTime _fechaSolicitud;

		public Invitacion(int id, Miembro miebroSolicitante, Miembro miembroSolicitado)
		{
			_idInv = id;
			_miembroSolicitante = miebroSolicitante;
			_miembroSolicitado = miembroSolicitado;
			_estadoSolicitud = Status.PENDIENTE_APROBACION;// ? En la precarga
			_fechaSolicitud = DateTime.Now;

        }
		public Miembro MiembroSolicitante
		{
			get { return _miembroSolicitante; }
		}

        public Miembro MiembroSolicitado
        {
            get { return _miembroSolicitado; }
        }

        public int IdInv
        {
            get { return _idInv; }
        }

        public Status Status
        {
            get { return _estadoSolicitud; }
        }

        public void Validar()
        {
            if (_idInv < 0) throw new Exception("Id no puede ser menor a O!");
            if (_miembroSolicitante.Status != false && _miembroSolicitado.Status != false)
            {
                if (_estadoSolicitud == Status.RECHAZADA || _estadoSolicitud == Status.APROBADA) throw new Exception("El estado de la solicitud no es válido!");
                if (!(_fechaSolicitud is DateTime)) throw new Exception("La fecha de solicitud no es de tipo DateTime.");
            }
            else
            {
                throw new Exception("Miembro censurado!"); // controlamos que el status del miembro
            }


        }




        public void AceptarSolicitud(Miembro solicitado)
		{
			if (solicitado == null) throw new Exception("Solicitado no puede ser nulo!");
			if (solicitado.Email != _miembroSolicitado.Email) throw new Exception("No le corresponde a este usuario aceptar");
			if(solicitado.Status == false) throw new Exception("El solicitante se encuentra bloqueado");

			solicitado.AgregarMiembro(_miembroSolicitante);
			_miembroSolicitante.AgregarMiembro(solicitado);

            //solicitante.AgregarAmigo(solicitado); // Hace referencia al método AgregarAmigo -- > Miembro.
            this._estadoSolicitud = Status.APROBADA;

			
		}



		public void RechazarInvitacion()
		{
			this._estadoSolicitud = Status.RECHAZADA;
		}

        public override bool Equals(object? obj)
        {
			Invitacion inv = obj as Invitacion;
			return inv != null && this._idInv.Equals(inv._idInv);
        }

        public override string ToString()
        {
			return $"Id: {_idInv} - Miembro Solicitado: {_miembroSolicitado} - Miembro Solicitante: {_miembroSolicitante} - Fecha: {_fechaSolicitud} - Estado: {_estadoSolicitud}.";

        }
    }
}

