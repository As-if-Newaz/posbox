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
    public class TransferService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Transfer, TransferDTO>();
                cfg.CreateMap<TransferDTO, Transfer>();
            });
            return new Mapper(config);
        }

        public static bool Create(TransferDTO obj)
        {
            obj.CreatedAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
            obj.IsDeleted = true;
            var data = GetMapper().Map<Transfer>(obj);
            return DataAccess.TransferData().Create(data);
        }

        public static List<TransferDTO> Get()
        {
            var data = DataAccess.TransferData().Get();
            return GetMapper().Map<List<TransferDTO>>(data);

        }

        public static TransferDTO Get(int id)
        {
            var data = DataAccess.TransferData().Get(id);
            return GetMapper().Map<TransferDTO>(data);
        }

        public static bool Update(TransferDTO obj)
        {
            var data = GetMapper().Map<Transfer>(obj);
            return DataAccess.TransferData().Update(data);

        }

        public static bool Delete(int id)
        {
            return DataAccess.TransferData().Delete(id);

        }
    }
}
