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
                    magazin.VanzareBecuri(magazin);
                    break;
                case 2:
                    magazin.VanzareTV(magazin);
                    break;
                default:
                    magazin.VanzareTelefon(magazin);
                    break;
            }
            magazin.ClientIese();
        }
    }
}
