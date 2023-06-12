using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allami_Beruhazasok
{
    class BaratiCeg : IBeszallito
    {
        public string Nev { get; set; }
        public szakteruletek[] Szakteruletek { get; set; }
        public double visszaosszeg { get; set; }

        //public string[] Szakterulet { get; set; }
        public BaratiCeg(string cegNeve)
        {
            this.Nev = cegNeve;
            //this.Szakterulet = new string[] {"Tervezés","Alapozás","Útépítés","Hídépítés"}; //Bármihez érthet
            Szakteruletek = new szakteruletek[] { szakteruletek.Tervezés,szakteruletek.Alapozás,szakteruletek.Útépítés,szakteruletek.Hídépítés};
        }
        public bool ErtHozza(szakteruletek szakterulet)
        {
            /*
            switch (szakterulet)
            {
                case "Tervezés":
                    return true;
                case "Alapozás":
                    return true;
                case "Útépítés":
                    return true;
                case "Hídépítés":
                    return true;
                default:
                    return false;
            */
            /*
            if (Szakteruletek.Contains(szakterulet))
            {
                return true;
            }
            else
            {
                return false;
            }
            */
            return true; //Ha ért mindenhez, úgyis igazat fog visszaadni
        }
        public string getTypeName()
        {
            return "BaratiCeg";
        }

        public double MegvesztegetesiAr(double projectar)
        {
            return 1; //Fix 1 milliót ad vissza
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
