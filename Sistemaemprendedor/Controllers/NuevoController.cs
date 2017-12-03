using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Sistemaemprendedor.Models;
using Sistemaemprendedor.App_Start;

namespace Sistemaemprendedor.Controllers
{
    public class NuevoController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            return View();
        }

        // GET: Nuevo Evento
        [AllowAnonymous]
        public ActionResult Evento()
        {
            return View();
        }

        // POST: Nuevo Evento
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Evento(NuevoEventoForm model, HttpPostedFileBase file)
        {
            string extension = "";            
            if (file != null)
            {
                extension = System.IO.Path.GetExtension(file.FileName).ToLower();
            }
            
            ActionResponses ar = null;            
            string msg = null;
            if (file!= null && extension != ".jpg" && extension != ".jpeg" && extension != ".gif" && extension != ".png" && extension != ".bmp")
            {
                msg = "Formato de imágen incorrecto";
                ar = new ActionResponses(ResponseType.ERROR, msg);
                ViewBag.ActionResponses = ar;                
            }
            if (ModelState.IsValid)
            {
                try
                {
                    //Crea conexión a base de datos
                    SistemaEmprendedorEntities bd = new SistemaEmprendedorEntities();
                    FileUploadController upload = new FileUploadController();
                    Evento NuevoEventoObj = new Evento();
                    //Llena datos del evento                
                    NuevoEventoObj.estatus = 1;
                    NuevoEventoObj.Fecha_actualizacion = DateTime.Today;
                    NuevoEventoObj.Fecha_Creacion = DateTime.Today;
                    NuevoEventoObj.Usuario_actualizacion = 1;
                    NuevoEventoObj.Usuario_Creacion = 1;
                    NuevoEventoObj.Nombre = model.Nombre;
                    NuevoEventoObj.Descripcion = model.Descripcion;
                    NuevoEventoObj.ShortDesc = new string(model.Descripcion.Take(46).ToArray())+"...";
                    NuevoEventoObj.idTipoEvento = model.tipoEvento;
                    NuevoEventoObj.Estado = model.Estado;
                    NuevoEventoObj.Ciudad = model.Municipio;
                    NuevoEventoObj.Cp = "CP "+model.CodigoPostal;
                    NuevoEventoObj.Municipio = model.Municipio;
                    NuevoEventoObj.Calle = model.Calle + " " + model.NumExt;
                    NuevoEventoObj.FechaEvento = model.FechaEvento.ToString("dd/MM/yyyy").ToUpper();
                    NuevoEventoObj.Month = model.FechaEvento.ToString("MMMM").ToUpper();
                    TextInfo textInfo = new CultureInfo("es-MX", false).TextInfo;
                    NuevoEventoObj.Month = textInfo.ToTitleCase(NuevoEventoObj.Month);
                    NuevoEventoObj.Day = model.FechaEvento.Day;
                    NuevoEventoObj.Year = model.FechaEvento.Year;
                    NuevoEventoObj.HoraInicio = model.HoraInicio;
                    NuevoEventoObj.Organizador = model.Organizador;
                    NuevoEventoObj.Email = model.Email;
                    NuevoEventoObj.Telefono = model.Telefono;
                    NuevoEventoObj.WebPage = model.Website;
                    if (file != null)
                    {
                        
                        NuevoEventoObj.url = AppConfig.SEBlobUrl+"/"+AppConfig.SE_stgContainer+"/"+file.FileName;
                        upload.uploadFileIntoBlob(file.FileName, file);
                    }
                    else
                    {
                        NuevoEventoObj.url = AppConfig.SEBlobUrl + "/" + AppConfig.SE_stgContainer + "/" + "NA.jpg";
                    } 
                    //Agrega el objeto a la base y guarda los cambios.
                    bd.Evento.Add(NuevoEventoObj);
                    bd.SaveChanges();                                                   
                }
                catch (Exception ex)
                {
                    string mensajedeerror = ex.ToString();
                    msg = "Se registro un error, intentelo nuevamente o reportelo al administrador del sistema";
                    ar = new ActionResponses(ResponseType.ERROR, msg);
                    ViewBag.ActionResponses = ar;
                    return View(model);
                }
                msg = "Evento agregado correctamente";
                ar = new ActionResponses(ResponseType.SUCCESS, msg);
                ViewBag.ActionResponses = ar;               
            }
            else
            {
                msg = "Revise los campos del formulario";
                ar = new ActionResponses(ResponseType.ERROR, msg);
                ViewBag.ActionResponses = ar;
            }
            return View();
        }

        // GET: Nuevo Acceso a Evento
        [AllowAnonymous]
        public ActionResult RegistroEvento(int id)
        {
            SistemaEmprendedorEntities bd = new SistemaEmprendedorEntities();
            NuevoAsistente model = new NuevoAsistente();
            model.idEvento = id;
            model.TituloEvento = bd.Evento.Where(x => x.id == id).Select(x => x.Nombre).FirstOrDefault();
            return View(model);
        }

        // POST: Nuevo Acceso a Evento
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult RegistroEvento(NuevoAsistente model)
        {
            ActionResponses ar = null;
            string msg = null;
            if (ModelState.IsValid)
            {
                try
                {
                    //Crea conexión a base de datos
                    SistemaEmprendedorEntities bd = new SistemaEmprendedorEntities();
                    RegistroAEvento NuevoRegistroObj = new RegistroAEvento();
                    //Llena datos del evento                         
                    NuevoRegistroObj.IdEvento = 20;
                    NuevoRegistroObj.Fecha_actualizacion = DateTime.Today;
                    NuevoRegistroObj.Fecha_Creacion = DateTime.Today;
                    NuevoRegistroObj.Usuario_actualizacion = 1;
                    NuevoRegistroObj.Usuario_Creacion = 1;
                    NuevoRegistroObj.Correo = model.Correo;
                    NuevoRegistroObj.ApellidoMaterno = model.ApellidoMat;
                    NuevoRegistroObj.ApellidoPaterno = model.ApellidoPat;
                    NuevoRegistroObj.FechaNacimiento = model.FechaNacimiento;
                    NuevoRegistroObj.Edad = model.Edad;
                    NuevoRegistroObj.Estado = model.Estado;
                    NuevoRegistroObj.CURP = model.Curp;
                    NuevoRegistroObj.Telefono = model.Telefono;
                    NuevoRegistroObj.Sexo = model.Sexo;
                    NuevoRegistroObj.Escolaridad = model.Escolaridad;
                    NuevoRegistroObj.Calle = model.Calle;
                    NuevoRegistroObj.NumExt = model.NumExt;
                    NuevoRegistroObj.Colonia = model.Colonia;
                    NuevoRegistroObj.Domicilio = model.Calle + " " + model.NumExt + "," + model.Colonia;
                    NuevoRegistroObj.CP = model.Cp;
                    NuevoRegistroObj.Municipio = model.Municipio;
                    //NuevoRegistroObj.IdRegion = model.Empresa;
                    NuevoRegistroObj.Empresa = model.Empresa;
                    NuevoRegistroObj.Etapa = model.Etapa;
                    NuevoRegistroObj.Sector = model.Sector;
                    NuevoRegistroObj.Necesidad = model.Necesidad;

                    //Agrega el objeto a la base y guarda los cambios.
                    bd.RegistroAEvento.Add(NuevoRegistroObj);
                    bd.SaveChanges();
                }
                catch (Exception ex)
                {
                    string mensajedeerror = ex.ToString();
                    msg = "Se registro un error, intentelo nuevamente o reportelo al administrador del sistema";
                    ar = new ActionResponses(ResponseType.ERROR, msg);
                    ViewBag.ActionResponses = ar;
                    return View(model);
                }
                msg = "Registro agregado correctamente";
                ar = new ActionResponses(ResponseType.SUCCESS, msg);
                ViewBag.ActionResponses = ar;
            }
            else
            {
                msg = "Revise los campos del formulario";
                ar = new ActionResponses(ResponseType.ERROR, msg);
                ViewBag.ActionResponses = ar;
            }
            return View(model);
        }

        // GET: Nuevo Evento
        [AllowAnonymous]
        public ActionResult Organizacion()
        {
            return View();
        }

        // POST: Nuevo Evento
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Organizacion(NuevaOrganizacionForm model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //Crea conexión a base de datos
                    SistemaEmprendedorEntities bd = new SistemaEmprendedorEntities();
                    Evento NuevoEventoObj = new Evento();
                    //Llena datos de organizacion
                    
                    //Agrega el objeto a la base y guarda los cambios.
                    bd.Evento.Add(NuevoEventoObj);
                    bd.SaveChanges();
                }
                catch (Exception ex)
                {
                    string mensajedeerror = ex.ToString();
                }
            }
            return View(model);
        }
    }
}