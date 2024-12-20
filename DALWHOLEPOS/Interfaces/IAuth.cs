using DALWHOLEPOS.EF.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALWHOLEPOS.Interfaces
{
    public interface IAuth
    {
        Business Authentication(string buName, string password);
    }
}
