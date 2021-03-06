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
    
    public partial class Mentores
    {
        public int id { get; set; }
        public int estatus { get; set; }
        public System.DateTime Fecha_actualizacion { get; set; }
        public System.DateTime Fecha_Creacion { get; set; }
        public int Usuario_actualizacion { get; set; }
        public int Usuario_Creacion { get; set; }
        public int IdEmpresa { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string LinkedIn { get; set; }
        public Nullable<int> DesarrolloNegocio { get; set; }
        public Nullable<int> Mercadotecnia { get; set; }
        public Nullable<int> DesarrolloSoftware { get; set; }
        public Nullable<int> DesarrolloHardware { get; set; }
        public Nullable<int> Pitch { get; set; }
        public Nullable<int> Finanzas { get; set; }
        public Nullable<int> Contabilidad { get; set; }
        public Nullable<int> Validación { get; set; }
        public Nullable<int> MinimoVariable { get; set; }
        public Nullable<int> Legal { get; set; }
        public Nullable<int> Startups { get; set; }
        public Nullable<int> Administracion { get; set; }
    
        public virtual Organizacion Organizacion { get; set; }
    }
}
