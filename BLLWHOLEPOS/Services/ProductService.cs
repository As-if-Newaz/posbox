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
    public class ProductService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductDTO>();
                cfg.CreateMap<ProductDTO, Product>();
            });
            return new Mapper(config);
        }

        public static bool Create(ProductDTO obj)
        {
            obj.CreatedAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
            obj.AddingDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
            obj.IsDeleted = false;
            var data = GetMapper().Map<Product>(obj);
            return DataAccess.ProductData().Create(data);
        }

        public static List<ProductDTO> Get()
        {
            var data = DataAccess.ProductData().Get();
            return GetMapper().Map<List<ProductDTO>>(data);

        }

        public static ProductDTO Get(int id)
        {
            var data = DataAccess.ProductData().Get(id);
            return GetMapper().Map<ProductDTO>(data);
        }

        public static bool Update(ProductDTO obj)
        {
            var data = GetMapper().Map<Product>(obj);
            return DataAccess.ProductData().Update(data);

        }

        public static bool Delete(int id)
        {
            return DataAccess.ProductData().Delete(id);

        }


    }
}
