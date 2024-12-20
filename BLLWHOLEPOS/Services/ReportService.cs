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
    public class ReportService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Report, ReportDTO>();
                cfg.CreateMap<ReportDTO, Report>();
            });
            return new Mapper(config);
        }

        public static bool Create(ReportDTO obj)
        {
            obj.CreatedAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
            obj.IsDeleted = false;
            var data = GetMapper().Map<Report>(obj);
            return DataAccess.ReportData().Create(data);
        }

        public static List<ReportDTO> Get()
        {
            var data = DataAccess.ReportData().Get();
            return GetMapper().Map<List<ReportDTO>>(data);

        }

        public static ReportDTO Get(int id)
        {
            var data = DataAccess.ReportData().Get(id);
            return GetMapper().Map<ReportDTO>(data);
        }

        public static bool Update(ReportDTO obj)
        {
            var data = GetMapper().Map<Report>(obj);
            return DataAccess.ReportData().Update(data);

        }

        public static bool Delete(int id)
        {
            return DataAccess.ReportData().Delete(id);

        }
    }
}
