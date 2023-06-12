using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allami_Beruhazasok
{
    class EgyProject
    {
        public string Nev { get; set; }
        public double Koltseg { get; set; }
        public szakteruletek[] Szakteruletek { get; set; }
        public EgyProject(string projectNeve, double projectKoltsege, szakteruletek[] szuksegesSzakterueletek)
        {
            this.Nev = projectNeve;
            this.Koltseg = projectKoltsege;
            this.Szakteruletek = new szakteruletek[szuksegesSzakterueletek.Length];
            this.Szakteruletek = szuksegesSzakterueletek;
        }
    }
    class Projectek
    {
        public List<EgyProject> osszesProject = new List<EgyProject>();
        public void ProjectHozzaadasa(EgyProject egyproject)
        {
            osszesProject.Add(egyproject);
        }
    }
}
