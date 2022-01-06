using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace TP_N2.DAL
{
    class DALGestionReglements
    {
        private DBConnection conn;
        public DALGestionReglements() { conn = new DBConnection(); }

        public bool InsertClientQuery(int id , string nom)
        {
            string query=@"INSERT INTO Client VALUES (@id,@nom)";
            OleDbParameter[] oleDbParameters = new OleDbParameter[2];
            oleDbParameters[0] = new OleDbParameter("@id", OleDbType.Integer);
            oleDbParameters[1] = new OleDbParameter("@nom", OleDbType.VarChar);
            oleDbParameters[0].Value = id;
            oleDbParameters[1].Value = nom;
            return conn.executeInsertQuery(query, oleDbParameters);

        }
        public bool DeleteClientQuery(string reference)
        {
            string query = @"DELETE FROM Client Where reference=@ref;";
            OleDbParameter[] oleDbParameters = new OleDbParameter[1];
            oleDbParameters[0] = new OleDbParameter("@ref", OleDbType.VarChar);
            oleDbParameters[0].Value = reference;
            return conn.executeDeleteQuery(query, oleDbParameters);

        }
        public bool DeleteReglementsFactureQuery(string reference)
        {
            string query = @"DELETE FROM reglement Where reference=@ref;";
            OleDbParameter[] oleDbParameters = new OleDbParameter[1];
            oleDbParameters[0] = new OleDbParameter("@ref", OleDbType.VarChar);
            oleDbParameters[0].Value = reference;

            return conn.executeDeleteQuery(query, oleDbParameters);
        }
        public bool DeleteFactureQuery(string reference)
        {
            DeleteReglementsFactureQuery(reference);
            string query = @"DELETE FROM Facture Where reference=@ref;";
            OleDbParameter[] oleDbParameters = new OleDbParameter[1];
            oleDbParameters[0] = new OleDbParameter("@ref", OleDbType.VarChar);
            oleDbParameters[0].Value =reference;
            return conn.executeDeleteQuery(query, oleDbParameters);

        }
        public DataTable SelectClientById(int id)
        {
            string query = @"Select * FROM Client WHERE identite=@id;";
            OleDbParameter[] oleDbParameters = new OleDbParameter[1];
            oleDbParameters[0] = new OleDbParameter("@id", OleDbType.Integer);
            oleDbParameters[0].Value = id;
            return conn.executeSelectQueryConnectMode(query, oleDbParameters);
        }
        public DataTable SelectFactureByIdClient(int id)
        {
            string query = @"Select * FROM Facture WHERE identite=@id;";
            OleDbParameter[] oleDbParameters = new OleDbParameter[1];
            oleDbParameters[0] = new OleDbParameter("@id", OleDbType.Integer);
            oleDbParameters[0].Value = id;
            return conn.executeSelectQueryConnectMode(query, oleDbParameters);
        }
        public DataTable SelectAllClient()
        {
            string Query = @"SELECT * FROM CLIENT;";
            return conn.executeSelectQueryDisconnectMode(Query);
        }
        public DataTable SelectAllFacture()
        {
            string Query = @"SELECT * FROM Facture;";
            return conn.executeSelectQueryDisconnectMode(Query);
        }
    }
}
