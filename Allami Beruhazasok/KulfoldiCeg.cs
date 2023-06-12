using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allami_Beruhazasok
{
    class KulfoldiCeg : IBeszallito
    {
        public string Nev { get; set; }
        //public string[] Szakterulet { get; set; }
        public szakteruletek[] Szakteruletek { get; set; }
        public double visszaosszeg { get; set; }

        public KulfoldiCeg(string cegNeve)
        {
            this.Nev = cegNeve;
            //this.Szakterulet = new string[] {"Alapozás","Útépítés", "Hídépítés"};
            Szakteruletek = new szakteruletek[] {szakteruletek.Alapozás, szakteruletek.Útépítés, szakteruletek.Hídépítés};
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
            return "KulfoldiCeg";
        }

        public double MegvesztegetesiAr(double projectar)
        {
            return (projectar * 0.05); //A projekt ár 5%-át adja vissza
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
