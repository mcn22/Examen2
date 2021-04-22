using HotelFinalProgramacionAvanzada.DataAccess.Data;
using HotelFinalProgramacionAvanzada.DataAccess.Repositorio;
using HotelFinalProgramacionAvanzada.DataAccess.Repositorio.IRepositorio;
using HotelFinalProgramacionAvanzada.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelFinalProgramacionAvanzada.DataAccess.Repositorio
{
    public class HotelRepositorio : Repositorio<Hotel>, IHotelRepositorio
    {
        public HotelRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        readonly ApplicationDbContext _db;

        public void Actualizar(Hotel hotel)
        {
            var l = _db.Hoteles.FirstOrDefault(s => s.HotelId == hotel.HotelId);

            if (l == null)
                return;

            l.Nombre = hotel.Nombre;
            l.Descripcion = hotel.Descripcion;
            l.UrlImagen = hotel.UrlImagen;
            l.Direccion = hotel.Direccion;
            l.Ciudad = hotel.Ciudad;
            l.Telefono = hotel.Telefono;
        }
    }
}
