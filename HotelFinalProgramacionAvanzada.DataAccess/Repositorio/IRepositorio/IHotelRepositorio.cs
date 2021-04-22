using HotelFinalProgramacionAvanzada.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinalProgramacionAvanzada.DataAccess.Repositorio.IRepositorio
{
    public interface IHotelRepositorio : IRepositorio<Hotel>
    {
        void Actualizar(Hotel hotel);
    }
}
