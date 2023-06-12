using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allami_Beruhazasok
{
    class ProjectKioszto
    {
        EgyProject[] EgyProjectTomb;
        AllamiCeg[] AllamicegTomb;
        UjCeg[] UjCegTomb;
        BaratiCeg[] BaratiCegTomb;
        Maganyszemely[] MaganszemelyTomb;
        KulfoldiCeg[] KulfoldiCegTomb;
        IdegenCeg[] IdegenCegTomb;
        IsmertCeg[] IsmertCegTomb;
        private IBeszallito[][] r;
        string[,] e;
        bool van = false;
        bool notfound = false;
        int j = 0;
        
        public ProjectKioszto(List<EgyProject> projectek, List<AllamiCeg> Allami, List<UjCeg> Uj, List<BaratiCeg> Barati, List<Maganyszemely> Magan, List<KulfoldiCeg> Kulfoldi, List<IdegenCeg> Idegen, List<IsmertCeg> Ismert)
        {
            EgyProjectTomb = new EgyProject[projectek.Count];
            for (int i = 0; i < EgyProjectTomb.Length; i++)
            {
                EgyProjectTomb[i] = projectek[i];
            }
            AllamicegTomb = new AllamiCeg[Allami.Count];
            for (int i = 0; i < AllamicegTomb.Length; i++)
            {
                AllamicegTomb[i] = Allami[i];
            }
            UjCegTomb = new UjCeg[Uj.Count];
            for (int i = 0; i < UjCegTomb.Length; i++)
            {
                UjCegTomb[i] = Uj[i];
            }
            BaratiCegTomb = new BaratiCeg[Barati.Count];
            for (int i = 0; i < BaratiCegTomb.Length; i++)
            {
                BaratiCegTomb[i] = Barati[i];
            }
            MaganszemelyTomb = new Maganyszemely[Magan.Count];
            for (int i = 0; i < MaganszemelyTomb.Length; i++)
            {
                MaganszemelyTomb[i] = Magan[i];
            }
            KulfoldiCegTomb = new KulfoldiCeg[Kulfoldi.Count];
            for (int i = 0; i < KulfoldiCegTomb.Length; i++)
            {
                KulfoldiCegTomb[i] = Kulfoldi[i];
            }
            IdegenCegTomb = new IdegenCeg[Idegen.Count];
            for (int i = 0; i < IdegenCegTomb.Length; i++)
            {
                IdegenCegTomb[i] = Idegen[i];
            }
            IsmertCegTomb = new IsmertCeg[Ismert.Count];
            for (int i = 0; i < IsmertCegTomb.Length; i++)
            {
                IsmertCegTomb[i] = Ismert[i];
            }
            r = new IBeszallito[][] {
            AllamicegTomb,
            UjCegTomb,
            BaratiCegTomb,
            MaganszemelyTomb,
            KulfoldiCegTomb,
            IdegenCegTomb,
            IsmertCegTomb};
            e = new string[EgyProjectTomb.Length,2];
        }
        public void BTS()
        {
            _BTS(r, 0, e, ref van, EgyProjectTomb, j,ref notfound);
            KiosztottMunkakKiirasa(e);
        }
        private void _BTS(IBeszallito[][] r,int szint, string[,] e,ref bool van, EgyProject[] EgyProjectTomb,int j,ref bool notfound)
        {
            int i = -1;
            while (van == false && notfound == false)
            {
                i++;
                if (i < r[szint].Length && JoASzakterulet(r[szint][i],EgyProjectTomb[j]) && Fk(r[szint][i],EgyProjectTomb[j].Koltseg))
                {
                    e[j, 0] = EgyProjectTomb[j].Nev;
                    e[j, 1] = r[szint][i].Nev;
                    r[szint][i].OsszegHozzaadasa(r[szint][i].MegvesztegetesiAr(EgyProjectTomb[j].Koltseg));
                    if (j == EgyProjectTomb.Length-1)
                    {
                        van = true;
                    }
                    else
                    {
                        _BTS(r, 0, e, ref van, EgyProjectTomb, j + 1, ref notfound);
                        notfound = false;
                        r[szint][i].OsszegKivonasa(r[szint][i].MegvesztegetesiAr(EgyProjectTomb[j].Koltseg));
                    }
                }
                else if (i < r[szint].Length-1)
                {
                    i++;
                }
                else if (szint < 6)
                {
                    szint++;
                    i = -1;
                }
                else
                {
                    notfound = true;
                }
            }
        }
        private bool JoASzakterulet(IBeszallito ceg, EgyProject project)
        {
            int szamolo = 0;
            for (int i = 0; i < project.Szakteruletek.Length; i++)
            {
                if (ceg.Szakteruletek.Contains(project.Szakteruletek[i]))
                {
                    szamolo++;
                }
            }
            if (szamolo == project.Szakteruletek.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool Fk(IBeszallito ceg, double projectar)
        {
            bool ok = false;
            if ((ceg.OsszegLekerdezo() + ceg.MegvesztegetesiAr(projectar)) <= 2)
            {
                ok = true;
            }
            return ok;
        }
        private void KiosztottMunkakKiirasa(string[,] e)
        {
            for (int i = 0; i < EgyProjectTomb.Length; i++)
            {
                Console.WriteLine($"{e[i,0]} project nyertese: {e[i,1]}");
            }
        }

    }
}
