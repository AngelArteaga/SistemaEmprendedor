
using Sistemaemprendedor.Models;
using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Xml;
using System.Xml.Linq;
using System.IO;


namespace Sistemaemprendedor.Controllers
{
    public class CatalogoController : Controller
    {
        //Ecosistema
        public ActionResult Ecosistema(int region)
        {
            if (region == 14)
            {
                region = 3;
            }
            EcosistemaModelo modelo = new EcosistemaModelo();
            modelo.Region = modelo.RegionSch(region);
            modelo.Organizaciones = modelo.OrganizacionesSch(region);
            return View(modelo);
        }
        //Infografia
        public ActionResult Infografia(int region)
        {
            if (region == 14)
            {
                region = 3;
            }
            EcosistemaModelo modelo = new EcosistemaModelo();
            modelo.Region = modelo.RegionSch(region);            
            return View(modelo);
        }
        //MapaVocaciones
        public ActionResult MapaVocaciones()
        {           
            return View();
        }
        
        // GET: Catalogo
        public ActionResult Index(HttpPostedFileBase file)
        {
            if (file != null)
            {
                if (file.ContentType == "image/jpeg" || file.ContentType == "image/png")
                {
                    try
                    {
                        string pic = System.IO.Path.GetFileName(file.FileName);

                        string path = System.IO.Path.Combine(
                                               Server.MapPath("~/Content/Images/eventos"), pic);
                        // file is uploaded
                        file.SaveAs(path);

                        // save the image path path to the database or you can send image
                        // directly to database
                        // in-case if you want to store byte[] ie. for DB
                        using (MemoryStream ms = new MemoryStream())
                        {
                            file.InputStream.CopyTo(ms);
                            byte[] array = ms.GetBuffer();
                        }
                        ViewBag.Message = "File uploaded successfully";
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = "ERROR:" + ex.Message.ToString();
                    }
                }
                else
                {
                    ViewBag.Message = "Formato incorrecto";
                }
            }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            // after successfully uploading redirect the user
           
            return View();
        }

        [Authorize]
        public ActionResult EditarEvento (int id)
        {
            //Crea conexión a base de datos
            SistemaEmprendedorEntities bd = new SistemaEmprendedorEntities();
            EditarEventoForm model = new EditarEventoForm();
            Evento EventoEditable = new Evento();
            EventoEditable = bd.Evento.Where(x => x.id == id).Select(x => x).FirstOrDefault();
            //Llena datos del evento                                   
            model.Nombre = EventoEditable.Nombre;
            model.Descripcion = EventoEditable.Descripcion;
            model.tipoEvento = EventoEditable.idTipoEvento;
            model.Estado = EventoEditable.Estado;
            model.Municipio = EventoEditable.Municipio;
            model.CodigoPostal = EventoEditable.Cp;
            model.Calle = EventoEditable.Calle;
            model.FechaEvento = EventoEditable.FechaEvento;
            model.HoraInicio = EventoEditable.HoraInicio;
            model.Organizador = EventoEditable.Organizador;
            model.Email = EventoEditable.Email;
            model.Telefono = EventoEditable.Telefono;
            model.Website = EventoEditable.WebPage;
            model.Image = EventoEditable.url;
            return View(model);
        }

        // GET: Eventos
        public ActionResult Eventos()
        {
            SistemaEmprendedorEntities bd = new SistemaEmprendedorEntities();
            CatalogoModelo modelo = new CatalogoModelo();
            modelo.ListaDeTiposEvento = bd.TipoEvento.Select(x => x).ToList();
            modelo.ListaDeEventos = bd.Evento.Where(x=>x.estatus == 2).Select(x => x).ToList(); 
            string RegionName = System.Web.HttpContext.Current.Session["RegionString"] as String;
            return View(modelo);
        }

        // GET: Evento
        public ActionResult Evento(int id)
        {
            SistemaEmprendedorEntities bd = new SistemaEmprendedorEntities();
            CatalogoEvento model = new CatalogoEvento();
            Evento Event = new Models.Evento();
            Event = bd.Evento.Where(x => x.id == id).Select(x=>x).FirstOrDefault();
            if (Event != null)
            {
            model.idEvento = Event.id;
            model.Nombre = Event.Nombre;
            model.Titulo = Event.Nombre;
            model.Fecha = Event.FechaEvento;
            model.FechaMostrar = Event.Month + " " + Event.Day + ", " + Event.Year;
            model.Url = Event.url;
            model.TipoEvento = bd.TipoEvento.Where(x => x.idTipoEvento == Event.idTipoEvento).Select(x => x.Nombre).FirstOrDefault();
            model.Telefono = Event.Telefono;
            model.Correo = Event.Email;
            model.HoraEvento = Event.HoraInicio;
            model.DireccionComp = Event.Calle + ", " + Event.Municipio;
            model.DescripcionCompleta = Event.Descripcion;
                string hora = Event.HoraInicio.Split('p')[0];
                int outN;
                if (!Int32.TryParse(hora,out outN))
                {
                   hora = Event.HoraInicio.Split('a')[0];
                }
            model.Counter = Event.Year + "/" + Event.FechaEvento.Split('/')[1] + "/" + Event.Day + "," + Event.HoraInicio;
            return View(model);
            }
            else
            {
                return View();
            }
            
        }
       
        // GET: Empresas
        public ActionResult Organizaciones()
        {
            SistemaEmprendedorEntities bd = new SistemaEmprendedorEntities();
            CatalogoModelo modelo = new CatalogoModelo();
            modelo.ListaDeEmpresas = bd.Organizacion.Select(x => x).Where(x => x.IdRegion != null).ToList();
            modelo.ListaDeRegiones = bd.Regiones.Select(x => x).ToList();
            return View(modelo);
        }
        public ActionResult Organizacion(int id)
        {
            SistemaEmprendedorEntities bd = new SistemaEmprendedorEntities();
            CatalogoModelo modelo = new CatalogoModelo();
            modelo.Empresa = bd.Organizacion.Select(x => x).Where(x => x.id == id).FirstOrDefault();
            return View(modelo);
        }

        // GET: Emprendedores
        public ActionResult Emprendedores()
        {
            SistemaEmprendedorEntities bd = new SistemaEmprendedorEntities();
            CatalogoModelo modelo = new CatalogoModelo();
            //modelo.ListaDeEmprendedores = bd.Emprendedor.Select(x => x).ToList();
            return View(modelo);
        }
        // GET: Emprendedor
        public ActionResult Emprendedor()
        {
            SistemaEmprendedorEntities bd = new SistemaEmprendedorEntities();
            CatalogoModelo modelo = new CatalogoModelo();
            //modelo.ListaDeEmprendedores = bd.Emprendedor.Select(x => x).ToList();
            return View();
        }

        public ActionResult Busqueda(string TextSearch)
        {
            CatalogoModelo model = new CatalogoModelo();
            model.textSearch = TextSearch;            
            return View(model);
        }
    }
}