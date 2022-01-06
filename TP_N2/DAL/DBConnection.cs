using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
namespace TP_N2.DAL
{
     class DBConnection
    {
        OleDbConnection conn;
         public DBConnection ()
        {
            conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=C:\Users\FRANTIC\Documents\TP_db.accdb;Persist Security Info=False;");
        }
        
        private OleDbConnection openConnection()
        {
            try
            {
                if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
                {
                    conn.Open();
                }
            }
            catch (OleDbException e) {
                Console.WriteLine("Error - Connection-Exception:" + e.StackTrace.ToString());
                return null;
            }
            return conn;
        }
        public bool executeInsertQuery(string query,OleDbParameter[] oleDbParameter)
        {
            OleDbCommand mycmd = new OleDbCommand();
            try
            {
                mycmd.Connection = openConnection();
                mycmd.CommandText = query;
                mycmd.Parameters.AddRange(oleDbParameter);
                mycmd.ExecuteNonQuery();
            }
            catch (OleDbException e)
            {
                Console.WriteLine("Error- Connection.executeInsertQuery - Query: " + query + "\n Exception: " + e.StackTrace.ToString());
                return false;
            }
            conn.Close();
            return true;
        }
        public bool executeDeleteQuery(string query,OleDbParameter[] oleDbParameter)
        {
            OleDbCommand mycmd = new OleDbCommand();
            try
            {
                mycmd.Connection = openConnection();
                mycmd.CommandText = query;
                mycmd.Parameters.AddRange(oleDbParameter);
                mycmd.ExecuteNonQuery();
            }
            catch(OleDbException e)
            {
                Console.WriteLine("Error- Connection.executeDeleteQuery - Query: "+ query +"\nException: "+ e.StackTrace.ToString());
                return false;

            }

            conn.Close();
            return true;
        }
        public bool executeUpdateQuery(string query, OleDbParameter[] oleDbParameter)
        {
            OleDbCommand mycmd = new OleDbCommand();
            try
            {
                mycmd.Connection = openConnection();
                mycmd.CommandText = query;
                mycmd.Parameters.AddRange(oleDbParameter);
                mycmd.ExecuteNonQuery();
            }
            catch (OleDbException e)
            {
                Console.WriteLine("Error- Connection.executeUpdateQuery - Query: " + query + "\nException: " + e.StackTrace.ToString());
                return false;

            }

            conn.Close();
            return true;
        }
        public DataTable executeSelectQueryConnectMode(string query, OleDbParameter[] oleDbParameter)
        {
        
            OleDbCommand cmd = new OleDbCommand();
            DataTable myTable = new DataTable();
            OleDbDataReader myReader = null;
            try
            {                
                cmd.Connection = openConnection();
                cmd.CommandText = query;
                cmd.Parameters.AddRange(oleDbParameter);
                myReader = cmd.ExecuteReader();
                DataTable schemaTable = myReader.GetSchemaTable();
                List <string> list = new List<string>();
                foreach(DataRow myRow in schemaTable.Rows)
                {
                    DataColumn myDataColumn = new DataColumn();
                    myDataColumn.DataType = (Type)myRow["DataType"];
                    myDataColumn.ColumnName = myRow["ColumnName"].ToString();
                    list.Add(myDataColumn.ColumnName);
                    myTable.Columns.Add(myDataColumn);
                }
                myTable.BeginLoadData();
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        DataRow myDataRow = myTable.NewRow();
                        for (int i = 0; i < list.Count; i++)
                        {
                            myDataRow[list[i]] = myReader[list[i]];
                        }
                        myTable.Rows.Add(myDataRow);
                        myDataRow = null;

                    }
                }
            }
            catch( OleDbException e)
            {
               Console.WriteLine("error - connection.executrSelectQueryConnectMode - Query:" + query + "/nEexeption" + e.StackTrace.ToString());
                return null;
            }
            myReader.Close();
            conn.Close();
            return myTable;

        }
        public DataTable executeSelectQueryDisconnectMode(string query)
        {

            OleDbDataAdapter myAdapter = new OleDbDataAdapter();
            OleDbCommand cmd = new OleDbCommand();
            DataSet ds = new DataSet();
            DataTable dataTable = null;
            try
            {
                cmd.Connection = openConnection();
                cmd.CommandText = query;
                myAdapter.SelectCommand = cmd;
                myAdapter.Fill(ds);
                dataTable = ds.Tables[0];
            }
            catch (OleDbException e)
            {
                Console.WriteLine("Error - Connection.executeSelectQueryDesconnectMode - query " + query + "\n Exception :" + e.ToString());
            }
            conn.Close();
            return dataTable;
        }
    }
}
