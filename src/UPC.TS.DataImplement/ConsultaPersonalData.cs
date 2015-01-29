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
    public class ConsultaPersonalData : BaseRepository<SRV_VW_CONSULTA_PERSONAL>, IConsultaPersonal
    {
        public ConsultaPersonalData(IUnitOfWork unit) : base(unit) { }

        public IEnumerable<SRV_VW_CONSULTA_PERSONAL> ListarPersonal(SRV_PERSONAL personal)
        {
            if (!string.IsNullOrEmpty(personal.DNIPER) && !string.IsNullOrEmpty(personal.NOMPER) && !string.IsNullOrEmpty(personal.APEPER))
                return this.GetMany(c => c.DNIPER.Equals(personal.DNIPER) && c.NOMPER.ToLower().Contains(personal.NOMPER.ToLower()) && c.APEPER.ToLower().Contains(personal.APEPER.ToLower()));

            if (!string.IsNullOrEmpty(personal.DNIPER) && !string.IsNullOrEmpty(personal.NOMPER) && string.IsNullOrEmpty(personal.APEPER))
                return this.GetMany(c => c.DNIPER.Equals(personal.DNIPER) && c.NOMPER.ToLower().Contains(personal.NOMPER.ToLower()));

            if (!string.IsNullOrEmpty(personal.DNIPER) && string.IsNullOrEmpty(personal.NOMPER) && string.IsNullOrEmpty(personal.APEPER))
                return this.GetMany(c => c.DNIPER.Equals(personal.DNIPER));

            if (string.IsNullOrEmpty(personal.DNIPER) && !string.IsNullOrEmpty(personal.NOMPER) && !string.IsNullOrEmpty(personal.APEPER))
                return this.GetMany(c => c.NOMPER.ToLower().Contains(personal.NOMPER.ToLower()) && c.APEPER.ToLower().Contains(personal.APEPER.ToLower()));

            if (string.IsNullOrEmpty(personal.DNIPER) && string.IsNullOrEmpty(personal.NOMPER) && !string.IsNullOrEmpty(personal.APEPER))
                return this.GetMany(c => c.APEPER.ToLower().Contains(personal.APEPER.ToLower()));

            if (string.IsNullOrEmpty(personal.DNIPER) && !string.IsNullOrEmpty(personal.NOMPER) && string.IsNullOrEmpty(personal.APEPER))
                return this.GetMany(c => c.NOMPER.ToLower().Contains(personal.NOMPER.ToLower()));
            
            return this.GetMany();
        }
    }
}
