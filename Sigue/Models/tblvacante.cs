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
    
    public partial class tblvacante
    {
        public int VacanteId { get; set; }
        public int CentroPracticaId { get; set; }
        public string Cargo { get; set; }
        public string Departamento { get; set; }
        public Nullable<decimal> Salario { get; set; }
        public string Ubicacion { get; set; }
        public string ResumenCargo { get; set; }
        public string Funciones { get; set; }
        public string Requisitos { get; set; }
        public string AntecedentesAcademicos { get; set; }
        public string Experiencia { get; set; }
        public string Habilidades { get; set; }
        public System.DateTime FechaPublicacion { get; set; }
        public Nullable<System.DateTime> FechaCierre { get; set; }
    
        public virtual tblcentropractica tblcentropractica { get; set; }
    }
}
