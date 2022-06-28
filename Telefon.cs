using System;
using System.Collections.Generic;
using System.Text;

namespace Ex._1.Magazin_Mostenire__Laborator8_
{
    class Telefon
    {
        /*• Fiecare telefon va costa câte 1700 ron
         • Va avea un model și un producător
         • Va avea o metodă ”deblochează” care va debloca telefonul și va confirma acest lucru în consolă
        • Va avea o metodă ”blochează” care va bloca telefonul


            Suplimentar

            Telefonul
            • Va avea o metodă ”deblochează” care va primi ca parametru o parola
                   o Telefonul va fi deblocat doar dacă parola este corectă sau dacă încă nu a fost setată
                   (empty string)
            • Va avea o metodă de schimbare a parolei care va primi doi parametrii, parola veche și parola
            nouă
                   o Parola va fi schimbată doar dacă parola veche este corectă
                   o Va afișa in consola dacă parola a fost sau nu schimbată cu succes
            • Va persista starea telefonului (blocat/deblocat)
            • Va expune o metodă ”apelează”
                   o va primi ca parametru un număr de telefon
                   o va efectua apelul doar dacă telefonul este deblocat
       */




        private int pret = 1700;
        private string producator;
        private string model;
        private bool blocat = true;
        private string parola = string.Empty;
        private bool apelare = false;

        /// <summary>
        /// Creaza Telefon.
        /// </summary>
        /// <param name="producator"></param>
        /// <param name="model"></param>
        public Telefon(string producator, string model)
        {
            this.producator = producator;
            this.model = model;
        }
        /// <summary>
        /// Schimba parola unui telefon daca parola veche este parola actuala.
        /// </summary>
        /// <param name="parolaVeche"></param>
        /// <param name="parolaNoua"></param>
        public void SchimbaParola(string parolaVeche, string parolaNoua)
        {
            if (this.parola == parolaVeche || this.parola == string.Empty || this.parola == parolaNoua)
            {
                this.parola = parolaNoua;
                Console.WriteLine($"Parola a fost schimbata pentru {this.producator} {this.model}.");
            }

            else
            {
                Console.WriteLine($"Parola introdusa e incorecta.");
            }
        }
        /// <summary>
        /// Apeleaza numarul de telefon daca telefonul nu este blocat.
        /// </summary>
        /// <param name="numarTelefon"></param>
        public void Apelare(string numarTelefon)
        {
            if (this.blocat == false)
            {
                this.apelare = true;
                Console.WriteLine($"Se apeleaza {numarTelefon}...");
            }
            else
            {
                Console.WriteLine($"{this.producator} {this.model} este blocat.");
            }
        }
        /// <summary>
        /// returneaza parola telefonului.
        /// </summary>
        /// <returns></returns>
        public string GetParola()
        {
            return this.parola;
        }
        /// <summary>
        /// Deblocheaza telefonul daca nu are parola sau daca parola introdusa este corecta.
        /// </summary>
        /// <param name="parola"></param>
        public void Deblocheaza(string parola)
        {
            if (this.parola == parola || this.parola == string.Empty)
            {
                this.blocat = false;
                Console.WriteLine($"{this.producator} {this.model} este deblocat.");
            }
            else
            {
                this.blocat = true;
                Console.WriteLine($"S-a introdus parola gresita pentru{this.producator} {this.model}.");
            }

        }
        /// <summary>
        /// Blocheaza telefonul.
        /// </summary>
        public void Blocheaza()
        {
            this.blocat = true;
            Console.WriteLine($"{this.producator} {this.model} este blocat.");
        }
        /// <summary>
        /// Returneaza pretul unui telefon.
        /// </summary>
        /// <returns></returns>
        public int GetPret()
        {
            return this.pret;
        }
        /// <summary>
        /// Returneaza denumirea producatorului unui telefon.
        /// </summary>
        /// <returns></returns>
        public string GetProducator()
        {
            return this.producator;
        }
        /// <summary>
        /// Returneaza denumirea modelului unui telefon.
        /// </summary>
        /// <returns></returns>
        public string GetModel()
        {
            return this.model;
        }
    }
    class TelefonSamsungS10 : Telefon
    {
        public TelefonSamsungS10() : base("Samsung", "S10")
        {

        }
    }
    class TelefoniPhone10 : Telefon
    {
        public TelefoniPhone10() : base("iPhone", "10")
        {

        }
    }
    class TelefonOneplusN10 : Telefon
    {
        public TelefonOneplusN10() : base("OnePlus", "N10")
        {

        }
    }
    class TelefonNokia3310 : Telefon
    {
        public TelefonNokia3310() : base("Nokia", "3310")
        {

        }
    }

}
