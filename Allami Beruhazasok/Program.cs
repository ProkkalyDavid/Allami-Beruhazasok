using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Allami_Beruhazasok
{
    class Program
    {
        static void Main(string[] args)
        {
            Projectek projectek = new Projectek();
            BinarisFa<IBeszallito> fa = new BinarisFa<IBeszallito>();
            #region Project Beolvasás
            FileStream fs = new FileStream("projectek.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string egysor = sr.ReadLine();
            string[] tordelt = new string[3];
            string nev;
            string osszegString;
            string osszegString2 = "";
            double osszeg;
            string[] szakterueletekTomb = new string[4];
            szakteruletek[] Szakteruletek;
            while (egysor != null)
            {
                tordelt = egysor.Split('/');
                nev = tordelt[0];
                osszegString = tordelt[1];
                int i = 0;
                while (osszegString[i] != 'M')
                {
                    osszegString2 += osszegString[i];
                    i++;
                }
                osszeg = Convert.ToDouble(osszegString2);
                osszegString2 = "";
                szakterueletekTomb = tordelt[2].Split(',');
                Szakteruletek = new szakteruletek[szakterueletekTomb.Length];
                for (int j = 0; j < szakterueletekTomb.Length; j++)
                {
                    if (szakterueletekTomb[j] == "Tervezés") Szakteruletek[j] = szakteruletek.Tervezés;
                    else if (szakterueletekTomb[j] == "Alapozás") Szakteruletek[j] = szakteruletek.Alapozás;
                    else if (szakterueletekTomb[j] == "Útépítés") Szakteruletek[j] = szakteruletek.Útépítés;
                    else Szakteruletek[j] = szakteruletek.Hídépítés;
                }
                projectek.ProjectHozzaadasa(new EgyProject(nev, osszeg, Szakteruletek));
                egysor = sr.ReadLine();
            }
            List<EgyProject> uj = projectek.osszesProject;
            #endregion
            #region Beszállító Beolvasás
            List<IBeszallito> osszesBeszallito = new List<IBeszallito>();
            fs = new FileStream("beszallitok.txt",FileMode.Open);
            sr = new StreamReader(fs);
            egysor = sr.ReadLine();
            while (egysor != null)
            {
                tordelt = egysor.Split('/');
                nev = tordelt[0];
                szakterueletekTomb = tordelt[1].Split(',');
                Szakteruletek = new szakteruletek[szakterueletekTomb.Length];
                for (int j = 0; j < szakterueletekTomb.Length; j++)
                {
                    if (szakterueletekTomb[j] == "Tervezés") Szakteruletek[j] = szakteruletek.Tervezés;
                    else if (szakterueletekTomb[j] == "Alapozás") Szakteruletek[j] = szakteruletek.Alapozás;
                    else if (szakterueletekTomb[j] == "Útépítés") Szakteruletek[j] = szakteruletek.Útépítés;
                    else Szakteruletek[j] = szakteruletek.Hídépítés;
                }
                if (Szakteruletek.Length == 1 && Szakteruletek.Contains(szakteruletek.Tervezés))
                {
                    osszesBeszallito.Add(new AllamiCeg(nev));
                }
                else if (Szakteruletek.Length == 2 && Szakteruletek.Contains(szakteruletek.Alapozás) && Szakteruletek.Contains(szakteruletek.Útépítés))
                {
                    osszesBeszallito.Add(new UjCeg(nev));
                }
                else if (Szakteruletek.Length == 4 && Szakteruletek.Contains(szakteruletek.Tervezés) && Szakteruletek.Contains(szakteruletek.Alapozás) && Szakteruletek.Contains(szakteruletek.Útépítés) && Szakteruletek.Contains(szakteruletek.Hídépítés))
                {
                    osszesBeszallito.Add(new BaratiCeg(nev));
                }
                else if (Szakteruletek.Length == 2 && Szakteruletek.Contains(szakteruletek.Tervezés) && Szakteruletek.Contains(szakteruletek.Hídépítés))
                {
                    osszesBeszallito.Add(new Maganyszemely(nev));
                }
                else if (Szakteruletek.Length == 3 && Szakteruletek.Contains(szakteruletek.Alapozás) && Szakteruletek.Contains(szakteruletek.Útépítés) && Szakteruletek.Contains(szakteruletek.Hídépítés))
                {
                    osszesBeszallito.Add(new KulfoldiCeg(nev));
                }
                else if (Szakteruletek.Length == 2 && Szakteruletek.Contains(szakteruletek.Tervezés) && Szakteruletek.Contains(szakteruletek.Útépítés))
                {
                    osszesBeszallito.Add(new IdegenCeg(nev));
                }
                else if (Szakteruletek.Length == 2 && Szakteruletek.Contains(szakteruletek.Alapozás) && Szakteruletek.Contains(szakteruletek.Hídépítés))
                {
                    osszesBeszallito.Add(new IsmertCeg(nev));
                }
                egysor = sr.ReadLine();
            }
            for (int i = 0; i < osszesBeszallito.Count; i++)
            {
                if (osszesBeszallito[i].Szakteruletek.Length == 1 && osszesBeszallito[i].Szakteruletek.Contains(szakteruletek.Tervezés))
                {
                    fa.Beszuras(new AllamiCeg(osszesBeszallito[i].Nev));
                }
                else if (osszesBeszallito[i].Szakteruletek.Length == 2 && osszesBeszallito[i].Szakteruletek.Contains(szakteruletek.Alapozás) && osszesBeszallito[i].Szakteruletek.Contains(szakteruletek.Útépítés))
                {
                    fa.Beszuras(new UjCeg(osszesBeszallito[i].Nev));
                }
                else if (osszesBeszallito[i].Szakteruletek.Length == 4 && osszesBeszallito[i].Szakteruletek.Contains(szakteruletek.Tervezés) && osszesBeszallito[i].Szakteruletek.Contains(szakteruletek.Alapozás) && osszesBeszallito[i].Szakteruletek.Contains(szakteruletek.Útépítés) && osszesBeszallito[i].Szakteruletek.Contains(szakteruletek.Hídépítés))
                {
                    fa.Beszuras(new BaratiCeg(osszesBeszallito[i].Nev));
                }
                else if (osszesBeszallito[i].Szakteruletek.Length == 2 && osszesBeszallito[i].Szakteruletek.Contains(szakteruletek.Tervezés) && osszesBeszallito[i].Szakteruletek.Contains(szakteruletek.Hídépítés))
                {
                    fa.Beszuras(new Maganyszemely(osszesBeszallito[i].Nev));
                }
                else if (osszesBeszallito[i].Szakteruletek.Length == 3 && osszesBeszallito[i].Szakteruletek.Contains(szakteruletek.Alapozás) && osszesBeszallito[i].Szakteruletek.Contains(szakteruletek.Útépítés) && osszesBeszallito[i].Szakteruletek.Contains(szakteruletek.Hídépítés))
                {
                    fa.Beszuras(new KulfoldiCeg(osszesBeszallito[i].Nev));
                }
                else if (osszesBeszallito[i].Szakteruletek.Length == 2 && osszesBeszallito[i].Szakteruletek.Contains(szakteruletek.Tervezés) && osszesBeszallito[i].Szakteruletek.Contains(szakteruletek.Útépítés))
                {
                    fa.Beszuras(new IdegenCeg(osszesBeszallito[i].Nev));
                }
                else if (osszesBeszallito[i].Szakteruletek.Length == 2 && osszesBeszallito[i].Szakteruletek.Contains(szakteruletek.Alapozás) && osszesBeszallito[i].Szakteruletek.Contains(szakteruletek.Hídépítés))
                {
                    fa.Beszuras(new IsmertCeg(osszesBeszallito[i].Nev));
                }
            }
            #endregion
            List<IBeszallito> uj2 = new List<IBeszallito>();
            Console.WriteLine("Adja meg a pályáó cégek neveit. Ha nem szeretne több céget megadni, írja be hogy 'mehet'");
            try
            {
                uj2 = fa.PalyazoCegek();
            }
            catch (NemMegfeleloCegException e)
            {
                Console.WriteLine(e.Message);
            }
            for (int i = 0; i < uj2.Count; i++)
            {
                fa.Csoportositas(uj2[i]);
            } //csoportosítás
            ProjectKioszto projectkioszto = new ProjectKioszto(projectek.osszesProject,fa.AllamiCegLista,fa.UjCegLista,fa.BaratiCegLista,fa.MaganszemelyLista,fa.KulfoldiCegLista,fa.IdegenCegLista,fa.IsmertCegLista);
            projectkioszto.BTS();
            Console.WriteLine("Adja meg a törölni kívánt cég(ek) nevét. Ha nem szeretne több céget megadni, írja hogy 'mehet'.");
            string asd = "";
            try
            {
                while (asd != "nem")
                {
                    fa.TorlendoCegek(ref osszesBeszallito);
                    Console.WriteLine("Szeretne további cégeket törölni? Ha nem, írja be a 'nem' szót, ha igen, közvetlenül a cég nevét írja be.");
                    asd = Console.ReadLine();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Nem megfelelő cég nevet adott meg");
            }
            uj2 = fa.PalyazoCegekUjra();
            BinarisFa<IBeszallito> fa2 = new BinarisFa<IBeszallito>();
            for (int i = 0; i < osszesBeszallito.Count; i++)
            {
                if (osszesBeszallito[i].Szakteruletek.Length == 1 && osszesBeszallito[i].Szakteruletek.Contains(szakteruletek.Tervezés))
                {
                    fa2.Beszuras(new AllamiCeg(osszesBeszallito[i].Nev));
                }
                else if (osszesBeszallito[i].Szakteruletek.Length == 2 && osszesBeszallito[i].Szakteruletek.Contains(szakteruletek.Alapozás) && osszesBeszallito[i].Szakteruletek.Contains(szakteruletek.Útépítés))
                {
                    fa2.Beszuras(new UjCeg(osszesBeszallito[i].Nev));
                }
                else if (osszesBeszallito[i].Szakteruletek.Length == 4 && osszesBeszallito[i].Szakteruletek.Contains(szakteruletek.Tervezés) && osszesBeszallito[i].Szakteruletek.Contains(szakteruletek.Alapozás) && osszesBeszallito[i].Szakteruletek.Contains(szakteruletek.Útépítés) && osszesBeszallito[i].Szakteruletek.Contains(szakteruletek.Hídépítés))
                {
                    fa2.Beszuras(new BaratiCeg(osszesBeszallito[i].Nev));
                }
                else if (osszesBeszallito[i].Szakteruletek.Length == 2 && osszesBeszallito[i].Szakteruletek.Contains(szakteruletek.Tervezés) && osszesBeszallito[i].Szakteruletek.Contains(szakteruletek.Hídépítés))
                {
                    fa2.Beszuras(new Maganyszemely(osszesBeszallito[i].Nev));
                }
                else if (osszesBeszallito[i].Szakteruletek.Length == 3 && osszesBeszallito[i].Szakteruletek.Contains(szakteruletek.Alapozás) && osszesBeszallito[i].Szakteruletek.Contains(szakteruletek.Útépítés) && osszesBeszallito[i].Szakteruletek.Contains(szakteruletek.Hídépítés))
                {
                    fa2.Beszuras(new KulfoldiCeg(osszesBeszallito[i].Nev));
                }
                else if (osszesBeszallito[i].Szakteruletek.Length == 2 && osszesBeszallito[i].Szakteruletek.Contains(szakteruletek.Tervezés) && osszesBeszallito[i].Szakteruletek.Contains(szakteruletek.Útépítés))
                {
                    fa2.Beszuras(new IdegenCeg(osszesBeszallito[i].Nev));
                }
                else if (osszesBeszallito[i].Szakteruletek.Length == 2 && osszesBeszallito[i].Szakteruletek.Contains(szakteruletek.Alapozás) && osszesBeszallito[i].Szakteruletek.Contains(szakteruletek.Hídépítés))
                {
                    fa2.Beszuras(new IsmertCeg(osszesBeszallito[i].Nev));
                }
            } //fa2-be beszúrás
            for (int i = 0; i < uj2.Count; i++)
            {
                fa2.Csoportositas(uj2[i]);
            } //fa2 csoportosítás
            projectkioszto = new ProjectKioszto(projectek.osszesProject, fa2.AllamiCegLista, fa2.UjCegLista, fa2.BaratiCegLista, fa2.MaganszemelyLista, fa2.KulfoldiCegLista, fa2.IdegenCegLista, fa2.IsmertCegLista);
            projectkioszto.BTS();
            fa = null;
            Console.ReadLine();
        }
    }
}
