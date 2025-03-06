using AutoMapper;
using BLLWHOLEPOS.DTOs;
using DALWHOLEPOS;
using DALWHOLEPOS.EF.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLWHOLEPOS.Services
{
    public class BusinessService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Business, BusinessDTO>();
                cfg.CreateMap<BusinessDTO, Business>();
            });
            return new Mapper(config);
        }

        public static bool Create(BusinessDTO obj)
        {
            obj.CreatedAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
            obj.IsActive = true;
            var data = GetMapper().Map<Business>(obj);
            return DataAccess.BusinessData().Create(data);
        }

        public static List<BusinessDTO> Get()
        {
            var data = DataAccess.BusinessData().Get();
            return GetMapper().Map<List<BusinessDTO>>(data);

        }

        public static BusinessDTO Get(int id)
        {
            var data = DataAccess.BusinessData().Get(id);
            return GetMapper().Map<BusinessDTO>(data);
        }

        public static bool Update(BusinessDTO obj)
        {
            var data = GetMapper().Map<Business>(obj);
            return DataAccess.BusinessData().Update(data);

        }

        public static bool Delete(int id)
        {
            return DataAccess.BusinessData().Delete(id);

        }
    }
}
