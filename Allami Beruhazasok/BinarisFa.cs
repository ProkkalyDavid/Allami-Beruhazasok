using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allami_Beruhazasok
{
    class FaElem<T> where T : IBeszallito
    {
        public T tartalom;
        public int kulcs;
        public FaElem<T> jobb;
        public FaElem<T> bal;
        public FaElem(T tartalom)
        {
            this.tartalom = tartalom;
            this.kulcs = Kulcs(this.tartalom.Nev);
        }
        private int Kulcs(string neve)
        {
            int vissza = 0;
            for (int i = 0; i < neve.Length; i++)
            {
                vissza += (int)neve[i];
            }
            return vissza;
        }
    }
    class BinarisFa<T> where T : IBeszallito
    {
        public FaElem<T> gyoker;
        public void Beszuras(T tartalom)
        {
            _Beszuras(ref gyoker, tartalom, Kulcs(tartalom.Nev));
        }
        private void _Beszuras(ref FaElem<T> p, T tartalom, int kulcs)
        {
            if (p == null)
            {
                p = new FaElem<T>(tartalom);
            }
            else if (p.kulcs > kulcs)
            {
                _Beszuras(ref p.jobb, tartalom, kulcs);
            }
            else if (p.kulcs < kulcs)
            {
                _Beszuras(ref p.bal, tartalom, kulcs);
            }
            else
            {
                throw new MarVanIlyenElemAFabanException();
            }
        }
        private IBeszallito Kereses(ref IBeszallito vissza, FaElem<T> p, int kulcs) 
        {
            if (p == null)
            {
                throw new NemMegfeleloCegException();
            }
            else if (p.kulcs.CompareTo(kulcs) > 0)
            {
                Kereses(ref vissza, p.jobb, kulcs);
            }
            else if (p.kulcs.CompareTo(kulcs) < 0)
            {
                Kereses(ref vissza, p.bal, kulcs);
            }
            else if (p.kulcs == kulcs)
            {
                vissza = p.tartalom;
            }
            return vissza;
        }
        List<IBeszallito> palyazoCegek = new List<IBeszallito>();
        public List<IBeszallito> PalyazoCegek()
        {
            IBeszallito atmeneti = null;
            string r = "";
            int keresendoKulcs = 0;
            r = Console.ReadLine();
            while (r != "mehet")
            {
                keresendoKulcs = Kulcs(r);
                palyazoCegek.Add(Kereses(ref atmeneti, gyoker, keresendoKulcs));
                r = Console.ReadLine();
            }
            return palyazoCegek;
        }
        public List<IBeszallito> PalyazoCegekUjra()
        {
            return palyazoCegek;
        }
        private int Kulcs(string neve)
        {
            int vissza = 0;
            for (int i = 0; i < neve.Length; i++)
            {
                vissza += (int)neve[i];
            }
            return vissza;
        }
        public void TorlendoCegek(ref List<IBeszallito> osszesbeszallito)
        {
            string r = "";
            while (r != "mehet")
            {
                r = Console.ReadLine();
                if (r != "mehet")
                {
                    this.palyazoCegek.Remove(torlendoCegKereses(palyazoCegek, r));
                    osszesbeszallito.Remove(torlendoCegKereses(osszesbeszallito, r));
                }
            }
        }
        private IBeszallito torlendoCegKereses(List<IBeszallito> osszesbeszallito, string r)
        {
            int index = 0;
            while (osszesbeszallito[index].Nev != r)
            {
                index++;
            }
            return osszesbeszallito[index];
        }
        public void UjFa(T tartalom)
        {
            Beszuras(tartalom);
        }

        //csoportosítás
        public List<AllamiCeg> AllamiCegLista = new List<AllamiCeg>();
        public List<UjCeg> UjCegLista = new List<UjCeg>();
        public List<BaratiCeg> BaratiCegLista = new List<BaratiCeg>();
        public List<Maganyszemely> MaganszemelyLista = new List<Maganyszemely>();
        public List<KulfoldiCeg> KulfoldiCegLista = new List<KulfoldiCeg>();
        public List<IdegenCeg> IdegenCegLista = new List<IdegenCeg>();
        public List<IsmertCeg> IsmertCegLista = new List<IsmertCeg>();
        public void Csoportositas(IBeszallito ceg)
        {
            if (ceg is AllamiCeg)
            {
                AllamiCegLista.Add(ceg as AllamiCeg);
            }
            else if (ceg is UjCeg)
            {
                UjCegLista.Add(ceg as UjCeg);
            }
            else if (ceg is BaratiCeg)
            {
                BaratiCegLista.Add(ceg as BaratiCeg);
            }
            else if (ceg is Maganyszemely)
            {
                MaganszemelyLista.Add(ceg as Maganyszemely);
            }
            else if (ceg is KulfoldiCeg)
            {
                KulfoldiCegLista.Add(ceg as KulfoldiCeg);
            }
            else if (ceg is IdegenCeg)
            {
                IdegenCegLista.Add(ceg as IdegenCeg);
            }
            else
            {
                IsmertCegLista.Add(ceg as IsmertCeg);
            }
            ;
        }
    }
}
