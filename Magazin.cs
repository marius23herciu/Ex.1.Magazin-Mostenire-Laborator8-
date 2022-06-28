using System;
using System.Collections.Generic;
using System.Text;

namespace Ex._1.Magazin_Mostenire__Laborator8_
{
    class Magazin
    {
        /*• Va conține lista produselor
          • Va permite adăugarea de produse
          • Va avea o metodă care va returna valoarea curentă a vânzărilor
          • Va expune o modalitate pentru cumpărarea televizoarelor, a becurilor și a telefoanelor
                            o La cumpărarea unui produs
                                   ▪ Se va verifica dacă produsul este pe stoc
                                   ▪ Produsul va fi retras din stoc
                                   ▪ Prețul va fi încasat
        
         
         Suplimentar

         Magazinul
         • Va avea o parolă pe care o va seta automat telefoanelor atunci când un telefon nou va intra în
         stoc
         • Va oferi o metodă de schimbare a parolei (aceeași regulă ca la schimbarea parolei telefonului) la
         apelul căreia, dacă parola veche este corectă, va schimba parola tuturor telefoanelor aflate în
         stoc
         • La vânzarea unui telefon, parola acestuia va fi resetată pe valoarea inițiala (empty string) astfel
         încât cumpărătorul să își poată seta propria parolă
         */

        private List<TV> listaTV = new List<TV>();
        private List<Bec> listaBecuri = new List<Bec>();
        private List<Telefon> listaTelefoane = new List<Telefon>();
        private CasaDeMarcat casaDeMarcat = new CasaDeMarcat();
        private SistemAudio sistemAudio = new SistemAudio();
        private string parolaAutomata = "0000";

        /// <summary>
        /// Schimba parola pentru toate telefoanele din magazin daca parola veche introdusa este corecta.
        /// </summary>
        /// <param name="parolaVeche"></param>
        /// <param name="parolaNoua"></param>
        public void SchimbareParolaMagazin(string parolaVeche, string parolaNoua)
        {
            if (this.parolaAutomata == parolaVeche)
            {
                this.parolaAutomata = parolaNoua;
            }
            foreach (Telefon telefon in this.listaTelefoane)
            {
                parolaVeche = telefon.GetParola();
                telefon.SchimbaParola(parolaVeche, parolaNoua);
            }
        }

