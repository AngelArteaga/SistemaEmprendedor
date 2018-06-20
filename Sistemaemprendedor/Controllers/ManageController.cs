using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Sistemaemprendedor.Models;

namespace Sistemaemprendedor.Controllers
{    
    [Authorize]
    public class ManageController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ManageController()
        {
        }

        // Eliminar
        public ActionResult Eliminar(int tipo, int id)
        {
            SistemaEmprendedorEntities bd = new SistemaEmprendedorEntities();
            ActionResponses ar = null;
            ManageCatalogo model = new ManageCatalogo();
            string msg = null;
            if (tipo == 1)
            {
                Evento EventoBorrar = bd.Evento.Where(x => x.id == id).Select(x => x).FirstOrDefault();
                if (EventoBorrar!= null)
                {
                    try {
                        model.ListaAsistentesDeEventos = bd.RegistroAEvento.Where(x => x.IdEvento == id).Select(x => x).ToList();
                        if (model.ListaAsistentesDeEventos != null)
                        {
                            foreach (var Asistente in model.ListaAsistentesDeEventos){
                                bd.Entry(Asistente).State = System.Data.Entity.EntityState.Deleted;
                                bd.SaveChanges();
                            }
                        }
                        bd.Entry(EventoBorrar).State = System.Data.Entity.EntityState.Deleted;
                        bd.SaveChanges();
                    }
                    catch(Exception ex) {
                        msg = "Existe un problema al eliminar este evento, consulta al administrador";
                        ar = new ActionResponses(ResponseType.ERROR, msg);                               
                        ViewBag.ActionResponses = ar;
                        TempData["Message"] = ar;
                        return RedirectToAction("AdministrarEventos", "Manage");
                    }
                    msg = "Evento eliminado correctamente";
                    ar = new ActionResponses(ResponseType.SUCCESS, msg);                    
                    ViewBag.ActionResponses = ar;
                    TempData["Message"] = ar;
                    return RedirectToAction("AdministrarEventos", "Manage");
                }
            }

            return RedirectToAction("Index", "Home");
        }

        // Activar
        public ActionResult Activar(int tipo, int id)
        {
            SistemaEmprendedorEntities bd = new SistemaEmprendedorEntities();
            ActionResponses ar = null;
            string msg = null;
            if (tipo == 1)
            {
                Evento EventoActivar = bd.Evento.Where(x => x.id == id).Select(x => x).FirstOrDefault();
                if (EventoActivar != null)
                {
                    try
                    {
                        EventoActivar.estatus = 2;
                        bd.Entry(EventoActivar).State = System.Data.Entity.EntityState.Modified;
                        bd.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        msg = "Existe un problema al activar este evento, consulta al administrador";
                        ar = new ActionResponses(ResponseType.ERROR, msg);
                        ViewBag.ActionResponses = ar;
                        TempData["Message"] = ar;
                        return RedirectToAction("AdministrarEventos", "Manage");
                    }
                    msg = "Evento activado correctamente";
                    ar = new ActionResponses(ResponseType.SUCCESS, msg);
                    ViewBag.ActionResponses = ar;
                    TempData["Message"] = ar;
                    return RedirectToAction("AdministrarEventos", "Manage");
                }
            }

            return RedirectToAction("Index", "Home");
        }

