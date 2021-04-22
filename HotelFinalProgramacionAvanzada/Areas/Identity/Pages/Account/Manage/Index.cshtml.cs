using HotelFinalProgramacionAvanzada.DataAccess.Data;
using HotelFinalProgramacionAvanzada.DataAccess.Repositorio.IRepositorio;
using HotelFinalProgramacionAvanzada.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace HotelFinalProgramacionAvanzada.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        readonly ApplicationDbContext _db;
        readonly IUnidadTrabajo _unidadTrabajo;

        public IndexModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ApplicationDbContext db,
            IUnidadTrabajo unidadTrabajo)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
            _unidadTrabajo = unidadTrabajo;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            public string Nombre { get; set; }

            public string Apellido { get; set; }
        }

        private async Task LoadAsync(IdentityUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Models.Usuario usuario = _unidadTrabajo.Usuarios.BuscarS(user.Id);

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                Nombre = usuario.Nombre + ' ' + usuario.Apellido
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            //var userTEM =
            //new Usuario
            //{
            //    Id = user.Id,
            //    UserName = user.UserName,
            //    PhoneNumber = Input.PhoneNumber,
            //    Nombre = Input.Nombre,
            //    Apellido = Input.Apellido
            //};

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            ////_unidadTrabajo.Usuarios.Actualizar(userTEM);

            //var userUpdate = await _userManager.UpdateAsync(userTEM);

            //if (!userUpdate.Succeeded)
            //{
            //    StatusMessage = "Unexpected error when trying to set data.";
            //    return RedirectToPage();
            //}

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
        public IActionResult OnPostRedirect1()
        {
            return Redirect("./Manage/ChangePassword");
        }
    }
}
