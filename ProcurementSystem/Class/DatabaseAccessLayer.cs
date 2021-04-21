using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ProcurementSystem.Class.AccessLayer
{
    class DatabaseAccessLayer
    {
        static SqlConnection myConnection = new SqlConnection("Data Source=192.168.1.18; Initial Catalog=PROCUREMENT; Integrated Security=false; User Instance=False; User ID=billing; Password=@Newuserlogs");

        public static DataTable RetrieveDataTableInfo(string query)
        {
            SqlDataAdapter myAdapter = null;
            DataTable myTable = null;

            try
            {
                myConnection.Open();
                myAdapter = new SqlDataAdapter(query, myConnection);
                myTable = new DataTable();
                myAdapter.Fill(myTable);

                return myTable;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in retrieving dataTable" + Environment.NewLine + ex.Message.ToString(), ex);
            }
            finally
            {
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Close();
                    myAdapter.Dispose();
                    myTable.Dispose();
                }
            }
        }

        public static DataTable RetrieveDataTableInfo(string query, params SqlParameter[] _Params)
        {
            SqlDataAdapter myAdapter = null;
            DataTable myTable = null;
            SqlCommand myCommand = null;

            try
            {
                myConnection.Open();
                myCommand = new SqlCommand(query, myConnection);

                myCommand.Parameters.Clear();
                myCommand.CommandType = CommandType.Text;
                myCommand.CommandTimeout = 0;


                if (!(_Params == null))
                {
                    foreach (SqlParameter param in _Params)
                    {
                        myCommand.Parameters.Add(param);
                    }
                }

                myAdapter = new SqlDataAdapter(myCommand);
                myTable = new DataTable();
                myAdapter.Fill(myTable);

                return myTable;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in retrieving dataTable" + Environment.NewLine + ex.Message.ToString(), ex);
            }
            finally
            {
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Close();
                    myAdapter.Dispose();
                    myTable.Dispose();
                    myCommand.Dispose();
                }
            }
        }


        public static Boolean UpdateInfomation(string query)
        {
            SqlCommand myCommand = null;

            try
            {
                myConnection.Open();
                myCommand = new SqlCommand(query, myConnection);
                myCommand.CommandTimeout = 0;
                myCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in update info" + Environment.NewLine + ex.Message.ToString(), ex);
            }
            finally
            {
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Close();
                    myCommand.Dispose();
                }
            }
        }

        public   static Boolean UpdateInfomation(string query, params SqlParameter[] _Params)
        {
            SqlCommand myCommand = null;

            try
            {
                myConnection.Open();
                myCommand = new SqlCommand(query, myConnection);

                myCommand.Parameters.Clear();
                myCommand.CommandType = CommandType.Text;
                myCommand.CommandTimeout = 0;

                if (!(_Params == null))
                {
                    foreach (SqlParameter param in _Params)
                    {
                        myCommand.Parameters.Add(param);
                    }
                }

                myCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in update info" + Environment.NewLine + ex.Message.ToString(), ex);
            }
            finally
            {
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Close();
                    myCommand.Dispose();
                }
            }
        }





    }
}