        // Desactivar
        public ActionResult Desactivar(int tipo, int id)
        {
            SistemaEmprendedorEntities bd = new SistemaEmprendedorEntities();
            ActionResponses ar = null;
            string msg = null;
            if (tipo == 1)
            {
                Evento EventoActivar = bd.Evento.Where(x => x.id == id).Select(x => x).FirstOrDefault();
                if (EventoActivar != null)
                {
                    try
                    {
                        EventoActivar.estatus = 3;
                        bd.Entry(EventoActivar).State = System.Data.Entity.EntityState.Modified;
                        bd.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        msg = "Existe un problema al desactivar este evento, consulta al administrador";
                        ar = new ActionResponses(ResponseType.ERROR, msg);
                        ViewBag.ActionResponses = ar;
                        TempData["Message"] = ar;
                        return RedirectToAction("AdministrarEventos", "Manage");
                    }
                    msg = "Evento desactivado correctamente";
                    ar = new ActionResponses(ResponseType.SUCCESS, msg);
                    ViewBag.ActionResponses = ar;
                    TempData["Message"] = ar;
                    return RedirectToAction("AdministrarEventos", "Manage");
                }
            }

            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Lista de usuarios
        public ActionResult Usuarios()
        {
            SistemaEmprendedorEntities bd = new SistemaEmprendedorEntities();
            Usuarios Users = new Usuarios();
            Users.UsersList = bd.AspNetUsers.ToList();
            return View(Users);
        }

        //
        // GET: /Lista de asistentes
        public ActionResult AsistentesEvento(int idEvento)
        {
            SistemaEmprendedorEntities bd = new SistemaEmprendedorEntities();
            ManageCatalogo model = new ManageCatalogo();
            model.ListaAsistentesDeEventos = bd.RegistroAEvento.Where(x => x.IdEvento == idEvento).Select(x => x).ToList();
            model.Evento = bd.Evento.Where(x => x.id == idEvento).Select(x => x).FirstOrDefault();
            return View(model);
        }

        // GET: /Admin eventos
        public ActionResult AdministrarEventos()
        {
            SistemaEmprendedorEntities bd = new SistemaEmprendedorEntities();
            ManageCatalogo Manage = new ManageCatalogo();
            string ar = null;
            Manage.ListaEventos = bd.Evento.ToList();            
            if (TempData["Message"] != null)
            {
                ViewBag.ActionResponses = TempData["Message"];
            }            
            return View(Manage);
        }

        // GET: /Admin Emprendedores
        public ActionResult AdministrarEmprendedores()
        {
            SistemaEmprendedorEntities bd = new SistemaEmprendedorEntities();
            ManageCatalogo Manage = new ManageCatalogo();
            Manage.ListaEmprendedor = bd.Emprendedor.ToList();
            return View(Manage);
        }

        // GET: /Admin Organizaciones
        public ActionResult AdministrarOrganizaciones()
        {
            SistemaEmprendedorEntities bd = new SistemaEmprendedorEntities();
            ManageCatalogo Manage = new ManageCatalogo();
            Manage.ListaOrganizaciones = bd.Organizacion.ToList();
            return View(Manage);
        }

        public ManageController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set 
            { 
                _signInManager = value; 
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //
        // GET: /Manage/Index
        public async Task<ActionResult> Index(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Su contraseña se ha cambiado."
                : message == ManageMessageId.SetPasswordSuccess ? "Su contraseña se ha establecido."
                : message == ManageMessageId.SetTwoFactorSuccess ? "Su proveedor de autenticación de dos factores se ha establecido."
                : message == ManageMessageId.Error ? "Se ha producido un error."
                : message == ManageMessageId.AddPhoneSuccess ? "Se ha agregado su número de teléfono."
                : message == ManageMessageId.RemovePhoneSuccess ? "Se ha quitado su número de teléfono."
                : "";

            var userId = User.Identity.GetUserId();
            var model = new IndexViewModel
            {
                HasPassword = HasPassword(),
                PhoneNumber = await UserManager.GetPhoneNumberAsync(userId),
                TwoFactor = await UserManager.GetTwoFactorEnabledAsync(userId),
                Logins = await UserManager.GetLoginsAsync(userId),
                BrowserRemembered = await AuthenticationManager.TwoFactorBrowserRememberedAsync(userId)
            };
            return View(model);
        }

        //
        // POST: /Manage/RemoveLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RemoveLogin(string loginProvider, string providerKey)
        {
            ManageMessageId? message;
            var result = await UserManager.RemoveLoginAsync(User.Identity.GetUserId(), new UserLoginInfo(loginProvider, providerKey));
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                message = ManageMessageId.RemoveLoginSuccess;
            }
            else
            {
                message = ManageMessageId.Error;
            }
            return RedirectToAction("ManageLogins", new { Message = message });
        }

        //
        // GET: /Manage/AddPhoneNumber
        public ActionResult AddPhoneNumber()
        {
            return View();
        }

        //
        // POST: /Manage/AddPhoneNumber
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddPhoneNumber(AddPhoneNumberViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            // Generar el token y enviarlo
            var code = await UserManager.GenerateChangePhoneNumberTokenAsync(User.Identity.GetUserId(), model.Number);
            if (UserManager.SmsService != null)
            {
                var message = new IdentityMessage
                {
                    Destination = model.Number,
                    Body = "Su código de seguridad es: " + code
                };
                await UserManager.SmsService.SendAsync(message);
            }
            return RedirectToAction("VerifyPhoneNumber", new { PhoneNumber = model.Number });
        }

        //
        // POST: /Manage/EnableTwoFactorAuthentication
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EnableTwoFactorAuthentication()
        {
            await UserManager.SetTwoFactorEnabledAsync(User.Identity.GetUserId(), true);
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user != null)
            {
                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
            }
            return RedirectToAction("Index", "Manage");
        }

