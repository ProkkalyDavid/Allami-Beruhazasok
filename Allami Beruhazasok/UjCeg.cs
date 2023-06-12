using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allami_Beruhazasok
{
    class UjCeg : IBeszallito
    {
        public string Nev { get; set; }
        public szakteruletek[] Szakteruletek { get; set; }
        public double visszaosszeg { get; set; }

        //public string[] Szakterulet { get; set; }
        public UjCeg(string cegNeve)
        {
            //this.Szakterulet = new string[] { "Alapozás", "Útépítés" };
            this.Nev = cegNeve;
            Szakteruletek = new szakteruletek[] { szakteruletek.Alapozás, szakteruletek.Útépítés};
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
            return "UjCeg";
        }

        public double MegvesztegetesiAr(double projectar)
        {
            return (projectar * 0.1); //A project ár 10%-át adja vissza
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
