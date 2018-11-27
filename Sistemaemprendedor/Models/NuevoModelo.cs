using Sistemaemprendedor.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Sistemaemprendedor.Models
{
    //Formulario para nuevo evento
    public class NuevoEventoForm
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
        public int tipoEvento { get; set; }

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
        public DateTime FechaEvento { get; set; }        

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


    }

    //Formulario para registro a evento
    public class NuevoAsistente
    {
        public int idEvento { get; set; }
        public string TituloEvento { get; set; }
        public Evento Evento { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Correo:")]
        public string Correo { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Perfil:")]
        public string Perfil { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Nombre:")]
        public string Nombre { get; set; }


        [DataType(DataType.Text)]
        [Display(Name = "Apellido Paterno:")]
        public string ApellidoPat { get; set; }


        [DataType(DataType.Text)]
        [Display(Name = "Apellido Materno:")]
        public string ApellidoMat { get; set; }

        
        [Display(Name = "Fecha de Nacimiento:")]
        public DateTime FechaNacimiento { get; set; }

        [RegularExpression("([0-9]+)")]
        [Display(Name = "Edad:")]
        public int Edad { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Estado de Nacimiento:")]
        public string Estado { get; set; }


        [DataType(DataType.Text)]
        [Display(Name = "Curp:")]
        public string Curp { get; set; }


        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Numero de contacto:")]
        public string Telefono { get; set; }


        [DataType(DataType.Text)]
        [Display(Name = "Sexo:")]
        public string Sexo { get; set; }


        [DataType(DataType.Text)]
        [Display(Name = "Escolaridad:")]
        public string Escolaridad { get; set; }


        [DataType(DataType.Text)]
        [Display(Name = "Calle:")]
        public string Calle { get; set; }


        [DataType(DataType.Text)]
        [Display(Name = "Número Exterior:")]
        public string NumExt { get; set; }


        [DataType(DataType.Text)]
        [Display(Name = "Colonia:")]
        public string Colonia { get; set; }


        [DataType(DataType.Text)]
        [Display(Name = "Código Postal:")]
        public string Cp { get; set; }


        [DataType(DataType.Text)]
        [Display(Name = "Municipio donde actualmente vives:")]
        public string Municipio { get; set; }


        [DataType(DataType.Text)]
        [Display(Name = "Nombre de tu Empresa / Idea de Negocio:")]
        public string Empresa { get; set; }


        [DataType(DataType.Text)]
        [Display(Name = "Etapa:")]
        public string Etapa { get; set; }


        [DataType(DataType.Text)]
        [Display(Name = "Sector:")]
        public string Sector { get; set; }


        [DataType(DataType.Text)]
        [Display(Name = "¿Qué más necesitas para continuar creciendo tu emprendimiento?:")]
        public string Necesidad { get; set; }
    }

    //Formulario para nueva organizacion
    public class NuevaOrganizacionForm
    {
        //Etapa Organización
        [Required]
        [StringLength(200, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 15)]
        [DataType(DataType.Text)]
        [Display(Name = "Nombre de la Institucion: *")]
        public string Nombre { get; set; }                

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Municipio: *")]
        public string Municipio { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Categoría: *")]
        public string Categoria { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "¿Te encuentras reconocido por el INADEM?: *")]
        public string Reconocido { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 5)]
        [DataType(DataType.Text)]
        [Display(Name = "Nombre del representante legal: *")]
        public string NombreRepresentante { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 5)]
        [DataType(DataType.Text)]
        [Display(Name = "Nombre del enlace: *")]
        public string NombreEnlace { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 5)]
        [DataType(DataType.Text)]
        [Display(Name = "Cargo del enlace: *")]
        public string CargoEnlace { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 5)]
        [DataType(DataType.Text)]
        [Display(Name = "Sector: *")]
        public string Sector { get; set; }

        [Required]        
        [StringLength(50, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 5)]
        [DataType(DataType.Text)]
        [Display(Name = "Correo electrónico: *")]
        public string Correo { get; set; }

        [Required]
        [StringLength(300, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 5)]
        [DataType(DataType.Text)]
        [Display(Name = "Dirección (Calle, Número exterior, Número interior, Colonia, Municipio, C.P. ): *")]
        public string Direccion { get; set; }
        
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 5)]
        [DataType(DataType.Text)]
        [Display(Name = "Teléfono: *")]
        public string Telefono { get; set; }

        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 5)]
        [DataType(DataType.Text)]
        [Display(Name = "Página Web: *")]
        public string PaginaWeb { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Descripción: *")]
        public string Descripcion { get; set; }
        
        public string lat { get; set; }
        
        public string lon { get; set; }

    }

    //Formulario para nuevo articulo
    public class NuevoArticuloForm
    {
        
        [Required]
        [StringLength(200, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 20)]
        [DataType(DataType.Text)]
        [Display(Name = "Nombre del articulo: *")]
        public string Nombre { get; set; }

        [Required]        
        [DataType(DataType.Text)]
        [Display(Name = "Introducción del articulo: *")]
        public string Intro { get; set; }

        [Required]
        [AllowHtml]
        [DataType(DataType.Text)]
        [Display(Name = "Texto del articulo (Puede incluir tags HTML): *")]
        public string Texto { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 20)]
        [DataType(DataType.Text)]
        [Display(Name = "Autor: *")]
        public string Autor { get; set; }

        [Required]        
        [DataType(DataType.Text)]
        [Display(Name = "Categoria: *")]
        public int Categoria { get; set; }

    }
}