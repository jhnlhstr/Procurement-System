using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcurementSystem.Class.AccessLayer;

namespace ProcurementSystem.Class.DBMethods
{
    class DBMethods
    {
        public static Boolean GetUserLogin(string username, string password)
        {
            DataTable DtLog = new DataTable();
            
            try
            {
                DtLog = DatabaseAccessLayer.RetrieveDataTableInfo("SELECT * FROM PS.LoginCredentials WHERE Username = @username AND Password = @password",
                                                                  new SqlParameter("@username", username),
                                                                  new SqlParameter("@password", password));

                if (DtLog.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in getting login credentials" + Environment.NewLine + ex.Message.ToString(), ex);
            }
            finally
            {
                DtLog.Dispose();
            }
        }

        public static DataTable GetSupplierMasterList(string Id)
        {
            DataTable DtList = new DataTable();

            try
            {
                if (Id == string.Empty)
                {
                    DtList = DatabaseAccessLayer.RetrieveDataTableInfo("SELECT * FROM PS.MasterList");
                }
                else
                {
                    DtList = DatabaseAccessLayer.RetrieveDataTableInfo("SELECT * FROM PS.MasterList WHERE ID = @Id",
                                                                       new SqlParameter("@Id", Id));
                }

                return DtList;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in getting supplier master list" + Environment.NewLine + ex.Message.ToString(), ex);
            }
        }

        public static Boolean InsertSupplierList(string itemname, string vendor, string address, string contactperson, string contactnumber, string email, string terms)
        {
            Boolean _isInsert = false;

            try
            {
                _isInsert = DatabaseAccessLayer.UpdateInfomation("INSERT INTO PS.MasterList VALUES (@item, @vendor, @address, @contactperson, @contactnumber, @email, @terms)", 
                                                                 new SqlParameter("@item", itemname),
                                                                 new SqlParameter("@vendor", vendor),
                                                                 new SqlParameter("@address", address),
                                                                 new SqlParameter("@contactperson", contactperson),
                                                                 new SqlParameter("@contactnumber", contactnumber),
                                                                 new SqlParameter("@email", email),
                                                                 new SqlParameter("@terms", terms));

                return _isInsert;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in inserting master list" + Environment.NewLine + ex.Message.ToString(), ex);
            }
        }

        public static Boolean InsertBatchSupplierList(string filename)
        {
            try
            {
                return DatabaseAccessLayer.ExcelBatchSupplier(filename);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in insert batch supplier list" + Environment.NewLine + ex.Message.ToString(), ex);
            }
        }

        public static Boolean EditSupplierList(string Id, string itemname, string vendor, string address, string contactperson, string contactnumber, string email, string terms)
        {
            Boolean _isUpdate = false;
            
            try
            {
                _isUpdate = DatabaseAccessLayer.UpdateInfomation("UPDATE PS.MasterList SET ItemName = @item, VendorName = @vendor, Address = @address, ContactPerson = @contactperson," +
                                                                 " ContactNumber = @contactnumber, Email = @email, Terms = @terms WHERE ID = @Id",
                                                                 new SqlParameter("@Id", Id),
                                                                 new SqlParameter("@item", itemname),
                                                                 new SqlParameter("@vendor", vendor),
                                                                 new SqlParameter("@address", address),
                                                                 new SqlParameter("@contactperson", contactperson),
                                                                 new SqlParameter("@contactnumber", contactnumber),
                                                                 new SqlParameter("@email", email),
                                                                 new SqlParameter("@terms", terms));

                return _isUpdate;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in updating master list" + Environment.NewLine + ex.Message.ToString(), ex);
            }
        }

        public static Boolean DeleteSupplier(string Id)
        {
            Boolean _isDelete = false;

            try
            {
                _isDelete = DatabaseAccessLayer.UpdateInfomation("DELETE FROM PS.MasterList WHERE ID = @Id",
                                                                 new SqlParameter("@Id", Id));

                return _isDelete;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in deleting supplier" + Environment.NewLine + ex.Message.ToString(), ex);
            }
        }

        public static DataTable GetVendorName(string vendorname)
        {
            try
            {
                return DatabaseAccessLayer.RetrieveDataTableInfo("SELECT VendorName [Supplier/Vendor], [Address], Terms, 'Cash' [Mode of Payment], ContactPerson [Contact Person]," +
                                                                 " ContactNumber [Contact Number] FROM PS.MasterList WHERE VendorName = @vendorname",
                                                                 new SqlParameter("@vendorname", vendorname));
            }
            catch (Exception ex)
            {
                throw new Exception("Error in getting vendor name" + Environment.NewLine + ex.Message.ToString(), ex);
            }
        }


        //----------------------------------------------------------------- PURCHASE ORDER ----------------------------------------------------------------------------

        public static DataTable GetDepartmentList()
        {
            try
            {
                return DatabaseAccessLayer.RetrieveDataTableInfo("SELECT * FROM PS.Department");
            }
            catch (Exception ex)
            {
                throw new Exception("Error in getting department list" + Environment.NewLine + ex.Message.ToString(), ex);
            }
        }

        public static int InsertPODetails(string vendorname, string refnum, string podate, int sId)
        {
            try
            {
                return DatabaseAccessLayer.UpdateInfomationProcPOID("PS.uspPO",
                                                                    new SqlParameter("@vendorname", vendorname),
                                                                    new SqlParameter("@refnum", refnum),
                                                                    new SqlParameter("@podate", podate),
                                                                    new SqlParameter("@pId", sId));
            }
            catch(Exception ex)
            {
                throw new Exception("Error in inserting po number" + Environment.NewLine + ex.Message.ToString(), ex);
            }
        }

        public static Boolean InsertPOList(int MID, string ponum, string desc, string qty, string uom, string price, string total)
        {
            try
            {
                return DatabaseAccessLayer.UpdateInfomation("INSERT INTO PS.POList VALUES (@mid, @ponumber, @desc, @qty, @uom, @price, @total)",
                                                            new SqlParameter("@mid", MID),
                                                            new SqlParameter("@ponumber", ponum),
                                                            new SqlParameter("@desc", desc),
                                                            new SqlParameter("@qty", qty),
                                                            new SqlParameter("@uom", uom),
                                                            new SqlParameter("@price", price),
                                                            new SqlParameter("@total", total));
            }
            catch (Exception ex)
            {
                throw new Exception("Error in inserting Purchase List" + Environment.NewLine + ex.Message.ToString(), ex);
            }
        }

        public static Boolean InsertPOStatus(int MID, string sDate)
        {
            try
            {
                return DatabaseAccessLayer.UpdateInfomation("INSERT INTO PS.POStatus VALUES (@mid, @stats, @sdate)",
                                                            new SqlParameter("@mid", MID),
                                                            new SqlParameter("@stats", "Ongoing"),
                                                            new SqlParameter("@sdate", sDate));
            }
            catch (Exception ex)
            {
                throw new Exception("Error in inserting Purchase List Status" + Environment.NewLine + ex.Message.ToString(), ex);
            }
        }

        public static int PONumber(string month)
        {
            DataTable Dt = new DataTable();
            int _PONumber = 0;

            try
            {
                Dt = DatabaseAccessLayer.RetrieveDataTableInfo("SELECT * FROM PS.AutoPO WHERE MONTH(PODate) = @month ORDER BY RefNum DESC",
                                                               new SqlParameter("@month", month));
                if (Dt.Rows.Count > 0)
                {
                    _PONumber = Convert.ToInt32(Dt.Rows[0]["RefNum"]) + 1;
                }
                else
                {
                    _PONumber = 1;
                }

                return _PONumber;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in getting PO number" + Environment.NewLine + ex.Message.ToString(), ex);
            }
            finally
            {
                Dt.Dispose();
            }
        }

        public static DataTable GetPONumberList()
        {
            try
            {
                return DatabaseAccessLayer.RetrieveDataTableInfo("SELECT DISTINCT(PONumber), MID FROM PS.POList ORDER BY MID DESC");
            }
            catch(Exception ex)
            {
                throw new Exception("Error in getting PO Number List" + Environment.NewLine + ex.Message.ToString(), ex);
            }
        }

        public static DataTable GetPOListEditList(string ponumber)
        {
            try
            {
                return DatabaseAccessLayer.RetrieveDataTableInfo("SELECT * FROM PS.AutoPO A INNER JOIN PS.POList P ON A.ID = P.MID WHERE P.PONumber = @po",
                                                                 new SqlParameter("@po", ponumber));
            }
            catch (Exception ex)
            {
                throw new Exception("Error in getting PO List Edit" + Environment.NewLine + ex.Message.ToString(), ex);
            }
        }

        public static Boolean AddPOList(string MID, string ponum, string pdesc, string qty, string uom, string price, string total)
        {
            try
            {
                return DatabaseAccessLayer.UpdateInfomation("INSERT INTO PS.POList VALUES (@mid, @ponum, @desc, @qty, @uom, @price, @total)",
                                                            new SqlParameter("@mid", MID),
                                                            new SqlParameter("@ponum", ponum),
                                                            new SqlParameter("@desc", pdesc),
                                                            new SqlParameter("@qty", qty),
                                                            new SqlParameter("@uom", uom),
                                                            new SqlParameter("@price", price),
                                                            new SqlParameter("@total", total));
            }
            catch(Exception ex)
            {
                throw new Exception("Error in adding PO List" + Environment.NewLine + ex.Message.ToString(), ex);
            }
        }

        public static Boolean UpdatePOList(string Id, string desc, string qty, string uom, string price, string total)
        {
            try
            {
                return DatabaseAccessLayer.UpdateInfomation("UPDATE PS.POList SET PDescription = @desc, PQty = @qty, PUOM = @uom," +
                                                            " PUnitPrice = @price, PTotal = @total WHERE ID = @Id",
                                                            new SqlParameter("@desc", desc),
                                                            new SqlParameter("@qty", qty),
                                                            new SqlParameter("@uom", uom),
                                                            new SqlParameter("@price", price),
                                                            new SqlParameter("@total", total),
                                                            new SqlParameter("@Id", Id));
            }
            catch (Exception ex)
            {
                throw new Exception("Error in updateing PO List" + Environment.NewLine + ex.Message.ToString(), ex);
            }
        }

        public static Boolean DeletePOList(string Id)
        {
            try
            {
                return DatabaseAccessLayer.UpdateInfomation("DELETE FROM PS.POList WHERE ID = @Id",
                                                            new SqlParameter("@Id", Id));
            }
            catch (Exception ex)
            {
                throw new Exception("Error in deleting PO List" + Environment.NewLine + ex.Message.ToString(), ex);
            }
        }


        //----------------------------------------------------------------- PURCHASE ORDER STATUS ----------------------------------------------------------------------------

        public static DataTable GetPurchaseOrderStatus(string sdate)
        {
            try
            {
                return DatabaseAccessLayer.RetrieveDataTableInfo("SELECT DISTINCT P.MID, P.PONumber, A.VendorName, FORMAT(A.PODate, 'MMM dd, yyyy') [PODate], " +
                                                                 " CASE WHEN DATEDIFF(DAY, PODate, @sdate) >= (SELECT SUBSTRING(Terms, 1, CHARINDEX(' ', Terms) - 1) - 2" +
                                                                 " FROM PS.MasterList WHERE VendorName = A.VendorName)" +
                                                                 " THEN 'Warning' ELSE 'Good' END [Con], S.ID [SID], S.Stats" +
                                                                 " FROM PS.AutoPO A INNER JOIN PS.POList P ON A.ID = P.MID" +
                                                                 " INNER JOIN PS.POStatus S ON S.MID = P.MID ORDER BY P.MID DESC",
                                                                 new SqlParameter("@sdate", sdate));
            }
            catch (Exception ex)
            {
                throw new Exception("Error in getting Purchase Order Status" + Environment.NewLine + ex.Message.ToString(), ex);
            }
        }

        public static Boolean UpdatePurchaseStatus(string Id, string stats)
        {
            try
            {
                return DatabaseAccessLayer.UpdateInfomation("UPDATE PS.POStatus SET Stats = @stats, SDate = @date WHERE ID = @Id",
                                                            new SqlParameter("@stats", stats),
                                                            new SqlParameter("@date", DateTime.Now.ToString("MM/dd/yyyy")),
                                                            new SqlParameter("@Id", Id));
            }
            catch(Exception ex)
            {
                throw new Exception("Error in updating purchase status" + Environment.NewLine + ex.Message.ToString(), ex);
            }
        }



















    }

}