        /// <summary>
        /// Aprinde becurile din magazin, porneste sistem audio, porneste tv urile pe un canal cu muzica
        /// si deblocheaza ecranele telefoanelor.
        /// </summary>
        public void ClientIntra()
        {
            foreach (Bec bec in this.listaBecuri)
            {
                bec.AprindeBec();
            }
            Console.WriteLine($"S-au aprins {this.listaBecuri.Count} becuri.");

            sistemAudio.Porneste();
            Console.WriteLine($"S-a pornit sistemul audio.");

            foreach (TV tv in this.listaTV)
            {
                tv.Porneste();
                tv.SetPostTVMuzica();
            }
            Console.WriteLine($"S-au deschis {this.listaTV.Count} televizoare pe un canal cu muzica.");

            foreach (Telefon telefon in this.listaTelefoane)
            {
                telefon.Deblocheaza(this.parolaAutomata);
            }
        }
        /// <summary>
        /// Stinge becurile din magazin, opreste sistem audio, opreste tv urile 
        /// si blocheaza ecranele telefoanelor.
        /// </summary>
        public void ClientIese()
        {
            foreach (Bec bec in this.listaBecuri)
            {
                bec.StingeBec();
            }
            Console.WriteLine($"S-au stins {this.listaBecuri.Count} becuri.");

            sistemAudio.Opreste();
            Console.WriteLine($"S-a oprit sistemul audio.");

            foreach (TV tv in this.listaTV)
            {
                tv.Opreste();
            }
            Console.WriteLine($"S-au inchis {this.listaTV.Count} televizoare.");

            foreach (Telefon telefon in this.listaTelefoane)
            {
                telefon.Blocheaza();
            }
            Console.WriteLine($"S-au blocat {this.listaTelefoane.Count} telefoane");
        }
        /// <summary>
        /// Adauga tv in stocul magazinului.
        /// </summary>
        /// <param name="tv"></param>
        public void AdaugareTV(TV tv)
        {
            this.listaTV.Add(tv);
        }
        /// <summary>
        /// Adauga bec in stocul magazinului.
        /// </summary>
        /// <param name="bec"></param>
        public void AdaugareBec(Bec bec)
        {
            this.listaBecuri.Add(bec);
        }
        /// <summary>
        /// Adauga telefon in stocul magazinului.
        /// </summary>
        /// <param name="telefon"></param>
        public void AdaugareTelefon(Telefon telefon)
        {
            telefon.SchimbaParola(string.Empty, this.parolaAutomata);
            this.listaTelefoane.Add(telefon);
        }
        /// <summary>
        /// Returneaza suma din casa de marcat.
        /// </summary>
        /// <returns></returns>
        public int GetValoareCurentaVanzari()
        {
            return casaDeMarcat.GetValoare();
        }
        /// <summary>
        /// Optiuni vanzare becuri.
        /// </summary>
        /// <param name="magazin"></param>
        public void VanzareBecuri(Magazin magazin)
        {
            if (this.listaBecuri.Count <= 0)
            {
                Console.WriteLine("Nu sunt becuri in stoc");
                return;
            }

            Console.WriteLine($"Sunt {this.listaBecuri.Count} becuri in stoc.\n" +
                $"Cate becuri doriti sa vindeti?");
            int becuri = int.Parse(Console.ReadLine());
            char exit = ' ';
            while (this.listaBecuri.Count < becuri)
            {
                Console.WriteLine("Ati introdus mai multe becuri decat sunt in stoc.\n" +
                    "Doriti sa introdueti din nou numarul de becuri? y/n");
                exit = Console.ReadKey().KeyChar;
                if (exit == 'n')
                {
                    break;
                }
                Console.WriteLine();
                Console.WriteLine($"Sunt {this.listaBecuri.Count} becuri in stoc.\n" +
                $"Cate becuri doriti sa cumparati?");
                becuri = int.Parse(Console.ReadLine());
            }
            if (exit == 'n')
            {
                return;
            }
            for (int i = 0; i < becuri; i++)
            {
                this.casaDeMarcat.Incasare(this.listaBecuri[0].GetPret());
                this.listaBecuri.RemoveAt(0);
            }
            Console.WriteLine($"Ati vandut {becuri} becuri.");
            Console.WriteLine($"Mai sunt {this.listaBecuri.Count} becuri in stoc.");
        }
        /// <summary>
        /// Optiuni vanzare TV.
        /// </summary>
        /// <param name="magazin"></param>
        public void VanzareTV(Magazin magazin)
        {
            TV tv = magazin.GetTipTV();
            bool tvInStoc = magazin.VerificareStocTV(tv);
            if (tvInStoc == true)
            {
                this.casaDeMarcat.Incasare(tv.GetPret());
                int index = magazin.GetIndexTV(tv);
                this.listaTV.RemoveAt(index);
                Console.WriteLine($"Ati vandut un tv {tv.GetProducator()} {tv.GetModel()}.");
            }
            else
            {
                Console.WriteLine("Televizorul cautat nu este in stoc");
            }
        }
        /// <summary>
        /// Optiuni vanzare telefoane.
        /// </summary>
        /// <param name="magazin"></param>
        public void VanzareTelefon(Magazin magazin)
        {
            Telefon telefon = magazin.GetTipTelefon();
            bool telefonInStoc = magazin.VerificareStocTelefon(telefon);
            if (telefonInStoc == true)
            {
                this.casaDeMarcat.Incasare(telefon.GetPret());
                telefon.SchimbaParola(telefon.GetParola(), string.Empty);
                int index = magazin.GetIndexTelefon(telefon);
                this.listaTelefoane.RemoveAt(index);
                Console.WriteLine($"Ati vandut un telefon {telefon.GetProducator()} {telefon.GetModel()}.");
            }
            else
            {
                Console.WriteLine("Telefonul cautat nu este in stoc");
            }
        }

