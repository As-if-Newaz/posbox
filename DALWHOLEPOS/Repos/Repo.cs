using DALWHOLEPOS.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALWHOLEPOS.Repos
{
    internal class Repo
    {
        protected Context db;  //kept protected so that child classes can access

        internal Repo()
        {
            db = new Context();
        }
    }
}
