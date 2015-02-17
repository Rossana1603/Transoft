using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.TS.Entities;
using UPC.TS.DataContract;
using UPC.TS.DataContract.Infraestructura;
using UPC.TS.DataImplement.Infraestructura;
using UPC.TS.Infraestructure;

namespace UPC.TS.DataImplement
{
    public class TarifasData : BaseRepository<SRV_TARIFA>, ITarifas
    {
        public TarifasData(IUnitOfWork unit) : base(unit) { }
        public IEnumerable<SRV_TARIFA> ListarOrigen()
        {
            var tarifas = this.GetAll();
            var origen = (from c in tarifas where c.ESTREG == "1" select new SRV_TARIFA { ORITAR = c.ORITAR, CODESTTAR = c.CODESTTAR }).Distinct().Select(x => new SRV_TARIFA
            {
                ORITAR = x.ORITAR,
                CODESTTAR = x.CODESTTAR
            });
            return origen;
        }

        public IEnumerable<SRV_TARIFA> ListarDestino()
        {
            var tarifas = this.GetAll();
            var destino = (from c in tarifas where c.ESTREG == "1" select new SRV_TARIFA { DESTAR = c.DESTAR, CODESTTAR = c.CODESTTAR }).Distinct().Select(x => new SRV_TARIFA
            {
                DESTAR = x.DESTAR,
                CODESTTAR = x.CODESTTAR
            });

            return destino;
        }

        public SRV_TARIFA Registrar(SRV_TARIFA entidad)
        {

            return (SRV_TARIFA)this.Insert(entidad);
        }

        public SRV_TARIFA Actualizar(SRV_TARIFA entidad)
        {
            return (SRV_TARIFA)this.Update(entidad);
        }

        public bool Eliminar(int id)
        {
            this.Delete(id);
            return true;
        }

        public SRV_TARIFA BuscarPorId(int id)
        {
            return this.Single(id);
        }

        public IEnumerable<SRV_TARIFA> ListarTodo()
        {
            return this.GetMany(c=>c.ESTREG == "1");
        }


        public IEnumerable<SRV_TARIFA> ListarTarifaFiltro(SRV_TARIFA entidad)
        {

            if (!string.IsNullOrEmpty(entidad.ORITAR) && string.IsNullOrEmpty(entidad.DESTAR) && string.IsNullOrEmpty(entidad.CODESTTAR)) 
               return this.GetMany(c => c.ORITAR == entidad.ORITAR && c.ESTREG == "1").ToList();
            if (string.IsNullOrEmpty(entidad.ORITAR) && !string.IsNullOrEmpty(entidad.DESTAR) && string.IsNullOrEmpty(entidad.CODESTTAR))
                return this.GetMany(c => c.DESTAR == entidad.DESTAR && c.ESTREG == "1").ToList();
            if (string.IsNullOrEmpty(entidad.ORITAR) && string.IsNullOrEmpty(entidad.DESTAR) && !string.IsNullOrEmpty(entidad.CODESTTAR))
                return this.GetMany(c => c.CODESTTAR == entidad.CODESTTAR && c.ESTREG == "1").ToList();
            if (!string.IsNullOrEmpty(entidad.ORITAR) && !string.IsNullOrEmpty(entidad.DESTAR) && string.IsNullOrEmpty(entidad.CODESTTAR))
                return this.GetMany(c => c.ORITAR == entidad.ORITAR && c.DESTAR == entidad.DESTAR && c.ESTREG == "1").ToList();
            if (!string.IsNullOrEmpty(entidad.ORITAR) && string.IsNullOrEmpty(entidad.DESTAR) && !string.IsNullOrEmpty(entidad.CODESTTAR))
                return this.GetMany(c => c.ORITAR == entidad.ORITAR && c.CODESTTAR == entidad.CODESTTAR && c.ESTREG == "1").ToList();
            if (string.IsNullOrEmpty(entidad.ORITAR) && !string.IsNullOrEmpty(entidad.DESTAR) && !string.IsNullOrEmpty(entidad.CODESTTAR))
                return this.GetMany(c => c.DESTAR == entidad.DESTAR && c.CODESTTAR == entidad.CODESTTAR && c.ESTREG == "1").ToList();
            return this.GetMany(c => c.ESTREG == "1");
        }
    }
}
