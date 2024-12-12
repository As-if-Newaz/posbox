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
    public class CustomerService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerDTO>();
                cfg.CreateMap<CustomerDTO, Customer>();
            });
            return new Mapper(config);
        }

        public static bool Create(CustomerDTO obj)
        {
            obj.CreatedAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
            obj.IsDeleted = false;
            var data = GetMapper().Map<Customer>(obj);
            return DataAccess.CustomerData().Create(data);
        }

        public static List<CustomerDTO> Get()
        {
            var data = DataAccess.CustomerData().Get();
            return GetMapper().Map<List<CustomerDTO>>(data);

        }

        public static CustomerDTO Get(int id)
        {
            var data = DataAccess.CustomerData().Get(id);
            return GetMapper().Map<CustomerDTO>(data);
        }

        public static bool Update(CustomerDTO obj)
        {
            var data = GetMapper().Map<Customer>(obj);
            return DataAccess.CustomerData().Update(data);

        }

        public static bool Delete(int id)
        {
            return DataAccess.CustomerData().Delete(id);

        }
    }
}
