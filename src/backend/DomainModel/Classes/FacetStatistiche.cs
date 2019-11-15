using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Classes
{
    public class FacetStatistiche
    {
        /// <summary>
        /// Rappresenta la votozine che può rilasciare un utente scegliendo tra Good, Fair e Poor.
        /// </summary>
        public string Voto { get; set; }

        /// <summary>
        /// Rappresenta la percentuale rispetto al totale dei feedback rilascati che corrispondono ad un determinato Voto.
        /// </summary>
        public double Percentuale { get; set; }

    }
}
