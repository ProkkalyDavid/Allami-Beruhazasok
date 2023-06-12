using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allami_Beruhazasok
{
    class MarVanIlyenElemAFabanException : Exception
    {
        public MarVanIlyenElemAFabanException() : base("Már van ilyen elem a fában!")
        {

        }
    }
    class NemMegfeleloBemenetException : Exception
    {
        public NemMegfeleloBemenetException() : base("Nem megfelelő formátumban szerepel a beszállító a fájlban!")
        {

        }
    }
    class NemMegfeleloCegException : Exception
    {
        public NemMegfeleloCegException(): base("Nem megfelelő cég nevet adott meg!")
        {

        }
    }
}
