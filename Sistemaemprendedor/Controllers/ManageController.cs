using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Sistemaemprendedor.Models;
using Microsoft.AspNet.Identity;

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

        // Editar Organización
        [Authorize(Roles = "Administrador")]
        public ActionResult EditarOrganizacion(int id)
        {
            SistemaEmprendedorEntities bd = new SistemaEmprendedorEntities();
            Organizacion org = bd.Organizacion.Where(x => x.id == id).Select(x => x).FirstOrDefault();
            EditarOrganizacionForm model = new EditarOrganizacionForm();
            ViewBag.ActionResponses = TempData["AcResponse"];
            if (org != null)
            {
                //Llena datos de organizacion  
                model.Estatus = org.estatus;
                model.id = org.id;        
                model.Nombre = org.Nombre;
                model.Municipio = org.Municipio;               
                model.Categoria = org.CategoriaDesc;
                model.Reconocido = org.ReconocidoPorINADEM;
                model.NombreRepresentante = org.RepresentanteLegal;
                model.NombreEnlace = org.Enlace;
                model.CargoEnlace = org.CargoEnlace;
                model.Sector = org.Sector;
                model.Correo = org.Correo;
                model.Direccion = org.Direccion;
                model.Telefono = org.Telefono;
                model.PaginaWeb = org.PaginaWeb;
                model.Descripcion = org.Descripcion;
                model.Imagen = org.Imagen;
            }
            return View(model);
        }

        // Actualizar Organización
        [Authorize(Roles = "Administrador")]
        public ActionResult ActualizarOrganizacion(EditarOrganizacionForm model, HttpPostedFileBase file)
        {
            string extension = "";
            if (file != null)
            {
                extension = System.IO.Path.GetExtension(file.FileName).ToLower();
            }

            ActionResponses ar = null;
            string msg = null;
            if (file != null && extension != ".jpg" && extension != ".jpeg" && extension != ".gif" && extension != ".png" && extension != ".bmp")
            {
                msg = "Formato de imágen incorrecto";
                ar = new ActionResponses(ResponseType.ERROR, msg);
                ViewBag.ActionResponses = ar;
                TempData["AcResponse"] = ar;
            }
            if (ModelState.IsValid)
            {
                try
                {
                    //Crea conexión a base de datos
                    SistemaEmprendedorEntities bd = new SistemaEmprendedorEntities();
                    FileUploadController upload = new FileUploadController();
                    Organizacion NuevaOrgObj = bd.Organizacion.Where(x=>x.id == model.id).Select(x=>x).FirstOrDefault();
                    //Obtiene municipio/Region
                    int idRegion = 0;
                    string Region = "";
                    if (model.Municipio != "")
                    {
                        idRegion = bd.Municipios.Where(x => x.Nombre == model.Municipio).Select(x => x.idRegion).FirstOrDefault();
                        Region = bd.Regiones.Where(x => x.Id == idRegion).Select(x => x.Nombre).FirstOrDefault();
                    }
                    //Llena datos de organizacion
                    NuevaOrgObj.estatus = model.Estatus;
                    NuevaOrgObj.Fecha_actualizacion = DateTime.Today;
                    int UserId = 1;
                    bool UserIdValid = int.TryParse(User.Identity.GetUserId(), out UserId);
                    if (UserIdValid)
                    {
                        NuevaOrgObj.Usuario_actualizacion = UserId;
                    }
                    else
                    {
                        NuevaOrgObj.Usuario_actualizacion = 1;
                    }                     
                    NuevaOrgObj.Nombre = model.Nombre;
                    NuevaOrgObj.Municipio = model.Municipio;
                    NuevaOrgObj.IdRegion = idRegion;
                    NuevaOrgObj.Region = Region;
                    NuevaOrgObj.CategoriaDesc = model.Categoria;
                    NuevaOrgObj.ReconocidoPorINADEM = model.Reconocido;
                    NuevaOrgObj.RepresentanteLegal = model.NombreRepresentante;
                    NuevaOrgObj.Enlace = model.NombreEnlace;
                    NuevaOrgObj.CargoEnlace = model.CargoEnlace;
                    NuevaOrgObj.Sector = model.Sector;
                    NuevaOrgObj.Correo = model.Correo;
                    NuevaOrgObj.Direccion = model.Direccion;
                    NuevaOrgObj.Telefono = model.Telefono;
                    NuevaOrgObj.PaginaWeb = model.PaginaWeb;
                    NuevaOrgObj.Descripcion = model.Descripcion;
                    if (file != null)
                    {
                        //NuevaOrgObj.Imagen = AppConfig.SEBlobUrl + "/" + AppConfig.SE_stgContainer + "/" + file.FileName;
                        NuevaOrgObj.Imagen = file.FileName;
                        upload.uploadFileIntoBlob(file.FileName, file);
                    }                    

                    //Agrega el objeto a la base y guarda los cambios.
                    //bd.Organizacion.Add(NuevaOrgObj);
                    bd.SaveChanges();
                }
                catch (Exception ex)
                {
                    string mensajedeerror = ex.ToString();
                    msg = "Se registro un error, intentelo nuevamente o reportelo al administrador del sistema";
                    ar = new ActionResponses(ResponseType.ERROR, msg);
                    ViewBag.ActionResponses = ar;
                    TempData["AcResponse"] = ar;
                    return RedirectToAction("EditarOrganizacion", new { id = model.id });
                }
                msg = "Organización actualizada correctamente.";
                ar = new ActionResponses(ResponseType.SUCCESS, msg);
                TempData["AcResponse"] = ar;
                ViewBag.ActionResponses = ar;
            }
            else
            {
                msg = "Revise los campos del formulario";
                ar = new ActionResponses(ResponseType.ERROR, msg);
                ViewBag.ActionResponses = ar;
                TempData["AcResponse"] = ar;
            }
            return RedirectToAction("EditarOrganizacion", new { id = model.id });
        }

        // Editar Articulo
        [Authorize(Roles = "Administrador")]
        public ActionResult EditarArticulo(int id)
        {
            SistemaEmprendedorEntities bd = new SistemaEmprendedorEntities();
            ArticulosInteres art = bd.ArticulosInteres.Where(x => x.Id == id).Select(x => x).FirstOrDefault();
            EditarArticuloForm model = new EditarArticuloForm();
            ViewBag.ActionResponses = TempData["AcResponse"];
            if (art != null)
            {
                //Llena datos de organizacion  
                model.Estatus = art.Estatus;
                model.id = art.Id;
                model.Nombre = art.Nombre;
                model.Autor = art.Autor;
                model.Categoria = art.Id;
                model.Intro = art.Introduccion;
                model.Texto = art.Descripcion;                
                model.Imagen = art.Imagen;
            }
            return View(model);
        }

        // Actualizar Organización
        [Authorize(Roles = "Administrador")]
        public ActionResult ActualizarArticulo(EditarArticuloForm model, HttpPostedFileBase file)
        {
            string extension = "";
            if (file != null)
            {
                extension = System.IO.Path.GetExtension(file.FileName).ToLower();
            }

            ActionResponses ar = null;
            string msg = null;
            if (file != null && extension != ".jpg" && extension != ".jpeg" && extension != ".gif" && extension != ".png" && extension != ".bmp")
            {
                msg = "Formato de imágen incorrecto";
                ar = new ActionResponses(ResponseType.ERROR, msg);
                ViewBag.ActionResponses = ar;
                TempData["AcResponse"] = ar;
            }
            if (ModelState.IsValid)
            {
                try
                {
                    //Crea conexión a base de datos
                    SistemaEmprendedorEntities bd = new SistemaEmprendedorEntities();
                    FileUploadController upload = new FileUploadController();
                    ArticulosInteres NuevoArtObj = bd.ArticulosInteres.Where(x => x.Id == model.id).Select(x => x).FirstOrDefault();
                    //Obtiene categoria
                    if (model.Categoria != 0)
                    {
                        NuevoArtObj.Categoria = bd.CategoriasArticulos.Where(x => x.IdCategoria == model.Categoria).Select(x => x.Nombre).FirstOrDefault();
                        NuevoArtObj.IdCategoria = model.Categoria;
                    }
                    //Llena datos de organizacion
                    NuevoArtObj.Estatus = model.Estatus;
                    NuevoArtObj.FechaActualizacion = DateTime.Today;
                    int UserId = 1;
                    bool UserIdValid = int.TryParse(User.Identity.GetUserId(), out UserId);
                    if (UserIdValid)
                    {
                        NuevoArtObj.UsuarioActualizacion = UserId;
                    }
                    else
                    {
                        NuevoArtObj.UsuarioActualizacion = 1;
                    }
                    NuevoArtObj.Nombre = model.Nombre;
                    NuevoArtObj.Introduccion = model.Intro;
                    NuevoArtObj.Descripcion = model.Texto;
                    NuevoArtObj.Autor = model.Autor;                    
                    if (file != null)
                    {
                        //NuevaOrgObj.Imagen = AppConfig.SEBlobUrl + "/" + AppConfig.SE_stgContainer + "/" + file.FileName;
                        NuevoArtObj.Imagen = file.FileName;
                        upload.uploadFileIntoBlob(file.FileName, file);
                    }

                    //Agrega el objeto a la base y guarda los cambios.                    
                    bd.SaveChanges();
                }
                catch (Exception ex)
                {
                    string mensajedeerror = ex.ToString();
                    msg = "Se registro un error, intentelo nuevamente o reportelo al administrador del sistema";
                    ar = new ActionResponses(ResponseType.ERROR, msg);
                    ViewBag.ActionResponses = ar;
                    TempData["AcResponse"] = ar;
                    return RedirectToAction("EditarArticulo", new { id = model.id });
                }
                msg = "Articulo actualizado correctamente.";
                ar = new ActionResponses(ResponseType.SUCCESS, msg);
                TempData["AcResponse"] = ar;
                ViewBag.ActionResponses = ar;
            }
            else
            {
                msg = "Revise los campos del formulario";
                ar = new ActionResponses(ResponseType.ERROR, msg);
                ViewBag.ActionResponses = ar;
                TempData["AcResponse"] = ar;
            }
            return RedirectToAction("EditarArticulo", new { id = model.id });
        }

        // Eliminar
        [Authorize(Roles = "Administrador")]
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
            if (tipo == 2)
            {
                Organizacion OrgBorrar = bd.Organizacion.Where(x => x.id == id).Select(x => x).FirstOrDefault();
                if (OrgBorrar != null)
                {
                    try
                    {   
                        if(OrgBorrar.Imagen != null && OrgBorrar.Imagen != "logo hidalgo crece contigo.png")
                        {
                            FileUploadController delete = new FileUploadController();
                            delete.DeleteBlob(OrgBorrar.Imagen);
                        }                    
                        bd.Entry(OrgBorrar).State = System.Data.Entity.EntityState.Deleted;
                        bd.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        msg = "Existe un problema al eliminar esta organización, consulta al administrador";
                        ar = new ActionResponses(ResponseType.ERROR, msg);
                        ViewBag.ActionResponses = ar;
                        TempData["Message"] = ar;
                        return RedirectToAction("AdministrarOrganizaciones", "Manage");
                    }
                    msg = "Organización eliminada correctamente";
                    ar = new ActionResponses(ResponseType.SUCCESS, msg);
                    ViewBag.ActionResponses = ar;
                    TempData["Message"] = ar;
                    return RedirectToAction("AdministrarOrganizaciones", "Manage");
                }
            }
            if (tipo == 3)
            {
                ArticulosInteres ArticuloBorrar = bd.ArticulosInteres.Where(x => x.Id == id).Select(x => x).FirstOrDefault();
                if (ArticuloBorrar != null)
                {
                    try
                    {
                        if (ArticuloBorrar.Imagen != null && ArticuloBorrar.Imagen != "logo hidalgo crece contigo.png")
                        {
                            FileUploadController delete = new FileUploadController();
                            delete.DeleteBlob(ArticuloBorrar.Imagen);
                        }
                        bd.Entry(ArticuloBorrar).State = System.Data.Entity.EntityState.Deleted;
                        bd.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        msg = "Existe un problema al eliminar este articulo, consulta al administrador";
                        ar = new ActionResponses(ResponseType.ERROR, msg);
                        ViewBag.ActionResponses = ar;
                        TempData["Message"] = ar;
                        return RedirectToAction("AdministrarArticulos", "Manage");
                    }
                    msg = "Articulo eliminado correctamente";
                    ar = new ActionResponses(ResponseType.SUCCESS, msg);
                    ViewBag.ActionResponses = ar;
                    TempData["Message"] = ar;
                    return RedirectToAction("AdministrarArticulos", "Manage");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        // Activar
        [Authorize(Roles = "Administrador")]
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
            if (tipo == 2)
            {
                Organizacion OrganizacionActivar = bd.Organizacion.Where(x => x.id == id).Select(x => x).FirstOrDefault();
                if (OrganizacionActivar != null && (OrganizacionActivar.estatus == 0 || OrganizacionActivar.estatus == 2))
                {
                    try
                    {
                        OrganizacionActivar.estatus = 1;
                        bd.Entry(OrganizacionActivar).State = System.Data.Entity.EntityState.Modified;
                        bd.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        msg = "Existe un problema al activar esta organizacion, consulta al administrador";
                        ar = new ActionResponses(ResponseType.ERROR, msg);
                        ViewBag.ActionResponses = ar;
                        TempData["Message"] = ar;
                        return RedirectToAction("AdministrarOrganizaciones", "Manage");
                    }
                    msg = "Evento activado correctamente";
                    ar = new ActionResponses(ResponseType.SUCCESS, msg);
                    ViewBag.ActionResponses = ar;
                    TempData["Message"] = ar;
                    return RedirectToAction("AdministrarOrganizaciones", "Manage");
                }
            }
            if (tipo == 3)
            {
                ArticulosInteres ArtActivar = bd.ArticulosInteres.Where(x => x.Id == id).Select(x => x).FirstOrDefault();
                if (ArtActivar != null && (ArtActivar.Estatus == 0 || ArtActivar.Estatus == 2))
                {
                    try
                    {
                        ArtActivar.Estatus = 1;
                        bd.Entry(ArtActivar).State = System.Data.Entity.EntityState.Modified;
                        bd.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        msg = "Existe un problema al activar este articulo, consulta al administrador";
                        ar = new ActionResponses(ResponseType.ERROR, msg);
                        ViewBag.ActionResponses = ar;
                        TempData["Message"] = ar;
                        return RedirectToAction("AdministrarArticulos", "Manage");
                    }
                    msg = "Articulo activado correctamente";
                    ar = new ActionResponses(ResponseType.SUCCESS, msg);
                    ViewBag.ActionResponses = ar;
                    TempData["Message"] = ar;
                    return RedirectToAction("AdministrarArticulos", "Manage");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        // Desactivar
        [Authorize(Roles = "Administrador")]
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
            if (tipo == 2)
            {
                Organizacion OrgActivar = bd.Organizacion.Where(x => x.id == id).Select(x => x).FirstOrDefault();
                if (OrgActivar != null && OrgActivar.estatus == 1)
                {
                    try
                    {
                        OrgActivar.estatus = 2;
                        bd.Entry(OrgActivar).State = System.Data.Entity.EntityState.Modified;
                        bd.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        msg = "Existe un problema al desactivar esta organización, consulta al administrador";
                        ar = new ActionResponses(ResponseType.ERROR, msg);
                        ViewBag.ActionResponses = ar;
                        TempData["Message"] = ar;
                        return RedirectToAction("AdministrarOrganizaciones", "Manage");
                    }
                    msg = "Organización desactivada correctamente";
                    ar = new ActionResponses(ResponseType.SUCCESS, msg);
                    ViewBag.ActionResponses = ar;
                    TempData["Message"] = ar;
                    return RedirectToAction("AdministrarOrganizaciones", "Manage");
                }
            }
            if (tipo == 3)
            {
                ArticulosInteres ArtActivar = bd.ArticulosInteres.Where(x => x.Id == id).Select(x => x).FirstOrDefault();
                if (ArtActivar != null && ArtActivar.Estatus == 1)
                {
                    try
                    {
                        ArtActivar.Estatus = 2;
                        bd.Entry(ArtActivar).State = System.Data.Entity.EntityState.Modified;
                        bd.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        msg = "Existe un problema al desactivar este articulo, consulta al administrador";
                        ar = new ActionResponses(ResponseType.ERROR, msg);
                        ViewBag.ActionResponses = ar;
                        TempData["Message"] = ar;
                        return RedirectToAction("AdministrarArticulos", "Manage");
                    }
                    msg = "Articulo desactivado correctamente";
                    ar = new ActionResponses(ResponseType.SUCCESS, msg);
                    ViewBag.ActionResponses = ar;
                    TempData["Message"] = ar;
                    return RedirectToAction("AdministrarArticulos", "Manage");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Lista de usuarios
        [Authorize(Roles = "Administrador")]
        public ActionResult Usuarios()
        {
            SistemaEmprendedorEntities bd = new SistemaEmprendedorEntities();
            Usuarios Users = new Usuarios();
            Users.UsersList = bd.AspNetUsers.Where(x=>x.Email != "admin@sistema.com").Select(x=>x).ToList();
            return View(Users);
        }

        //
        // GET: /Lista de asistentes
        [Authorize(Roles = "Administrador")]
        public ActionResult AsistentesEvento(int idEvento)
        {
            SistemaEmprendedorEntities bd = new SistemaEmprendedorEntities();
            ManageCatalogo model = new ManageCatalogo();
            model.ListaAsistentesDeEventos = bd.RegistroAEvento.Where(x => x.IdEvento == idEvento).Select(x => x).ToList();
            model.Evento = bd.Evento.Where(x => x.id == idEvento).Select(x => x).FirstOrDefault();
            return View(model);
        }

        // GET: /Admin eventos
        [Authorize(Roles = "Administrador")]
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
        [Authorize(Roles = "Administrador")]
        public ActionResult AdministrarEmprendedores()
        {
            SistemaEmprendedorEntities bd = new SistemaEmprendedorEntities();
            ManageCatalogo Manage = new ManageCatalogo();
            Manage.ListaEmprendedor = bd.Emprendedor.ToList();
            return View(Manage);
        }

        // GET: /Admin Organizaciones
        [Authorize(Roles = "Administrador")]
        public ActionResult AdministrarOrganizaciones()
        {
            SistemaEmprendedorEntities bd = new SistemaEmprendedorEntities();
            ManageCatalogo Manage = new ManageCatalogo();
            Manage.ListaOrganizaciones = bd.Organizacion.ToList();            
            return View(Manage);
        }

        // GET: /Admin Articulos
        [Authorize(Roles = "Administrador")]
        public ActionResult AdministrarArticulos()
        {
            SistemaEmprendedorEntities bd = new SistemaEmprendedorEntities();
            ManageCatalogo Manage = new ManageCatalogo();
            Manage.ListaArticulos = bd.ArticulosInteres.ToList();
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