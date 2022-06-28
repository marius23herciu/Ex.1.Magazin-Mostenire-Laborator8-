using System;
using System.Collections.Generic;
using System.Text;

namespace Ex._1.Magazin_Mostenire__Laborator8_
{
    class CasaDeMarcat
    {
        //Va persista valoarea curentă a vânzărilor și va încasa prețul produselor cumpărate

        private int valoareVanzari = 0;
        /// <summary>
        /// Adauga pretul la la valoarea actuala din casea de marcat.
        /// </summary>
        /// <param name="pret"></param>
        public void Incasare(int pret)
        {
            this.valoareVanzari += pret;
        }
        /// <summary>
        /// Returneaza suma din casa de marcat.
        /// </summary>
        /// <returns></returns>
        public int GetValoare()
        {
            return this.valoareVanzari;
        }
    }
}
