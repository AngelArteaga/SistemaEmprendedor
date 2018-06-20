using Sistemaemprendedor.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Sistemaemprendedor.Models
{
    public class EcosistemaModelo
    {
        SistemaEmprendedorEntities bd = new SistemaEmprendedorEntities();
        DBConection dbConection = new DBConection();
        //Obtener Region
        public Regiones RegionSch(int id)
        {
            Regiones Region = bd.Regiones.Where(x => x.Id == id).FirstOrDefault();
            return Region;
        }
        public Regiones Region { get; set; }

        //Obtener Organizaciones de la region
        public List<Organizacion> OrganizacionesSch(int idRegion)
        {
            List<Organizacion> Organizaciones = bd.Organizacion.Where(x => x.IdRegion == idRegion).ToList();
            return Organizaciones;
        }

        public List<Organizacion> Organizaciones { get; set; }

    }
        public class CatalogoModelo
    {
        SistemaEmprendedorEntities bd = new SistemaEmprendedorEntities();
        static SistemaEmprendedorEntities bd2 = new SistemaEmprendedorEntities();
        DBConection dbConection = new DBConection();

        //Criterio de busqueda
        public string textSearch { get; set; }

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
        //Obtener Empresa
        public Organizacion Empresa { get; set; }
        //Obtener Regiones
        public List<Regiones> ListaDeRegiones { get; set; }

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

    //Formulario para editar evento
    public class EditarEventoForm
    {
        [Required]
        //[StringLength(200, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 15)]
        [DataType(DataType.Text)]
        [Display(Name = "Nombre:")]
        public string Nombre { get; set; }

        [Required]
        // [StringLength(2000, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 20)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Descripción:")]
        public string Descripcion { get; set; }

        // [Required(ErrorMessage ="Selecciona una opción valida")]                
        [Display(Name = "Tipo de evento:")]
        public int? tipoEvento { get; set; }

        [Required]
        //[StringLength(50, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 5)]
        //  [DataType(DataType.Text)]
        [Display(Name = "Estado:")]
        public string Estado { get; set; }

        // [StringLength(50, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 5)]
        //  [DataType(DataType.Text)]
        [Display(Name = "Ciudad:")]
        public string Ciudad { get; set; }

        [Required]
        //   [DataType(DataType.PostalCode)]
        [Display(Name = "Código Postal:")]
        public string CodigoPostal { get; set; }

        [Required]
        //  [DataType(DataType.Text)]
        [Display(Name = "Municipio:")]
        public string Municipio { get; set; }

        [Required]
        //   [DataType(DataType.Text)]
        [Display(Name = "Calle:")]
        public string Calle { get; set; }

        //  [DataType(DataType.Text)]
        [Display(Name = "Número Exterior:")]
        public string NumExt { get; set; }

        [Required]
        //  [DataType(DataType.Text)]
        [Display(Name = "Fecha:")]
        public string FechaEvento { get; set; }

        [Required]
        //  [DataType(DataType.Text)]
        [Display(Name = "Hora de inicio:")]
        public string HoraInicio { get; set; }

        [Required]
        //  [StringLength(50, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 10)]
        //  [DataType(DataType.Text)]
        [Display(Name = "Organizador:")]
        public string Organizador { get; set; }


        //  [DataType(DataType.EmailAddress)]
        [Display(Name = "Email:")]
        public string Email { get; set; }

        // [DataType(DataType.PhoneNumber)]
        [Display(Name = "Teléfono:")]
        public string Telefono { get; set; }


        //[DataType(DataType.Url)]
        [Display(Name = "Sitio Web:")]
        public string Website { get; set; }

        
        public string Image { get; set; }
    }
}