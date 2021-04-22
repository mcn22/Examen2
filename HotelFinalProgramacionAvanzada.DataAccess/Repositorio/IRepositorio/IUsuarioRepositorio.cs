using HotelFinalProgramacionAvanzada.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinalProgramacionAvanzada.DataAccess.Repositorio.IRepositorio
{
    public interface IUsuarioRepositorio : IRepositorio<Usuario>
    {
        void Actualizar(Usuario usuario);
    }
}
