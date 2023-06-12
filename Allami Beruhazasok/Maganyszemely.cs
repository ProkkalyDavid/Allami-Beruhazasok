using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allami_Beruhazasok
{
    class Maganyszemely : IBeszallito
    {
        public string Nev { get; set; }
        public szakteruletek[] Szakteruletek { get; set; }
        public double visszaosszeg { get; set; }

        //public string[] Szakterulet { get; set; }
        public Maganyszemely(string cegNeve)
        {
            this.Nev = cegNeve;
            Szakteruletek = new szakteruletek[] { szakteruletek.Tervezés,szakteruletek.Hídépítés};
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
            return "Maganyszemely";
        }

        public double MegvesztegetesiAr(double projectar)
        {
            return 0; //Nem veszteget meg
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
