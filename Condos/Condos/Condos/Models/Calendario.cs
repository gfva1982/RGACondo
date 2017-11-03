using System;

namespace Condos.Models
{
    public class Calendario
    {
        public Int64 ZonaPublicaID { get; set; }

        public int InmuebleID { get; set; }

        public DateTime Fecha { get; set; }

        public DateTime HoraInicio { get; set; }

        public DateTime HoraFinal { get; set; }

        public string Comentarios { get; set; }

        public int Estado { get; set; }

        public int UsuarioID { get; set; }

        public string FechaReservacion => string.Format("Fecha: {0}/{1}/{2}", Fecha.Day, Fecha.Month, Fecha.Year);

        public string HoraInicioReservacion => string.Format("Hora Inicio: {0}:{1}", HoraInicio.Hour, HoraInicio.Minute.ToString()== "0"?"00":HoraInicio.Minute.ToString());

        public string HoraFinalReservacion => string.Format("Hora Final: {0}:{1}", HoraFinal.Hour, HoraFinal.Minute.ToString() == "0" ? "00" : HoraFinal.Minute.ToString());

        public string EstadoReserva
        {
           get
            {
                switch (Estado)
                {
                    case 1 :
                        return "Estado: Pendiente De Confirmacion";


                    case 2:
                        return "Estado: Reservado";
                       
                    case 3:
                        return "Estado: En Mantenimiento";

                    default:
                        return "Estado: Reservado";
                       
                }

            }
        }

    }

}

