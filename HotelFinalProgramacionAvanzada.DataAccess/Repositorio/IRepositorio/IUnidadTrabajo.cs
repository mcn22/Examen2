using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinalProgramacionAvanzada.DataAccess.Repositorio.IRepositorio
{
    public interface IUnidadTrabajo : IDisposable
    {
        IHotelRepositorio Hoteles { get;}
        IUsuarioRepositorio Usuarios { get;}

        void Guardar();
    }
}
