using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allami_Beruhazasok
{
    class IsmertCeg : IBeszallito
    {
        public string Nev { get; set; }
        public szakteruletek[] Szakteruletek { get; set; }
        public double visszaosszeg { get; set; }

        public IsmertCeg(string cegNeve)
        {
            this.Nev = cegNeve;
            Szakteruletek = new szakteruletek[] { szakteruletek.Alapozás, szakteruletek.Hídépítés };
        }
        public bool ErtHozza(szakteruletek szakterulet)
        {
            if (Szakteruletek.Contains(szakterulet))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string getTypeName()
        {
            return "IsmertCeg";
        }

        public double MegvesztegetesiAr(double projectar)
        {
            return 1.5;
        }

        public double OsszegLekerdezo()
        {
            return visszaosszeg;
        }

        public void OsszegHozzaadasa(double osszeg)
        {
            visszaosszeg += osszeg;
        }

        public void OsszegKivonasa(double osszeg)
        {
            visszaosszeg -= osszeg;
        }
    }
}
