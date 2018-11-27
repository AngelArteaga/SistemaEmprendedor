using Sistemaemprendedor.Models;
using System;
using System.Net;
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
    public class ArticulosController : Controller
    {
        // GET: Articulos - Index
        public ActionResult Index()
        {
            return View();
        }

        // GET: Categorías
        public ActionResult Categorias()
        {
            SistemaEmprendedorEntities bd = new SistemaEmprendedorEntities();
            CategoriasArticulosModelo modelo = new CategoriasArticulosModelo();
            modelo.Categorias = bd.CategoriasArticulos.Where(x=>x.Estatus == 1).Select(x => x).ToList();
            modelo.ArticulosRecientes = bd.ArticulosInteres.OrderByDescending(x => x.Fecha).Where(x => x.Estatus == 1).Select(x => x).Take(3).ToList();
            return View(modelo);
        }
        // GET: Articulos
        [HttpPost]
        public ActionResult ListaArticulos(int id)
        {
            SistemaEmprendedorEntities bd = new SistemaEmprendedorEntities();
            CategoriasArticulosModelo modelo = new CategoriasArticulosModelo();
            ViewBag.Message = id.ToString();
            modelo.Articulos = bd.ArticulosInteres.OrderByDescending(x => x.Fecha).Where(x => x.Estatus == 1 && x.IdCategoria == id).Select(x => x).ToList();
            modelo.Categoria = bd.CategoriasArticulos.Where(x => x.IdCategoria == id).Select(x => x.Nombre).FirstOrDefault();
            return PartialView("Articulos", modelo);
        }
        // GET: Articulo
        public ActionResult Articulo(int id)
        {
            SistemaEmprendedorEntities bd = new SistemaEmprendedorEntities();
            CategoriasArticulosModelo modelo = new CategoriasArticulosModelo();
            modelo.Articulo = bd.ArticulosInteres.Where(x => x.Estatus == 1 && x.Id == id).Select(x => x).FirstOrDefault();
            modelo.Categoria = bd.CategoriasArticulos.Where(x => x.Estatus == 1 && x.IdCategoria == modelo.Articulo.IdCategoria).Select(x => x.Nombre).FirstOrDefault();            
            return View(modelo);
        }
    }
}