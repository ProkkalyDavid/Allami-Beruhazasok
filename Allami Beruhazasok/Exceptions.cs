using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allami_Beruhazasok
{
    class NincsMegvesztegetesiArException : Exception
    {
        public NincsMegvesztegetesiArException(string hibauzi) : base(hibauzi)
        {

        }
    }
}
