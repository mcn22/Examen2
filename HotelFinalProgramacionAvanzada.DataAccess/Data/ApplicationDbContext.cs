using HotelFinalProgramacionAvanzada.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinalProgramacionAvanzada.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        } 
        public DbSet<Hotel> Hoteles { get; set; }   

        public DbSet<Usuario> Usuarios { get; set; }

    }
}
