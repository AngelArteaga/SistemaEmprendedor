using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Web.Mvc;
using System.Linq;

namespace Sistemaemprendedor.Models
{
    public class Usuarios
    {
        public List<AspNetUsers> UsersList { get; set; }
        public string UserStatus(string username)
        {
            SistemaEmprendedorEntities bd = new SistemaEmprendedorEntities();
            UserStatus usuario = bd.UserStatus.Find(username);
            if(usuario != null && usuario.Status == 1)
            {
                return ("Activo");
            }
            else
            {
                return ("Inactivo");
            }
            
        }
    }
    public class ManageCatalogo
    {
        public List<Evento> ListaEventos { get; set; }
        public List<Emprendedor> ListaEmprendedor { get; set; }
        public List<Organizacion> ListaOrganizaciones { get; set; }
        public List<ArticulosInteres> ListaArticulos { get; set; }
        public string OrgStatus(int id)
        {
            SistemaEmprendedorEntities bd = new SistemaEmprendedorEntities();
            Organizacion org = bd.Organizacion.Find(id);
            if (org != null && org.estatus == 1)
            {
                return ("Activo");
            }
            else if (org != null && org.estatus == 0)
            {
                return ("Nuevo registros");
            }
            else
            {
                return ("Inactivo");
            }

        }
        public string ArtStatus(int id)
        {
            SistemaEmprendedorEntities bd = new SistemaEmprendedorEntities();
            ArticulosInteres art = bd.ArticulosInteres.Where(x => x.Id == id).Select(x => x).FirstOrDefault();
            if (art != null && art.Estatus == 1)
            {
                return ("Activo");
            }
            else if (art != null && art.Estatus == 0)
            {
                return ("Nuevo registros");
            }
            else
            {
                return ("Inactivo");
            }

        }

        //Obtener AsistentesEventos
        public List<RegistroAEvento> ListaAsistentesDeEventos { get; set; }

        public Evento Evento { get; set; }

    }
    //Formulario para editar organizacion
    public class EditarOrganizacionForm
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
                        
        public int Estatus { get; set; }

        public int id { get; set; }

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
        
        [DataType(DataType.Text)]
        [Display(Name = "Imagen")]
        public string Imagen { get; set; }

        [Required]
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Descripción: *")]
        public string Descripcion { get; set; }

    }

    //Formulario para nueva organizacion
    public class EditarArticuloForm
    {
        public int Estatus { get; set; }
        public int id { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Imagen")]
        public string Imagen { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 20)]
        [DataType(DataType.Text)]
        [Display(Name = "Nombre del articulo: *")]
        public string Nombre { get; set; }

        [Required]
        [AllowHtml]
        [DataType(DataType.Text)]
        [Display(Name = "Texto del articulo (Puede incluir tags HTML): *")]
        public string Texto { get; set; }

        [Required]       
        [DataType(DataType.Text)]
        [Display(Name = "Introducción del articulo: *")]
        public string Intro { get; set; }

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
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }
    }

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }

    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "{0} debe tener al menos {2} caracteres de longitud.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña nueva")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme la contraseña nueva")]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessage = "La contraseña nueva y la contraseña de confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña actual")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} debe tener al menos {2} caracteres de longitud.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña nueva")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme la contraseña nueva")]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessage = "La contraseña nueva y la contraseña de confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }
    }

    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Número de teléfono")]
        public string Number { get; set; }
    }

    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "Código")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Número de teléfono")]
        public string PhoneNumber { get; set; }
    }

    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }
}