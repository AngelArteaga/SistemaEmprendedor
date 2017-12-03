//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sistemaemprendedor.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Evento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Evento()
        {
            this.RegistroAEvento = new HashSet<RegistroAEvento>();
        }
    
        public int id { get; set; }
        public int estatus { get; set; }
        public System.DateTime Fecha_actualizacion { get; set; }
        public System.DateTime Fecha_Creacion { get; set; }
        public int Usuario_actualizacion { get; set; }
        public int Usuario_Creacion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public string FechaEvento { get; set; }
        public string HoraInicio { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string WebPage { get; set; }
        public string Organizador { get; set; }
        public string url { get; set; }
        public Nullable<int> idTipoEvento { get; set; }
        public Nullable<int> idRegion { get; set; }
        public string Cp { get; set; }
        public string Municipio { get; set; }
        public string Calle { get; set; }
        public string ShortDesc { get; set; }
        public string Month { get; set; }
        public Nullable<int> Day { get; set; }
        public Nullable<int> Year { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegistroAEvento> RegistroAEvento { get; set; }
    }
}
