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
    public class QuickSellService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<QuickSell, QuickSellDTO>();
                cfg.CreateMap<QuickSellDTO, QuickSell>();
            });
            return new Mapper(config);
        }

        public static bool Create(QuickSellDTO obj)
        {
            obj.CreatedAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
            obj.IsDeleted = false;
            var data = GetMapper().Map<QuickSell>(obj);
            return DataAccess.QuickSellData().Create(data);
        }

        public static List<QuickSellDTO> Get()
        {
            var data = DataAccess.QuickSellData().Get();
            return GetMapper().Map<List<QuickSellDTO>>(data);

        }

        public static QuickSellDTO Get(int id)
        {
            var data = DataAccess.QuickSellData().Get(id);
            return GetMapper().Map<QuickSellDTO>(data);
        }

        public static bool Update(QuickSellDTO obj)
        {
            var data = GetMapper().Map<QuickSell>(obj);
            return DataAccess.QuickSellData().Update(data);

        }

        public static bool Delete(int id)
        {
            return DataAccess.QuickSellData().Delete(id);

        }
    }
}