        /// <summary>
        /// Ofera optiunea de a selecta tipul de telefon si 
        /// returneaza tipul de telefon selectat.
        /// </summary>
        /// <returns></returns>
        public Telefon GetTipTelefon()
        {
            Console.WriteLine("Alegeti din urmatoarele modele\n" +
                "Samsung S10(1)\n" +
                "iPhone 10(2)\n" +
                "Oneplus N10(3)\n" +
                "Nokia 3310(4)\n" +
               "Tastati numarul corespunzator produsului dorit:");
            int raspuns = int.Parse(Console.ReadLine());
            while (raspuns < 1 || raspuns > 4)
            {
                Console.WriteLine("Input gresit!");
                raspuns = int.Parse(Console.ReadLine());
            }

            if (raspuns == 1)
            {
                return new TelefonSamsungS10();
            }
            if (raspuns == 2)
            {
                return new TelefoniPhone10();
            }
            if (raspuns == 3)
            {
                return new TelefonOneplusN10();
            }
            if (raspuns == 4)
            {
                return new TelefonNokia3310();
            }
            return new Telefon("empty", "empty");
        }
        /// <summary>
        ///  Ofera optiunea de a selecta tipul de televizor si 
        /// returneaza tipul de televizor selectat.
        /// </summary>
        /// <returns></returns>
        public TV GetTipTV()
        {
            Console.WriteLine("Alegeti din urmatoarele modele\n" +
                "Samsung SA55(1)\n" +
                "LG 30LG(2)\n" +
                "Nei N45(3)\n" +
                "Philips PH35(4)\n" +
               "Tastati numarul corespunzator produsului dorit:");
            int raspuns = int.Parse(Console.ReadLine());
            while (raspuns < 1 || raspuns > 4)
            {
                Console.WriteLine("Input gresit!");
                raspuns = int.Parse(Console.ReadLine());
            }

            if (raspuns == 1)
            {
                return new TVSamsungSA55();
            }
            if (raspuns == 2)
            {
                return new TVLG30();
            }
            if (raspuns == 3)
            {
                return new TVNeiN45();
            }
            if (raspuns == 4)
            {
                return new TVPhilipsPH35();
            }
            return new TV("empty", "empty");
        }
        /// <summary>
        /// Verifica daca tipul de telefon introdus se afla in stocul magazinului.
        /// </summary>
        /// <param name="telefon"></param>
        /// <returns></returns>
        public bool VerificareStocTelefon(Telefon telefon)
        {
            for (int i = 0; i < this.listaTelefoane.Count; i++)
            {
                if (telefon.GetProducator() == this.listaTelefoane[i].GetProducator() && telefon.GetModel() == this.listaTelefoane[i].GetModel())
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Verifica daca tipul de televizor introdus se afla in stocul magazinului.
        /// </summary>
        /// <param name="tv"></param>
        /// <returns></returns>
        public bool VerificareStocTV(TV tv)
        {
            for (int i = 0; i < this.listaTV.Count; i++)
            {
                if (tv.GetProducator() == this.listaTV[i].GetProducator() && tv.GetModel() == this.listaTV[i].GetModel())
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Returneaza indexul tipului de tv introdus.
        /// </summary>
        /// <param name="tv"></param>
        /// <returns></returns>
        public int GetIndexTV(TV tv)
        {
            int index = 0;
            for (int i = 0; i < this.listaTV.Count; i++)
            {
                if (tv.GetProducator() == this.listaTV[i].GetProducator() && tv.GetModel() == this.listaTV[i].GetModel())
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        /// <summary>
        /// Returneaza indexul tipului de telefon introdus.
        /// </summary>
        /// <param name="telefon"></param>
        /// <returns></returns>
        public int GetIndexTelefon(Telefon telefon)
        {
            int index = 0;
            for (int i = 0; i < this.listaTelefoane.Count; i++)
            {
                if (telefon.GetProducator() == this.listaTelefoane[i].GetProducator() && telefon.GetModel() == this.listaTelefoane[i].GetModel())
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
    }
}
