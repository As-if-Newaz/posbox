using DALWHOLEPOS.EF.TableModels;
using DALWHOLEPOS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALWHOLEPOS.Repos
{
    internal class LoginTokenRepo : Repo, IRepo<LoginToken, string, LoginToken>
    {
        public LoginToken Create(LoginToken obj)
        {
            db.LoginTokens.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(string id)
        {
            var exobj = Get(id);
            exobj.IsValid = false;
            exobj.ExpiredAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
            db.SaveChanges();
            return true;
        }

        public List<LoginToken> Get()
        {
            return db.LoginTokens.Where(p => p.IsValid == true).ToList();
        }

        public LoginToken Get(string id)
        {
            return db.LoginTokens.Where(t => t.Key.Equals(id) && t.IsValid == true).FirstOrDefault();
        }

        public LoginToken Update(LoginToken obj)
        {
            var exobj = Get(obj.Key);
            if (exobj == null)
            {
                return obj;
            }
            if (obj.Key != null)
            {
                exobj.Key = obj.Key;
            }

            if (obj.CreatedAt != default(DateTime))
                exobj.CreatedAt = obj.CreatedAt;

            if (obj.ExpiredAt != default(DateTime))
                exobj.ExpiredAt = obj.ExpiredAt;

            if (obj.Business != null)
            {
                exobj.Business = obj.Business;
            }

            db.SaveChanges();

            return obj;
        }
    }
}
