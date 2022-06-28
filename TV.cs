using System;
using System.Collections.Generic;
using System.Text;

namespace Ex._1.Magazin_Mostenire__Laborator8_
{
    class TV
    {
        /*• Fiecare televizor va costa 1000 de ron.
          • Va avea un model și producător
          • Va avea o metodă care va porni televizorul pe un program cu muzica și va confirma acest lucru
          în consolă, menționând modelul și producătorul.
          • Va avea o metodă care va opri televizorul și va confirma acest lucru în consolă*/

        private int pret = 1000;
        private string model;
        private string producator;
        private bool pornit = false;
        private PosturiTV post;

        enum PosturiTV
        {
            Stiri, Muzica, Cultural, Cartoon
        }

        /// <summary>
        /// Creaza televizor.
        /// </summary>
        /// <param name="producator"></param>
        /// <param name="model"></param>
        public TV(string producator, string model)
        {
            this.producator = producator;
            this.model = model;
        }

        /// <summary>
        /// Porneste TV.
        /// </summary>
        public void Porneste()
        {
            pornit = true;
            this.post = PosturiTV.Muzica;
            Console.WriteLine($"{this.producator} {this.model} este pornit pe canalul {this.post}.");
        }
        /// <summary>
        /// Opreste TV.
        /// </summary>
        public void Opreste()
        {
            pornit = false;
            Console.WriteLine($"{this.producator} {this.model} este oprit.");
        }
        /// <summary>
        /// Returneaza pretul unui televizor.
        /// </summary>
        /// <returns></returns>
        public int GetPret()
        {
            return this.pret;
        }
        /// <summary>
        /// Returneaza numele producatorului unui TV.
        /// </summary>
        /// <returns></returns>
        public string GetProducator()
        {
            return this.producator;
        }
        /// <summary>
        /// Returneaza modelul unui TV.
        /// </summary>
        /// <returns></returns>
        public string GetModel()
        {
            return this.model;
        }
        /// <summary>
        /// Schimba un TV pe canalul Muzica.
        /// </summary>
        public void SetPostTVMuzica()
        {
            this.post = PosturiTV.Muzica;
        }
    }
    class TVSamsungSA55 : TV
    {
        public TVSamsungSA55() : base("Samsung", "SA55")
        {
        }
    }
    class TVLG30 : TV
    {
        public TVLG30() : base("LG", "30")
        {
        }
    }
    class TVNeiN45 : TV
    {
        public TVNeiN45() : base("Nei", "N45")
        {
        }
    }
    class TVPhilipsPH35 : TV
    {
        public TVPhilipsPH35() : base("Philips", "PH35")
        {

        }
    }
}
