using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_N2.BO
{
    class Reglement
    {
        private Facture fact_reg;

        public string IdReglement { get; set; }
        public DateTime DateReglement { get; set; }
        public double MontantReglement { get; set; }
        public Facture MyFacture { get { return fact_reg; } }
        public Reglement() { }
        public Reglement(string idReg,DateTime dateReg, double montReg, Facture facture) {
            IdReglement = idReg;
            DateReglement = dateReg;
            MontantReglement = montReg;
            fact_reg = facture;

        }

    }
}
