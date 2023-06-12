using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allami_Beruhazasok
{
    class AllamiCeg : IBeszallito
    {
        public string Nev { get; set; }
        public szakteruletek[] Szakteruletek { get; set; }
        public double visszaosszeg { get; set; }


        //public string[] Szakterulet { get; set; }
        public AllamiCeg(string cegNeve)
        {
            this.Nev = cegNeve;
            //Szakterulet = new string[] {"Tervezés"};
            Szakteruletek = new szakteruletek[] {szakteruletek.Tervezés };
        }
        public bool ErtHozza(szakteruletek szakterulet)
        {
            if (szakterulet == szakteruletek.Tervezés)
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
            return "AllamiCeg";
        }

        public double MegvesztegetesiAr(double projectar)
        {
            return 0; //Nincs megvesztegetési ár
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
