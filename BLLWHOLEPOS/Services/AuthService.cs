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
    internal class AuthService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<LoginToken, LoginTokenDTO>();
                cfg.CreateMap<LoginTokenDTO, LoginToken>();
                cfg.CreateMap<Business, BusinessDTO>();
                cfg.CreateMap<BusinessDTO, Business>();
            });
            return new Mapper(config);
        }
        public static LoginTokenDTO Authentication(string buName, string password)
        {
            var data = DataAccess.AuthData().Authentication(buName, password);

            if (data != null)
            {
                LoginToken t = new LoginToken();
                t.CreatedAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
                var Key = Guid.NewGuid().ToString();
                t.Key = Key.Substring(0, 15);
                t.BusinessId = data.Id;
                t.IsValid = true;
                var token = DataAccess.LoginTokenData().Create(t);
                return GetMapper().Map<LoginTokenDTO>(token);
            }
            return null;
        }
        public static bool IsTokenValid(string key)
        {
            var token = DataAccess.LoginTokenData().Get(key);
            if (token != null && token.ExpiredAt == null && token.IsValid == true)
            {

                return true;
            }
            return false;
        }

        public static bool LogoutToken(string key)
        {
            if (DataAccess.LoginTokenData().Get(key) != null)
            {
                var token = DataAccess.LoginTokenData().Delete(key);
                //GetMapper().Map<TokenDTO>(token);
                return true;
            }
            return false;
        }
    }
}
