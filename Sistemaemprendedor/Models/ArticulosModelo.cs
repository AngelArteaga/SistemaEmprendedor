using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistemaemprendedor.Models
{
    public class ArticulosModelo
    {
    }
    public class CategoriasArticulosModelo
    {
        public List<CategoriasArticulos> Categorias { get; set; }
        public List<ArticulosInteres> Articulos { get; set; }
        public List<ArticulosInteres> ArticulosRecientes { get; set; }
        public string Categoria { get; set; }
        public ArticulosInteres Articulo { get; set; }
    }
}