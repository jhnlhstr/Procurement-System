using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;

namespace ProcurementSystem.Class.AccessLayer
{
    class DatabaseAccessLayer
    {
        //LIVE DATABASE
        //static SqlConnection myConnection = new SqlConnection("Data Source=10.3.1.34; Initial Catalog=PROCUREMENT; Integrated Security=false; User Instance=False; User ID=ISbilling; Password=@Newuserlogss");

        //TESTING DATABASE
        static SqlConnection myConnection = new SqlConnection("Data Source=192.168.1.8; Initial Catalog=PROCUREMENT; Integrated Security=false; User Instance=False; User ID=billing; Password=@Newuserlogs");

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

        public static Boolean UpdateInfomation(string query, params SqlParameter[] _Params)
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

        public static int UpdateInfomationProcPOID(string query, params SqlParameter[] _Params)
        {
            SqlCommand myCommand = null;
            int sId = 0;

            try
            {
                myConnection.Open();
                myCommand = new SqlCommand(query, myConnection);

                myCommand.Parameters.Clear();
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandTimeout = 0;

                if (!(_Params == null))
                {
                    foreach (SqlParameter param in _Params)
                    {
                        myCommand.Parameters.Add(param);
                    }

                    myCommand.Parameters["@pId"].Direction = ParameterDirection.Output;
                }

                myCommand.ExecuteNonQuery();

                sId = Convert.ToInt32(myCommand.Parameters["@pId"].Value);

                return sId;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in inserting records" + Environment.NewLine + ex.Message.ToString(), ex);
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


        public static int UpdateInfomationProcPRID(string query, params SqlParameter[] _Params)
        {
            SqlCommand myCommand = null;
            int sId = 0;

            try
            {
                myConnection.Open();
                myCommand = new SqlCommand(query, myConnection);

                myCommand.Parameters.Clear();
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandTimeout = 0;

                if (!(_Params == null))
                {
                    foreach (SqlParameter param in _Params)
                    {
                        myCommand.Parameters.Add(param);
                    }

                    myCommand.Parameters["@pId"].Direction = ParameterDirection.Output;
                }

                myCommand.ExecuteNonQuery();

                sId = Convert.ToInt32(myCommand.Parameters["@pId"].Value);

                return sId;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in inserting pr number" + Environment.NewLine + ex.Message.ToString(), ex);
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


        //-------------------------------------------- BATCH UPLOAD EXCEL -------------------------------------------------------

        private static DataTable GetExcelRecords(string filename)
        {
            OleDbConnection myOleDBConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filename + ";Extended Properties=Excel 8.0");
            //OleDbConnection myConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filename + ";Extended Properties=Excel 12.0;HDR=YES;");
            OleDbDataAdapter myAdapter = null;
            DataTable myTable = null;
            DataTable DTsheet = new DataTable();
            string sheetname = string.Empty;

            try
            {
                myOleDBConnection.Open();
                DTsheet = myOleDBConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                sheetname = DTsheet.Rows[0]["Table_Name"].ToString();

                myAdapter = new OleDbDataAdapter("SELECT * FROM [" + sheetname + "]", myOleDBConnection);
                myTable = new DataTable();
                myAdapter.Fill(myTable);

                return myTable;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in retrieve records in excel" + Environment.NewLine + ex.Message.ToString(), ex);
            }
            finally
            {
                if (myOleDBConnection.State == ConnectionState.Open)
                {
                    myOleDBConnection.Close();
                    myAdapter.Dispose();
                    myTable.Dispose();
                }
            }
        }

        public static Boolean ExcelBatchSupplier(string filename)
        {
            SqlDataAdapter myAdapter = null;
            DataTable myTable = null;
            SqlCommandBuilder cb;
            DataRow dr;

            try
            {
                myConnection.Open();
                myAdapter = new SqlDataAdapter("SELECT * FROM PS.MasterList", myConnection);
                cb = new SqlCommandBuilder(myAdapter);
                myTable = new DataTable();
                myAdapter.Fill(myTable);

                DataTable dtExcel = new DataTable();
                dtExcel = GetExcelRecords(filename);

                for (int x = 0; x <= dtExcel.Rows.Count - 1; x++)
                {
                    dr = myTable.NewRow();

                    dr[1] = dtExcel.Rows[x][1].ToString();
                    dr[2] = dtExcel.Rows[x][2].ToString();
                    dr[3] = dtExcel.Rows[x][3].ToString();
                    dr[4] = dtExcel.Rows[x][4].ToString();
                    dr[5] = dtExcel.Rows[x][5].ToString();
                    dr[6] = dtExcel.Rows[x][6].ToString();
                    dr[7] = dtExcel.Rows[x][7].ToString();
                    dr[8] = dtExcel.Rows[x][0].ToString();
                    dr[9] = true;

                    myTable.Rows.Add(dr);
                    myAdapter.Update(myTable);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in inserting batch supplier list" + Environment.NewLine + ex.Message.ToString(), ex);
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





    }
}
