using Sistemaemprendedor.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

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


        [DataType(DataType.Date)]
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
        [StringLength(150, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 15)]
        [DataType(DataType.Text)]
        [Display(Name = "Nombre de la Institucion: *")]
        public string NombreOrg { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Correo electrónico: *")]
        public string CorreoOrg { get; set; }

        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Correo electrónico Colaborador 2:")]
        public string Correo2Org { get; set; }

        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Correo electrónico Colaborador 3:")]
        public string Correo3Org { get; set; }

        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Correo electrónico Colaborador 4:")]
        public string Correo4Org { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Región: *")]
        public string RegionOrg { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Tipo de Organismo de Apoyo al Emprendedor: *")]
        public string OrganismoApoyoOrg { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "¿Estás reconocido por el INADEM? *")]
        public int ReconocidoINADEMOrg { get; set; }

        [Required]
        [StringLength(1000, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 20)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Breve descripción: *")]
        public string DescripcionOrg { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 30)]
        [DataType(DataType.Text)]
        [Display(Name = "Principales servicios y productos de apoyo al emprendedor: *")]
        public string ApoyosEmprendedorOrg { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Número de Teléfono: *")]
        public string TelefonoOrg { get; set; }

        [DataType(DataType.Url)]
        [Display(Name = "Sitio web: *")]
        public string WebsiteOrg { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Facebook: *")]
        public string FacebookOrg { get; set; }

        
        [DataType(DataType.Text)]
        [Display(Name = "Twitter:")]
        public string TwitterOrg { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 10)]
        [DataType(DataType.Text)]
        [Display(Name = "Dirección: *")]
        public string DireccionOrg { get; set; }

        //Datos Representante

        [Required]
        [StringLength(150, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 15)]
        [DataType(DataType.Text)]
        [Display(Name = "Nombre del representante: *")]
        public string NombreRep { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Correo electrónico del representante: *")]
        public string CorreoRep { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Número de teléfono del representante: *")]
        public string TelefonoRep { get; set; }
           
        [DataType(DataType.Text)]
        [Display(Name = "LinkedIn:")]
        public string LinkedInRep { get; set; }

        //Datos Mentor 1                
        [DataType(DataType.Text)]
        [Display(Name = "Nombre Completo:")]
        public string NombreMent1 { get; set; }
        
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Correo Electrónico:")]
        public string CorreoMent1 { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Número de Teléfono:")]
        public string TelefonoMent1 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "LinkedIn:")]
        public string LinkedInMent1 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "DESARROLLO DE NEGOCIO:")]
        public int DesarrolloNegocioMent1 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "MERCADOTECNIA:")]
        public int MercadotecniaMent1 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "DESARROLLO DE SOFTWARE:")]
        public int DesarrolloSoftwareMent1 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "DESARROLLO DE HARDWARE:")]
        public int DesarrolloHardwareMent1 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "PITCH:")]
        public int PitchMent1 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "FINANZAS:")]
        public int FinanzasMent1 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "CONTABILIDAD:")]
        public int ContabilidadMent1 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "VALIDACION:")]
        public int ValidaciónMEnt1 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "MINIMO VIABLE:")]
        public int MinimoVariableMent1 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "LEGAL:")]
        public int LegalMent1 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "STARTUPS:")]
        public int StartupsMent1 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "ADMINISTRACIÓN:")]
        public int AdministracionMent1 { get; set; }

        //Datos Mentor 2   
        [DataType(DataType.Text)]
        [Display(Name = "Nombre Completo:")]
        public string NombreMent2 { get; set; }

        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Correo Electrónico:")]
        public string CorreoMent2 { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Número de Teléfono:")]
        public string TelefonoMent2 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "LinkedIn:")]
        public string LinkedInMent2 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "DESARROLLO DE NEGOCIO:")]
        public int DesarrolloNegocioMent2 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "MERCADOTECNIA:")]
        public int MercadotecniaMent2 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "DESARROLLO DE SOFTWARE:")]
        public int DesarrolloSoftwareMent2 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "DESARROLLO DE HARDWARE:")]
        public int DesarrolloHardwareMent2 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "PITCH:")]
        public int PitchMent2 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "FINANZAS:")]
        public int FinanzasMent2 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "CONTABILIDAD:")]
        public int ContabilidadMent2 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "VALIDACION:")]
        public int ValidaciónMEnt2 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "MINIMO VIABLE:")]
        public int MinimoVariableMent2 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "LEGAL:")]
        public int LegalMent2 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "STARTUPS:")]
        public int StartupsMent2 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "ADMINISTRACIÓN:")]
        public int AdministracionMent2 { get; set; }

        //Datos Mentor 3                
        [DataType(DataType.Text)]
        [Display(Name = "Nombre Completo:")]
        public string NombreMent3 { get; set; }

        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Correo Electrónico:")]
        public string CorreoMent3 { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Número de Teléfono:")]
        public string TelefonoMent3 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "LinkedIn:")]
        public string LinkedInMent3 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "DESARROLLO DE NEGOCIO:")]
        public int DesarrolloNegocioMent3 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "MERCADOTECNIA:")]
        public int MercadotecniaMent3 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "DESARROLLO DE SOFTWARE:")]
        public int DesarrolloSoftwareMent3 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "DESARROLLO DE HARDWARE:")]
        public int DesarrolloHardwareMent3 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "PITCH:")]
        public int PitchMent3 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "FINANZAS:")]
        public int FinanzasMent3 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "CONTABILIDAD:")]
        public int ContabilidadMent3 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "VALIDACION:")]
        public int ValidaciónMEnt3 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "MINIMO VIABLE:")]
        public int MinimoVariableMent3 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "LEGAL:")]
        public int LegalMent3 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "STARTUPS:")]
        public int StartupsMent3 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "ADMINISTRACIÓN:")]
        public int AdministracionMent3 { get; set; }

        [Required]
        [Display(Name = "Aviso de Privacidad")]
        public Boolean Privacidad { get; set; }
    }
}