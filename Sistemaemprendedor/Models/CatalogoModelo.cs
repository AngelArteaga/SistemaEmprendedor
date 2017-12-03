using Sistemaemprendedor.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Sistemaemprendedor.Models
{    
    public class CatalogoModelo
    {
        SistemaEmprendedorEntities bd = new SistemaEmprendedorEntities();
        static SistemaEmprendedorEntities bd2 = new SistemaEmprendedorEntities();
        DBConection dbConection = new DBConection();

        //Obtener Eventos
        public List<Evento> ListaDeEventos { get; set; }

        //Obtener Tipo de Evento
        public string TipoEvento(int idTipoEvento) {
            string Tipo = bd.TipoEvento.Where(x => x.idTipoEvento == idTipoEvento).FirstOrDefault().Nombre;
            return Tipo;
        }
       
        public List<TipoEvento> ListaDeTiposEvento { get; set; }

        //Obtener Empresas
        public List<Organizacion> ListaDeEmpresas { get; set; }

        //Obtener Emprendedores
        public List<Emprendedor> ListaDeEmprendedores { get; set; }
        
    }

    public class CatalogoEvento
    {
        public string Nombre { get; set; }

        public int idEvento { get; set; }

        public string Titulo { get; set; }

        public string Fecha { get; set; }

        public string FechaMostrar { get; set; }

        public string Url { get; set; }

        public string TipoEvento { get; set; }

        public string Telefono { get; set; }

        public string Correo { get; set; }

        public string HoraEvento { get; set; }

        public string DireccionComp { get; set; }

        public string DescripcionCompleta { get; set; }

        public string Counter { get; set; }

    }

}