using DatabaseFirstDWB.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstDWB.BackEnd
{
    public class BaseSC
    {
        protected NorthwindContext dbContext = new NorthwindContext();
    }
}
