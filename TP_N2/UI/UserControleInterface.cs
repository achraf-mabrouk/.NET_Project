using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_N2.BLL;
using TP_N2.BO;
namespace TP_N2.UI
{
    class UserControleInterface
    {
        private BLL.BLLGestionReglements bll=null ;
         public UserControleInterface() { }

        private BLLGestionReglements BLL
        {
            get
            {
                if (bll == null) bll = new BLLGestionReglements();
                return bll;
            }
        }
        public Client GetClientFromInterface()
        {
            Client Cl = new Client();
            Console.WriteLine("\n *** Saisie d'un Client ***");
            Console.Write("Identité: ");
            Cl.ID = Int32.Parse(Console.ReadLine());
            Console.Write("Nom :");
            Cl.Name = Console.ReadLine();
            return Cl;
        }
        public void ShowFacture(Facture myFact)
        {
            Console.WriteLine("Reference : " + myFact.Reff);
            Console.WriteLine("Date : " + myFact.DateFacture);
            Console.WriteLine("Montant : " + myFact.MontantFacture);
            Console.WriteLine("Client : " + myFact.Proprietaire.ID);
        }
        
        private int ChoixAction()
        {
            Console.WriteLine("******************MENU******************");
            Console.WriteLine(" 1: Ajouter un nouveau Client");
            Console.WriteLine(" 2: Supprimer les reglements d'une facture");
            Console.WriteLine(" 3: Supprimer une facture");
            Console.WriteLine(" 4: Afficher le montant total des factures d'un client");
            Console.WriteLine(" 5: Afficher toutes les factures");
            Console.WriteLine(" 6: Quitter");
            Console.WriteLine("******************************************");
            return (Int32.Parse(Console.ReadLine()));

        }
        public void MENU()
        {
            int choix;
            do
            {
                choix = ChoixAction();
                switch (choix)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("***********Ajouter un nouveau Client ********");
                        if (BLL.AjouterClient(GetClientFromInterface()))                        
                            Console.WriteLine("Client has been added succesfully !");
                        Console.WriteLine();                       
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("***********Suppression des reglements d'une facture ********");
                        Console.WriteLine("Donner le reference de reglement d'une facture a supprimé : ");
                        if(BLL.deleteReglementFacture(Console.ReadLine()))
                        {
                            Console.WriteLine("Facture Reglement has been deleted Succesfully ! ");
                        }
                        else Console.WriteLine("le référence que vous saisissez est introuvable !");          
                               
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("***********Suppression d'une facture ********");
                        Console.WriteLine("Liste des factures :");
                        List<Facture> Factures = new List<Facture>();
                            Factures = BLL.GetListFacture();
                        foreach (Facture myFacture in Factures)
                            Console.Write(myFacture.Reff + " ");
                        Console.WriteLine();
                        Console.WriteLine("Donner le reference de facture a supprimé : ");
                        
                        if (BLL.SupprimerFacture(Console.ReadLine()))
                            Console.WriteLine("Facture has been deleted Succesfully ! ");                                                                          
                        else
                            Console.WriteLine("le référence que vous saisissez est introuvable !");
                        break;
                    case 4:
                        {
                            Console.Clear();
                            Console.WriteLine("***********Affichage du montant total des factures*************");
                            Console.Write("Liste des Clients:");
                            List<Client> Clients = new List<Client>();
                            Clients= BLL.GetListClient();
                            foreach (Client myClient in Clients)
                                Console.Write(myClient.ID + " ");
                            Console.WriteLine();
                            Console.WriteLine("Donner l'identité d'un Client :");
                            Console.WriteLine(BLL.GetMontantTotalFactureClient(Int32.Parse(Console.ReadLine())));
                            break;

                        }
                    case 5:
                        {
                            Console.Clear();
                            Console.WriteLine("***********Affichage des factures*************");
                            List<Facture> Facts = new List<Facture>();
                                Facts= BLL.GetListFacture();
                            foreach (Facture myFacture in Facts)
                            {
                                Console.Write(" ----------------------------------");
                                ShowFacture(myFacture);
                            }
                            Console.ReadKey();

                            break;

                        }
                }

            } while (choix != 6);
        }

    }
}
