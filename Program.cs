using System;

namespace Ex._1.Magazin_Mostenire__Laborator8_
{
    class Program
    {
        static void Main(string[] args)
        {
            Bec bec = new Bec();

            TVSamsungSA55 tVSamsungSA55 = new TVSamsungSA55();
            TVLG30 tVLG30 = new TVLG30();
            TVNeiN45 tVNeiN45 = new TVNeiN45();
            TVPhilipsPH35 tVPhilipsPH35 = new TVPhilipsPH35();


            TelefoniPhone10 telefoniPhone10 = new TelefoniPhone10();
            TelefonNokia3310 telefonNokia3310 = new TelefonNokia3310();
            TelefonSamsungS10 telefonSamsungS10 = new TelefonSamsungS10();
            TelefonOneplusN10 telefonOneplusN10 = new TelefonOneplusN10();


            Magazin magazin = new Magazin();

            magazin.AdaugareBec(bec);
            magazin.AdaugareBec(bec);
            magazin.AdaugareBec(bec);
            magazin.AdaugareBec(bec);
            magazin.AdaugareBec(bec);

            TelefonSamsungS10 telefonSamsungTest = new TelefonSamsungS10();
            telefonSamsungTest.SchimbaParola("0000", "1234");
            telefonSamsungTest.Deblocheaza("4343");
            telefonSamsungTest.Apelare("0722222222");
            telefonSamsungTest.Deblocheaza("1234");
            telefonSamsungTest.Apelare("0722222222");

            magazin.AdaugareTelefon(telefonSamsungTest);


            magazin.AdaugareTelefon(telefonSamsungS10);
            magazin.AdaugareTelefon(telefonOneplusN10);
            magazin.AdaugareTelefon(telefoniPhone10);
            magazin.AdaugareTelefon(telefonNokia3310);
            magazin.AdaugareTelefon(telefoniPhone10);
            magazin.AdaugareTelefon(telefonNokia3310);


            magazin.AdaugareTV(tVSamsungSA55);
            magazin.AdaugareTV(tVLG30);
            magazin.AdaugareTV(tVNeiN45);
            magazin.AdaugareTV(tVPhilipsPH35);
            magazin.AdaugareTV(tVSamsungSA55);
            magazin.AdaugareTV(tVLG30);


            magazin.ClientIntra(); 

            magazin.SchimbareParolaMagazin("0000", "9999");

            Console.WriteLine("Vindeti bec(1), TV(2) sau telefon(3)?\n" +
                    "Tastati numarul corespunzator produsului dorit:");
            int raspuns = int.Parse(Console.ReadLine());
            while (raspuns < 1 || raspuns > 3)
            {
                Console.WriteLine("Input gresit!");
                raspuns = int.Parse(Console.ReadLine());
            }
            switch (raspuns)
            {
                case 1:
                    VanzareBecuriMain(magazin);
                    break;
                case 2:
                    VanzareTVMain(magazin);
                    break;
                default:
                    VanzareTelefonMain(magazin);
                    break;
            }


            magazin.ClientIese();
        }

        public static void VanzareBecuriMain(Magazin magazin)
        {
            Console.WriteLine($"Sunt {magazin.GetNumarBecuri()} becuri in stoc.\n" +
                $"Cate becuri doriti sa vindeti?");
            int becuri = int.Parse(Console.ReadLine());
            char exit = ' ';
            while (magazin.GetNumarBecuri() < becuri)
            {
                Console.WriteLine("Ati introdus mai multe becuri decat sunt in stoc.\n" +
                    "Doriti sa introdueti din nou numarul de becuri? y/n");
                exit = Console.ReadKey().KeyChar;
                if (exit == 'n')
                {
                    break;
                }
                Console.WriteLine();
                Console.WriteLine($"Sunt {magazin.GetNumarBecuri()} becuri in stoc.\n" +
                $"Cate becuri doriti sa cumparati?");
                becuri = int.Parse(Console.ReadLine());
            }
            if (exit == 'n')
            {
                return;
            }
            magazin.VanzareBecuri(magazin, becuri);
        }
        public static void VanzareTVMain(Magazin magazin)
        {
            Console.WriteLine("Alegeti din urmatoarele modele\n" +
                "Samsung SA55(1)\n" +
                "LG 30LG(2)\n" +
                "Nei N45(3)\n" +
                "Philips PH35(4)\n" +
               "Tastati numarul corespunzator produsului dorit:");
            TV tv = new TV("empty", "empty"); ;
            int raspuns = int.Parse(Console.ReadLine());
            while (raspuns < 1 || raspuns > 4)
            {
                Console.WriteLine("Input gresit!");
                raspuns = int.Parse(Console.ReadLine());
            }

            if (raspuns == 1)
            {
                tv = new TVSamsungSA55();
            }
            if (raspuns == 2)
            {
                tv = new TVLG30();
            }
            if (raspuns == 3)
            {
                tv = new TVNeiN45();
            }
            if (raspuns == 4)
            {
                tv = new TVPhilipsPH35();
            }
            magazin.VanzareTV(magazin, tv);
        }
        public static void VanzareTelefonMain(Magazin magazin)
        {
            Console.WriteLine("Alegeti din urmatoarele modele\n" +
               "Samsung S10(1)\n" +
               "iPhone 10(2)\n" +
               "Oneplus N10(3)\n" +
               "Nokia 3310(4)\n" +
              "Tastati numarul corespunzator produsului dorit:");
            Telefon telefon = new Telefon("empty", "empty");
            int raspuns = int.Parse(Console.ReadLine());
            while (raspuns < 1 || raspuns > 4)
            {
                Console.WriteLine("Input gresit!");
                raspuns = int.Parse(Console.ReadLine());
            }

            if (raspuns == 1)
            {
                telefon = new TelefonSamsungS10();
            }
            if (raspuns == 2)
            {
                telefon = new TelefoniPhone10();
            }
            if (raspuns == 3)
            {
                telefon = new TelefonOneplusN10();
            }
            if (raspuns == 4)
            {
                telefon = new TelefonNokia3310();
            }
            magazin.VanzareTelefon(magazin, telefon);
        }
    }
}
