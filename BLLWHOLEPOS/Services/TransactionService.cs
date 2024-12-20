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
    public class TransactionService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Transaction, TransactionDTO>();
                cfg.CreateMap<TransactionDTO, Transaction>();
            });
            return new Mapper(config);
        }

        public static bool Create(TransactionDTO obj)
        {
            obj.CreatedAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
            obj.IsDeleted = false;
            var data = GetMapper().Map<Transaction>(obj);
            return DataAccess.TransactionData().Create(data);
        }

        public static List<TransactionDTO> Get()
        {
            var data = DataAccess.TransactionData().Get();
            return GetMapper().Map<List<TransactionDTO>>(data);

        }

        public static TransactionDTO Get(int id)
        {
            var data = DataAccess.TransactionData().Get(id);
            return GetMapper().Map<TransactionDTO>(data);
        }

        public static bool Update(TransactionDTO obj)
        {
            var data = GetMapper().Map<Transaction>(obj);
            return DataAccess.TransactionData().Update(data);

        }

        public static bool Delete(int id)
        {
            return DataAccess.TransactionData().Delete(id);

        }
    }
}