        //
        // POST: /Manage/DisableTwoFactorAuthentication
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DisableTwoFactorAuthentication()
        {
            await UserManager.SetTwoFactorEnabledAsync(User.Identity.GetUserId(), false);
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user != null)
            {
                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
            }
            return RedirectToAction("Index", "Manage");
        }

        //
        // GET: /Manage/VerifyPhoneNumber
        public async Task<ActionResult> VerifyPhoneNumber(string phoneNumber)
        {
            var code = await UserManager.GenerateChangePhoneNumberTokenAsync(User.Identity.GetUserId(), phoneNumber);
            // Enviar un SMS a través del proveedor de SMS para verificar el número de teléfono
            return phoneNumber == null ? View("Error") : View(new VerifyPhoneNumberViewModel { PhoneNumber = phoneNumber });
        }

        //
        // POST: /Manage/VerifyPhoneNumber
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyPhoneNumber(VerifyPhoneNumberViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await UserManager.ChangePhoneNumberAsync(User.Identity.GetUserId(), model.PhoneNumber, model.Code);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                return RedirectToAction("Index", new { Message = ManageMessageId.AddPhoneSuccess });
            }
            // Si llegamos a este punto, es que se ha producido un error, volvemos a mostrar el formulario
            ModelState.AddModelError("", "No se ha podido comprobar el teléfono");
            return View(model);
        }

        //
        // POST: /Manage/RemovePhoneNumber
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RemovePhoneNumber()
        {
            var result = await UserManager.SetPhoneNumberAsync(User.Identity.GetUserId(), null);
            if (!result.Succeeded)
            {
                return RedirectToAction("Index", new { Message = ManageMessageId.Error });
            }
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user != null)
            {
                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
            }
            return RedirectToAction("Index", new { Message = ManageMessageId.RemovePhoneSuccess });
        }

        //
        // GET: /Manage/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
            }
            AddErrors(result);
            return View(model);
        }

        //
        // GET: /Manage/SetPassword
        public ActionResult SetPassword()
        {
            return View();
        }

        //
        // POST: /Manage/SetPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SetPassword(SetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await UserManager.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword);
                if (result.Succeeded)
                {
                    var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                    if (user != null)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    }
                    return RedirectToAction("Index", new { Message = ManageMessageId.SetPasswordSuccess });
                }
                AddErrors(result);
            }

            // Si llegamos a este punto, es que se ha producido un error, volvemos a mostrar el formulario
            return View(model);
        }

        //
        // GET: /Manage/ManageLogins
        public async Task<ActionResult> ManageLogins(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.RemoveLoginSuccess ? "Se ha quitado el inicio de sesión externo."
                : message == ManageMessageId.Error ? "Se ha producido un error."
                : "";
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user == null)
            {
                return View("Error");
            }
            var userLogins = await UserManager.GetLoginsAsync(User.Identity.GetUserId());
            var otherLogins = AuthenticationManager.GetExternalAuthenticationTypes().Where(auth => userLogins.All(ul => auth.AuthenticationType != ul.LoginProvider)).ToList();
            ViewBag.ShowRemoveButton = user.PasswordHash != null || userLogins.Count > 1;
            return View(new ManageLoginsViewModel
            {
                CurrentLogins = userLogins,
                OtherLogins = otherLogins
            });
        }

        //
        // POST: /Manage/LinkLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LinkLogin(string provider)
        {
            // Solicitar la redirección al proveedor de inicio de sesión externo para vincular un inicio de sesión para el usuario actual
            return new AccountController.ChallengeResult(provider, Url.Action("LinkLoginCallback", "Manage"), User.Identity.GetUserId());
        }

        //
        // GET: /Manage/LinkLoginCallback
        public async Task<ActionResult> LinkLoginCallback()
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync(XsrfKey, User.Identity.GetUserId());
            if (loginInfo == null)
            {
                return RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
            }
            var result = await UserManager.AddLoginAsync(User.Identity.GetUserId(), loginInfo.Login);
            return result.Succeeded ? RedirectToAction("ManageLogins") : RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _userManager != null)
            {
                _userManager.Dispose();
                _userManager = null;
            }

            base.Dispose(disposing);
        }

#region Aplicaciones auxiliares
        // Se usan para protección XSRF al agregar inicios de sesión externos
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }

        private bool HasPhoneNumber()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PhoneNumber != null;
            }
            return false;
        }

        public enum ManageMessageId
        {
            AddPhoneSuccess,
            ChangePasswordSuccess,
            SetTwoFactorSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            RemovePhoneSuccess,
            Error
        }

#endregion
    }
}