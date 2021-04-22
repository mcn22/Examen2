using HotelFinalProgramacionAvanzada.Models;
using HotelFinalProgramacionAvanzada.Utility;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFinalProgramacionAvanzada
{
    public static class Setup
    {

        public static async Task<bool> InitAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var RoleManager = roleManager;
            var UserManager = userManager;

            if (!await RoleManager.RoleExistsAsync(SD.Roles.Administrador))
            {   
                await RoleManager.CreateAsync(new IdentityRole(SD.Roles.Administrador));              
            }
            if (!await RoleManager.RoleExistsAsync(SD.Roles.Empleado))
            {
                await RoleManager.CreateAsync(new IdentityRole(SD.Roles.Empleado));
            }
            if (!await RoleManager.RoleExistsAsync(SD.Roles.Simple))
            {
                await RoleManager.CreateAsync(new IdentityRole(SD.Roles.Simple));
            }         
            var user =
                new Usuario
                {
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com",
                    Nombre = "admin",
                    PhoneNumber = "12345",
                };
            if (!UserManager.Users.Select(u => u.Email == u.Email).FirstOrDefault())
            {
                await UserManager.CreateAsync(user, "Admin-2020");
                await UserManager.AddToRoleAsync(user, SD.Roles.Administrador);
            }
            return true;
        }
    }
}
