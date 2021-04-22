using HotelFinalProgramacionAvanzada.DataAccess.Data;
using HotelFinalProgramacionAvanzada.DataAccess.Repositorio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinalProgramacionAvanzada.DataAccess.Repositorio
{
    public class UnidadTrabajo : IUnidadTrabajo
    {
        public UnidadTrabajo(ApplicationDbContext db)
        {
            _db = db;

            Hoteles = new HotelRepositorio(db);
            Usuarios = new UsuarioRepositorio(db);
        }

        readonly ApplicationDbContext _db;

        public IHotelRepositorio Hoteles { get; private set; }
        public IUsuarioRepositorio Usuarios { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Guardar()
        {
            _db.SaveChanges();
        }
    }
}

