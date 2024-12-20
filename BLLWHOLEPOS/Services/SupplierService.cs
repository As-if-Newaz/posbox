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
    public class SupplierService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Supplier, SupplierDTO>();
                cfg.CreateMap<SupplierDTO, Supplier>();
            });
            return new Mapper(config);
        }

        public static bool Create(SupplierDTO obj)
        {
            obj.CreatedAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
            obj.IsDeleted = false;
            var data = GetMapper().Map<Supplier>(obj);
            return DataAccess.SupplierData().Create(data);
        }

        public static List<SupplierDTO> Get()
        {
            var data = DataAccess.SupplierData().Get();
            return GetMapper().Map<List<SupplierDTO>>(data);

        }

        public static SupplierDTO Get(int id)
        {
            var data = DataAccess.SupplierData().Get(id);
            return GetMapper().Map<SupplierDTO>(data);
        }

        public static bool Update(SupplierDTO obj)
        {
            var data = GetMapper().Map<Supplier>(obj);
            return DataAccess.SupplierData().Update(data);

        }

        public static bool Delete(int id)
        {
            return DataAccess.SupplierData().Delete(id);

        }
    }
}
