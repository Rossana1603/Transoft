//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UPC.TS.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class SRV_TARJETA
    {
        public SRV_TARJETA()
        {
            this.SRV_COMPRA = new HashSet<SRV_COMPRA>();
        }
    
        public int CODTARJETA { get; set; }
        public string NUMTAR { get; set; }
        public string CODVER { get; set; }
        public string NOMTIT { get; set; }
        public string APETIT { get; set; }
        public string FECEXP { get; set; }
        public string ESTREG { get; set; }
        public Nullable<int> CODTIPTAR { get; set; }
    
        public virtual SRV_TIPO_TARJETA SRV_TIPO_TARJETA { get; set; }
        public virtual ICollection<SRV_COMPRA> SRV_COMPRA { get; set; }
    }
}