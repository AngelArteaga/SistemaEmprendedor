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
    
    public partial class Representante
    {
        public int id { get; set; }
        public int estatus { get; set; }
        public System.DateTime Fecha_actualizacion { get; set; }
        public System.DateTime Fecha_Creacion { get; set; }
        public int Usuario_actualizacion { get; set; }
        public int Usuario_Creacion { get; set; }
        public string Nombre { get; set; }
        public int IdEmpresa { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string LinkedIn { get; set; }
    }
}
