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
    
    public partial class SRV_COMPRA
    {
        public int CODCOM { get; set; }
        public string CODCON { get; set; }
        public Nullable<System.DateTime> FECCOM { get; set; }
        public Nullable<decimal> SUBTOT { get; set; }
        public Nullable<decimal> VALIGV { get; set; }
        public Nullable<decimal> MONTOT { get; set; }
        public Nullable<int> CODRES { get; set; }
        public Nullable<int> CODTARJETA { get; set; }
        public string ESTREG { get; set; }
    
        public virtual SRV_RESERVA SRV_RESERVA { get; set; }
        public virtual SRV_TARJETA SRV_TARJETA { get; set; }
    }
}