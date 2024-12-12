using AutoMapper;
using BLLWHOLEPOS.DTOs;
using DALWHOLEPOS.EF.TableModels;
using DALWHOLEPOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLWHOLEPOS.Services
{
    public class InvoiceService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Invoice, InvoiceDTO>();
                cfg.CreateMap<InvoiceDTO, Invoice>();
            });
            return new Mapper(config);
        }

        public static bool Create(InvoiceDTO obj)
        {
            obj.CreatedAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
            obj.IsDeleted = false;
            var data = GetMapper().Map<Invoice>(obj);
            return DataAccess.InvoiceData().Create(data);
        }

        public static List<InvoiceDTO> Get()
        {
            var data = DataAccess.InvoiceData().Get();
            return GetMapper().Map<List<InvoiceDTO>>(data);

        }

        public static InvoiceDTO Get(int id)
        {
            var data = DataAccess.InvoiceData().Get(id);
            return GetMapper().Map<InvoiceDTO>(data);
        }

        public static bool Update(InvoiceDTO obj)
        {
            var data = GetMapper().Map<Invoice>(obj);
            return DataAccess.InvoiceData().Update(data);

        }

        public static bool Delete(int id)
        {
            return DataAccess.InvoiceData().Delete(id);

        }
    }
}
