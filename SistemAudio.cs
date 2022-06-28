using System;
using System.Collections.Generic;
using System.Text;

namespace Ex._1.Magazin_Mostenire__Laborator8_
{
    class SistemAudio
    {
        private string nume = "Sistem Audio";
        private bool pornit = false;
        /// <summary>
        /// Porneste sistemul audio.
        /// </summary>
        public void Porneste()
        {
            this.pornit = true;
        }
        /// <summary>
        /// Opreste sistemul audio.
        /// </summary>
        public void Opreste()
        {
            this.pornit = false;
        }
    }
}
