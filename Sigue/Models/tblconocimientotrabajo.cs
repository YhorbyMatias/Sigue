//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sigue.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblconocimientotrabajo
    {
        public int TrabajoId { get; set; }
        public int EstudianteId { get; set; }
        public string Gerencia { get; set; }
        public string Organizacional { get; set; }
        public string Relacional { get; set; }
        public string Tic { get; set; }
    
        public virtual tblestudiante tblestudiante { get; set; }
    }
}