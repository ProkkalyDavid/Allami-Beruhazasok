using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allami_Beruhazasok
{
    public  enum szakteruletek { Tervezés, Alapozás, Útépítés, Hídépítés}
    interface IBeszallito
    {
        string Nev { get; set; }
        //string[] Szakterulet { get; set; }
        double visszaosszeg { get; set; }
        szakteruletek[] Szakteruletek { get;set; }
        bool ErtHozza(szakteruletek szakterulet);
        double MegvesztegetesiAr(double projectar);
        double OsszegLekerdezo();
        void OsszegHozzaadasa(double osszeg);
        void OsszegKivonasa(double osszeg);
    }
}
