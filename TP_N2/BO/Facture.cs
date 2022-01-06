using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_N2.BO
{
    class Facture
    {
        private Client proprietaire;
        public Facture() { }
        public Facture(string reff,DateTime dateFacture,double montantFacture,Client proprietaire)
        {
            MontantFacture = montantFacture;
            DateFacture = dateFacture;
            Reff = reff;
            this.proprietaire = proprietaire;

        }
        public double MontantFacture { get; set; }
        public DateTime DateFacture { get; set; }
        public string Reff { get; set; }
        public Client Proprietaire { get { return proprietaire; } }
    }
}
