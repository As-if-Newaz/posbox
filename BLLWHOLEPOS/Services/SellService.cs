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
    public class SellService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Sell, SellDTO>();
                cfg.CreateMap<SellDTO, Sell>();
            });
            return new Mapper(config);
        }

        public static bool Create(SellDTO obj)
        {
            obj.CreatedAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
            obj.IsDeleted = false;
            var data = GetMapper().Map<Sell>(obj);
            return DataAccess.SellData().Create(data);
        }

        public static List<SellDTO> Get()
        {
            var data = DataAccess.SellData().Get();
            return GetMapper().Map<List<SellDTO>>(data);

        }

        public static SellDTO Get(int id)
        {
            var data = DataAccess.SellData().Get(id);
            return GetMapper().Map<SellDTO>(data);
        }

        public static bool Update(SellDTO obj)
        {
            var data = GetMapper().Map<Sell>(obj);
            return DataAccess.SellData().Update(data);

        }

        public static bool Delete(int id)
        {
            return DataAccess.SellData().Delete(id);

        }
    }
}
