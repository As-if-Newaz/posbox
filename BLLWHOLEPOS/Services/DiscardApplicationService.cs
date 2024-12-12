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
    public class DiscardApplicationService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DiscardApplication, DiscardApplicationDTO>();
                cfg.CreateMap<DiscardApplicationDTO, DiscardApplication>();
            });
            return new Mapper(config);
        }

        public static bool Create(DiscardApplicationDTO obj)
        {
            obj.CreatedAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
            obj.IsDeleted = false;
            var data = GetMapper().Map<DiscardApplication>(obj);
            return DataAccess.DiscardApplicationData().Create(data);
        }

        public static List<DiscardApplicationDTO> Get()
        {
            var data = DataAccess.DiscardApplicationData().Get();
            return GetMapper().Map<List<DiscardApplicationDTO>>(data);

        }

        public static DiscardApplicationDTO Get(int id)
        {
            var data = DataAccess.DiscardApplicationData().Get(id);
            return GetMapper().Map<DiscardApplicationDTO>(data);
        }

        public static bool Update(DiscardApplicationDTO obj)
        {
            var data = GetMapper().Map<DiscardApplication>(obj);
            return DataAccess.DiscardApplicationData().Update(data);

        }

        public static bool Delete(int id)
        {
            return DataAccess.DiscardApplicationData().Delete(id);

        }
    }
}
