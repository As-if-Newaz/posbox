using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALWHOLEPOS.Interfaces
{
    public interface IRepo<CLASS,ID,RETURN>
    {
        RETURN Create(CLASS obj);
        List<CLASS> Get();

        CLASS Get(ID id);

        RETURN Update(CLASS obj);

        bool Delete(ID id);
    }
}
