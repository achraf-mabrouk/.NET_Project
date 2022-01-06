using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_N2.DAL;
using TP_N2.BO;
using System.Data;
namespace TP_N2.BLL
{
    class BLLGestionReglements
    {
        private DALGestionReglements dal = null;
        public BLLGestionReglements() { }

        private  DALGestionReglements DaL
        {
            get
            {
                if (dal == null) dal = new DALGestionReglements();
                return dal;
            }
        }

        public bool AjouterClient(Client proprietaire)
        {
            return (DaL.InsertClientQuery(proprietaire.ID, proprietaire.Name));
        }

        public bool deleteReglementFacture(string reference)
        {
            return DaL.DeleteReglementsFactureQuery(reference);
        }

        public bool SupprimerClient(string reference)
        {
            return DaL.DeleteClientQuery(reference);

        }
        public bool SupprimerFacture(string reference)
        {
            return DaL.DeleteFactureQuery(reference);

        }
        public Client GetClientByID(int id)
        {
            DataTable MyTable = new DataTable();
            MyTable = DaL.SelectClientById(id);

            return new Client(Convert.ToInt32(MyTable.Rows[0][0]), Convert.ToString(MyTable.Rows[0][1]));
        }
        public List <Client> GetListClient()
        {
            List<Client> Clients = new List<Client>();
            DataTable MyTable = new DataTable();
            MyTable = DaL.SelectAllClient();
            foreach(DataRow MyRow in MyTable.Rows)
            {
                Clients.Add(new Client(Convert.ToInt32(MyRow[0]),MyRow[1].ToString()));
            }
            return Clients;
        }
        public List <Facture> GetListFacture()
        {
            List < Facture > Factures= new List<Facture>();
            DataTable MyTable = new DataTable();
            MyTable =DaL.SelectAllFacture();
            foreach (DataRow myRow in MyTable.Rows)
                Factures.Add(new Facture(myRow[0].ToString(), Convert.ToDateTime(myRow[1]), Convert.ToDouble(myRow[2]), GetClientByID(Convert.ToInt32(myRow[3]))));
            return Factures;
        }
        public List<Facture> GetListeFactureClient(int ID)
        {
            List<Facture> Factures = new List<Facture>();
            DataTable myTable = new DataTable();
            myTable = DaL.SelectFactureByIdClient(ID);
            foreach (DataRow myRow in myTable.Rows)
                Factures.Add(new Facture(myRow[0].ToString(),Convert.ToDateTime(myRow[1]), Convert.ToDouble(myRow[2]),GetClientByID(Convert.ToInt32(myRow[3]))));
            return Factures;        
        }
        public double GetMontantTotalFactureClient (int ID)
        {
            double MontantTot = 0.0;
            DataTable MyTable = new DataTable();
            MyTable = DaL.SelectFactureByIdClient(ID);
            foreach (DataRow MyRow in MyTable.Rows)
            {
                MontantTot += Convert.ToDouble(MyRow[2]);
            }
            return MontantTot;
        }
    }
}
