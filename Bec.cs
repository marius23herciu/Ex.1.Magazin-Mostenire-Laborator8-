using System;
using System.Collections.Generic;
using System.Text;

namespace Ex._1.Magazin_Mostenire__Laborator8_
{
    class Bec
    {
        /*
         • Fiecare bec va costa 25 ron
         • Va avea o metodă care va aprinde becul și va confirma acest lucru în consolă.
         • Va avea o metodă care va stinge becul și va confirma acest lucru în consolă.
         */
        private int pret = 25;
        private bool aprins = false;

        /// <summary>
        /// Aprinde bec.
        /// </summary>
        public void AprindeBec()
        {
            aprins = true;
            Console.WriteLine("Bec aprins.");
        }
        /// <summary>
        /// Stinge bec.
        /// </summary>
        public void StingeBec()
        {
            aprins = false;
            Console.WriteLine("Bec stins.");
        }
        /// <summary>
        /// Returneaza pretul unui bec.
        /// </summary>
        /// <returns></returns>
        public int GetPret()
        {
            return this.pret;
        }
    }
}
