﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class UPCEntities : DbContext
    {
        public UPCEntities()
            : base("name=UPCEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<contactenos> contactenos { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<SRV_BUS> SRV_BUS { get; set; }
        public virtual DbSet<SRV_CLIENTE> SRV_CLIENTE { get; set; }
        public virtual DbSet<SRV_CUPONES> SRV_CUPONES { get; set; }
        public virtual DbSet<SRV_PASAJERO> SRV_PASAJERO { get; set; }
        public virtual DbSet<SRV_PERFIL> SRV_PERFIL { get; set; }
        public virtual DbSet<SRV_PERSONAL> SRV_PERSONAL { get; set; }
        public virtual DbSet<SRV_PROGRAMACION> SRV_PROGRAMACION { get; set; }
        public virtual DbSet<SRV_PROMOCION> SRV_PROMOCION { get; set; }
        public virtual DbSet<SRV_RESERVA> SRV_RESERVA { get; set; }
        public virtual DbSet<SRV_TIPO_SERVICIO> SRV_TIPO_SERVICIO { get; set; }
        public virtual DbSet<SRV_USUARIO> SRV_USUARIO { get; set; }
        public virtual DbSet<SRV_VW_ASIENTOS_RESERVADOSDES> SRV_VW_ASIENTOS_RESERVADOSDES { get; set; }
        public virtual DbSet<SRV_VW_ASIENTOS_RESERVADOSORI> SRV_VW_ASIENTOS_RESERVADOSORI { get; set; }
        public virtual DbSet<SRV_VW_CONSULTA_PROGRAMACION> SRV_VW_CONSULTA_PROGRAMACION { get; set; }
        public virtual DbSet<SRV_VW_RESERVAS> SRV_VW_RESERVAS { get; set; }
        public virtual DbSet<SRV_TARIFA> SRV_TARIFA { get; set; }
        public virtual DbSet<SRV_VW_CONSULTA_PERSONAL> SRV_VW_CONSULTA_PERSONAL { get; set; }
        public virtual DbSet<SRV_TIPO_TARJETA> SRV_TIPO_TARJETA { get; set; }
        public virtual DbSet<SRV_TARJETA> SRV_TARJETA { get; set; }
        public virtual DbSet<SRV_COMPRA> SRV_COMPRA { get; set; }
    }
}
