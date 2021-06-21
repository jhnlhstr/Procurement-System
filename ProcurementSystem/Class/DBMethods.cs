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
        public static Boolean GetUserLogin(string username, string password, ref string rights)
        {
            DataTable DtLog = new DataTable();
            
            try
            {
                DtLog = DatabaseAccessLayer.RetrieveDataTableInfo("SELECT * FROM PS.LoginCredentials WHERE Username = @username AND Password = @password AND Active = 'True'",
                                                                  new SqlParameter("@username", username),
                                                                  new SqlParameter("@password", password));

                if (DtLog.Rows.Count > 0)
                {
                    rights = DtLog.Rows[0]["Rights"].ToString();

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

        public static Boolean InsertSupplierList(string itemname, string vendor, string address, string contactperson, string contactnumber, string email, string terms, string tin)
        {
            Boolean _isInsert = false;

            try
            {
                _isInsert = DatabaseAccessLayer.UpdateInfomation("INSERT INTO PS.MasterList VALUES (@item, @vendor, @address, @contactperson, @contactnumber, @email, @terms, @tin, @active)", 
                                                                 new SqlParameter("@item", itemname),
                                                                 new SqlParameter("@vendor", vendor),
                                                                 new SqlParameter("@address", address),
                                                                 new SqlParameter("@contactperson", contactperson),
                                                                 new SqlParameter("@contactnumber", contactnumber),
                                                                 new SqlParameter("@email", email),
                                                                 new SqlParameter("@terms", terms),
                                                                 new SqlParameter("@tin", tin),
                                                                 new SqlParameter("@active", true));

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

        public static Boolean EditSupplierList(string Id, string itemname, string vendor, string address, string contactperson, string contactnumber, string email, string terms, string tin)
        {
            Boolean _isUpdate = false;
            
            try
            {
                _isUpdate = DatabaseAccessLayer.UpdateInfomation("UPDATE PS.MasterList SET ItemName = @item, VendorName = @vendor, Address = @address, ContactPerson = @contactperson," +
                                                                 " ContactNumber = @contactnumber, Email = @email, Terms = @terms, TIN = @tin WHERE ID = @Id",
                                                                 new SqlParameter("@Id", Id),
                                                                 new SqlParameter("@item", itemname),
                                                                 new SqlParameter("@vendor", vendor),
                                                                 new SqlParameter("@address", address),
                                                                 new SqlParameter("@contactperson", contactperson),
                                                                 new SqlParameter("@contactnumber", contactnumber),
                                                                 new SqlParameter("@email", email),
                                                                 new SqlParameter("@terms", terms),
                                                                 new SqlParameter("@tin", tin));

                return _isUpdate;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in updating master list" + Environment.NewLine + ex.Message.ToString(), ex);
            }
        }

        public static Boolean EditStatusSupplier(string Id, string active)
        {
            Boolean _isDelete = false;

            try
            {
                _isDelete = DatabaseAccessLayer.UpdateInfomation("UPDATE PS.MasterList SET Active = @active WHERE ID = @Id",
                                                                 new SqlParameter("@Id", Id),
                                                                 new SqlParameter("@active", active));

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






        //----------------------------------------------------------------- PURCHASE REQUEST ----------------------------------------------------------------------------

        public static int RequestNumber(string month)
        {
            DataTable Dt = new DataTable();
            int _reqNum = 0;

            try
            {
                Dt = DatabaseAccessLayer.RetrieveDataTableInfo("SELECT * FROM PS.AutoPR WHERE MONTH(RDate) = @month ORDER BY RefNum DESC",
                                                               new SqlParameter("@month", month));
                if (Dt.Rows.Count > 0)
                {
                    _reqNum = Convert.ToInt32(Dt.Rows[0]["RefNum"]) + 1;
                }
                else
                {
                    _reqNum = 1;
                }

                return _reqNum;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in getting request number" + Environment.NewLine + ex.Message.ToString(), ex);
            }
            finally
            {
                Dt.Dispose();
            }
        }

        public static int InsertPRNumber(string refnum, string podate, int sId)
        {
            try
            {
                return DatabaseAccessLayer.UpdateInfomationProcPOID("PS.uspPR",
                                                                    new SqlParameter("@refnum", refnum),
                                                                    new SqlParameter("@prdate", podate),
                                                                    new SqlParameter("@pId", sId));
            }
            catch (Exception ex)
            {
                throw new Exception("Error in inserting pr number" + Environment.NewLine + ex.Message.ToString(), ex);
            }
        }

        public static Boolean InsertPurchaseRequest(string rname, string dept, string email, string ticketnum, string prio, string specs, string billable, string account,
                                                    string item, string qty, string desc, string date, string prnum, int prId)
        {
            try
            {
                return DatabaseAccessLayer.UpdateInfomation("INSERT INTO PS.PurchaseRequest VALUES (@rname, @dept, @email," +
                                                            " @ticketnum, @prio, @specs, @billable, @account, @item, @qty, @desc, @date, @status, @prnumber, @prId)",
                                                            new SqlParameter("@rname", rname), new SqlParameter("@dept", dept), new SqlParameter("@email", email), 
                                                            new SqlParameter("@ticketnum", ticketnum), new SqlParameter("@prio", prio), new SqlParameter("@specs", specs), 
                                                            new SqlParameter("@billable", billable), new SqlParameter("@account", account), new SqlParameter("@item", item),
                                                            new SqlParameter("@qty", qty), new SqlParameter("@desc", desc), new SqlParameter("@date", date),
                                                            new SqlParameter("@status" , ""), new SqlParameter("@prnumber", prnum), new SqlParameter("@prId", prId));
            }
            catch (Exception ex)
            {
                throw new Exception("Error in inserting purchase request" + Environment.NewLine + ex.Message.ToString(), ex);
            }
        }

        public static DataTable GetRequestNumber(string stats, string prnum)
        {
            DataTable Dt = new DataTable();

            try 
            {
                if (stats == string.Empty)
                {
                    Dt = DatabaseAccessLayer.RetrieveDataTableInfo("SELECT DISTINCT RPRID, RPRNum FROM PS.PurchaseRequest WHERE RStatus <> 'Approved'" +
                                                                   " AND RStatus <> 'Cancelled' ORDER BY RPRID DESC");
                }
                else
                {
                    Dt = DatabaseAccessLayer.RetrieveDataTableInfo("SELECT * FROM PS.PurchaseRequest WHERE (RStatus <> 'Approved' OR RStatus <> 'Cancelled') AND RPRNum = @prnum",
                                                                   new SqlParameter("@prnum", prnum));
                }

                return Dt;
            }
            catch(Exception ex)
            {
                throw new Exception("Error in getting Request information" + Environment.NewLine + ex.Message.ToString(), ex);
            }
            finally
            {
                Dt.Dispose();
            }
        }

        public static Boolean InsertPurchaseProposal(string rId, string vendorname, string item, string qty, string cost, string prop)
        {
            try
            {
                return DatabaseAccessLayer.UpdateInfomation("INSERT INTO PS.PurchaseProposal VALUES (@rid, @vendor, @item, @qty, @cost, @status, @prop)",
                                                            new SqlParameter("@rid", rId),
                                                            new SqlParameter("@vendor", vendorname),
                                                            new SqlParameter("@item", item),
                                                            new SqlParameter("@qty", qty),
                                                            new SqlParameter("@cost", cost),
                                                            new SqlParameter("@status", ""),
                                                            new SqlParameter("@prop", prop));
            }
            catch (Exception ex)
            {
                throw new Exception("Error in inserting purchase proposal" + Environment.NewLine + ex.Message.ToString(), ex);
            }
        }

        public static Boolean UpdatePurchaseProposal(string Id, string stats)
        {
            try
            {
                return DatabaseAccessLayer.UpdateInfomation("UPDATE PS.PurchaseProposal SET PStatus = @status WHERE ID = @Id",
                                                            new SqlParameter("@status", stats),
                                                            new SqlParameter("@Id", Id));

            }
            catch(Exception ex)
            {
                throw new Exception("Error in updating Purchase Proposal" + Environment.NewLine + ex.Message.ToString(), ex);
            }

        }

        public static DataTable BindProposalStatus(string prnum)
        {
            DataTable Dt = new DataTable();

            try
            {
                if (prnum == string.Empty)
                {
                    Dt = DatabaseAccessLayer.RetrieveDataTableInfo("SELECT DISTINCT PR.RPRID, PP.ID [pID], PR.RPRNum, PP.PProp, PP.PVendorName, PP.PItem, PP.PQty, PP.PCost, PP.PStatus" +
                                                                   " FROM PS.PurchaseRequest PR INNER JOIN PS.PurchaseProposal PP ON RPRID = PP.RID ORDER BY PR.RPRID DESC");
                }
                else
                {
                    Dt = DatabaseAccessLayer.RetrieveDataTableInfo("SELECT DISTINCT PR.RPRID, PP.ID [pID], PR.RPRNum, PP.PProp, PP.PVendorName, PP.PItem, PP.PQty, PP.PCost, PP.PStatus" +
                                                                   " FROM PS.PurchaseRequest PR INNER JOIN PS.PurchaseProposal PP ON RPRID = PP.RID WHERE RPRNum = @prnum ORDER BY PR.RPRID DESC",
                                                                    new SqlParameter("@prnum", prnum));
                }

                return Dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in binding Proposal Status" + Environment.NewLine + ex.Message.ToString(), ex);
            }
            finally
            {
                Dt.Dispose();
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

        public static Boolean InsertPOList(string prfID, int MID, string ponum, string desc, string qty, string uom, string price, string total, string terms, string bit)
        {
            try
            {
                return DatabaseAccessLayer.UpdateInfomation("INSERT INTO PS.POList VALUES (@prfId, @mid, @ponumber, @desc, @qty, @uom, @price, @total, @terms, @bit)",
                                                            new SqlParameter("@prfId", prfID),
                                                            new SqlParameter("@mid", MID),
                                                            new SqlParameter("@ponumber", ponum),
                                                            new SqlParameter("@desc", desc),
                                                            new SqlParameter("@qty", qty),
                                                            new SqlParameter("@uom", uom),
                                                            new SqlParameter("@price", price),
                                                            new SqlParameter("@total", total),
                                                            new SqlParameter("@terms", terms),
                                                            new SqlParameter("@bit", bit));
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
                return DatabaseAccessLayer.UpdateInfomation("INSERT INTO PS.POStatus(MID, Stats, SDate) VALUES (@mid, @stats, @sdate)",
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

        public static Boolean AddPOList(string prfID, string MID, string ponum, string pdesc, string qty, string uom, string price, string total)
        {
            try
            {
                return DatabaseAccessLayer.UpdateInfomation("INSERT INTO PS.POList VALUES (@prf, @mid, @ponum, @desc, @qty, @uom, @price, @total)",
                                                            new SqlParameter("@mid", MID),
                                                            new SqlParameter("@prf", prfID),
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

        public static DataTable ListofPONum(string vendor)
        {
            try
            {
                return DatabaseAccessLayer.RetrieveDataTableInfo("SELECT DISTINCT MID, PONumber FROM PS.AutoPO A INNER JOIN PS.POList P ON A.ID = P.MID" +
                                                                 " WHERE A.VendorName = @vendor ORDER BY MID DESC",
                                                                 new SqlParameter("@vendor", vendor));
            }
            catch(Exception ex)
            {
                throw new Exception("Error in getting PO List Number" + Environment.NewLine + ex.Message.ToString(), ex);
            }
        }


        public static DataTable ApprovalDetailsEmail(string tab, string rprID)
        {
            DataTable Dt = new DataTable();

            try
            {
                if (tab == "Request")
                {
                    Dt = DatabaseAccessLayer.RetrieveDataTableInfo("SELECT * FROM PS.PurchaseRequest WHERE RPRID = @Id",
                                                                    new SqlParameter("@Id", rprID));
                }
                else
                {
                    Dt = DatabaseAccessLayer.RetrieveDataTableInfo("SELECT * FROM PS.PurchaseProposal WHERE RID = @Id",
                                                                    new SqlParameter("@Id", rprID));
                }

                return Dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in getting Approval Details" + Environment.NewLine + ex.Message.ToString(), ex);
            }
            finally
            {
                Dt.Dispose();
            }

        }

        public static string GetAccountPOEdit(string Id)
        {
            DataTable Dt = new DataTable();
            string accnt = string.Empty;

            try
            {
                Dt = DatabaseAccessLayer.RetrieveDataTableInfo("SELECT DISTINCT RAccount FROM PS.PurchaseRequest WHERE RPRID = @Id",
                                                                new SqlParameter("@Id", Id));

                if (Dt.Rows.Count > 0)
                {
                    accnt = Dt.Rows[0]["RAccount"].ToString();
                }

                return accnt;
            }
            catch(Exception ex)
            {
                throw new Exception("Error in getting account PO" + Environment.NewLine + ex.Message.ToString(), ex);
            }
            finally
            {
                Dt.Dispose();
            }
        }

        public static string CheckingTIN(string vendorname)
        {
            DataTable DtTIN = new DataTable();
            string tinxx = string.Empty;

            try
            {
                DtTIN = DatabaseAccessLayer.RetrieveDataTableInfo("SELECT * FROM PS.MasterList WHERE VendorName = @vendor",
                                                                  new SqlParameter("@vendor", vendorname));

                if (DtTIN.Rows.Count > 0)
                {
                    tinxx = DtTIN.Rows[0]["TIN"].ToString();
                }

                return tinxx;
            }
            catch(Exception ex)
            {
                throw new Exception("Error in checking TIN" + Environment.NewLine + ex.Message.ToString(), ex);
            }
        }







        //----------------------------------------------------------------- PURCHASE ORDER STATUS ----------------------------------------------------------------------------

        //public static DataTable GetPurchaseOrderStatus(string sdate)
        //{
        //    try
        //    {
        //        return DatabaseAccessLayer.RetrieveDataTableInfo("SELECT DISTINCT P.MID, P.PONumber, A.VendorName, FORMAT(A.PODate, 'MMM dd, yyyy') [PODate], " +
        //                                                         " CASE WHEN DATEDIFF(DAY, PODate, @sdate) >= (SELECT SUBSTRING(Terms, 1, CHARINDEX(' ', Terms) - 1) - 2" +
        //                                                         " FROM PS.MasterList WHERE VendorName = A.VendorName)" +
        //                                                         " THEN 'Warning' ELSE 'Good' END [Con], S.ID [SID], S.Stats" +
        //                                                         " FROM PS.AutoPO A INNER JOIN PS.POList P ON A.ID = P.MID" +
        //                                                         " INNER JOIN PS.POStatus S ON S.MID = P.MID ORDER BY P.MID DESC",
        //                                                         new SqlParameter("@sdate", sdate));
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error in getting Purchase Order Status" + Environment.NewLine + ex.Message.ToString(), ex);
        //    }
        //}

        public static DataTable PurchaseStatusBind(string stats)
        {
            DataTable Dt = new DataTable();

            try
            {
                if (stats == "request")
                {
                    Dt = DatabaseAccessLayer.RetrieveDataTableInfo("SELECT DISTINCT PL.PRFID, PR.RPRNum, PR.RName, PR.RAccount, PR.RDesc," +
                                                                   " PR.RDate, PR.RStatus  FROM PS.PurchaseRequest PR LEFT JOIN PS.POList PL ON PR.RPRID = PL.PRFID" +
                                                                   " WHERE PL.PRFID IS NULL OR PL.PRFID = ''");
                }
                else
                {
                    Dt = DatabaseAccessLayer.RetrieveDataTableInfo("SELECT *," +
                                                                   " CASE WHEN Pbit = 'True' THEN" +
                                                                   "     CASE WHEN PO_Status = 'Delivered' THEN" +
                                                                   "         CASE WHEN Paid_Date IS NOT NULL THEN DATEDIFF(DAY, Status_Date, Paid_Date)" +
                                                                   "         ELSE DATEDIFF(DAY, Status_Date, GETDATE()) END" +
                                                                   "     ELSE '0' END" +
                                                                   " ELSE '0' END [CountTerms] FROM (" +
                                                                   " SELECT DISTINCT(SELECT ID FROM PS.POStatus WHERE MID = PL.MID) [StatsID], PL.PRFID, PL.PONumber," +
                                                                   " (SELECT PODate FROM PS.AutoPO WHERE ID = PL.MID) [Purchase_Date], PR.RDesc, PR.RAccount, PL.PTerms, PL.Pbit," +
                                                                   " (SELECT Stats FROM PS.POStatus WHERE MID = PL.MID) [PO_Status]," +
                                                                   " (SELECT SDate FROM PS.POStatus WHERE MID = PL.MID) [Status_Date]," +
                                                                   " (SELECT PaidDate FROM PS.POStatus WHERE MID = PL.MID) [Paid_Date]," +
                                                                   " (SELECT Bill FROM PS.POStatus WHERE MID = PL.MID) [Bill]" +
                                                                   " FROM PS.PurchaseRequest PR INNER JOIN PS.POList PL ON PR.RPRID = PL.PRFID) TB1" +
                                                                   " ORDER BY PRFID DESC");
                }

                return Dt;
            
            }
            catch(Exception ex)
            {
                throw new Exception("Error in getting purchase status" + Environment.NewLine + ex.Message.ToString(), ex);
            }
            finally
            {
                Dt.Dispose();
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

        public static Boolean UpdatePurchaseStatusPaid(string Id)
        {
            try
            {
                return DatabaseAccessLayer.UpdateInfomation("UPDATE PS.POStatus SET PaidDate = @paid WHERE ID = @Id",
                                                            new SqlParameter("@paid", DateTime.Now.ToString("MM/dd/yyyy")),
                                                            new SqlParameter("@Id", Id));
            }
            catch (Exception ex)
            {
                throw new Exception("Error in updating purchase paid date" + Environment.NewLine + ex.Message.ToString(), ex);
            }
        }

        public static Boolean UpdatePurchaseStatusBilled(string Id, string bill)
        {
            try
            {
                return DatabaseAccessLayer.UpdateInfomation("UPDATE PS.POStatus SET Bill = @bill WHERE ID = @Id",
                                                            new SqlParameter("@bill", bill),
                                                            new SqlParameter("@Id", Id));
            }
            catch (Exception ex)
            {
                throw new Exception("Error in updating purchase billed" + Environment.NewLine + ex.Message.ToString(), ex);
            }
        }





        //----------------------------------------------------------------- DASHBOARD ----------------------------------------------------------------------------

        public static DataTable DashBoardTotalRequest(string month, string year)
        {
            try
            {
                return DatabaseAccessLayer.RetrieveDataTableInfo("SELECT COUNT(DISTINCT RPRNum) [TotalRequest]," +
                                                                 " (SELECT COUNT(DISTINCT RPRNum) FROM PS.PurchaseRequest WHERE RStatus = 'approved' AND MONTH(RDate) = @month" +
                                                                    " AND YEAR(RDate) = @year) [TotalApprove]," +
                                                                 " (SELECT COUNT(DISTINCT RPRNum) FROM PS.PurchaseRequest WHERE RStatus = 'cancelled' AND MONTH(RDate) = @month" +
                                                                    " AND YEAR(RDate) = @year) [TotalCancel]" +
                                                                 " FROM PS.PurchaseRequest WHERE MONTH(RDate) = @month AND YEAR(RDate) = @year",
                                                                 new SqlParameter("@month",  month),
                                                                 new SqlParameter("@year", year));
            }
            catch(Exception ex)
            {
                throw new Exception("Error in getting dashboard total request" + Environment.NewLine + ex.Message.ToString(), ex);
            }
        }
        
        public static DataTable DashBoardTotalPO(string month, string year)
        {
            try
            {
                return DatabaseAccessLayer.RetrieveDataTableInfo("SELECT COUNT(*) [TotalPO]," +
                                                                 " (SELECT COUNT(*) FROM PS.AutoPO A INNER JOIN PS.POStatus S ON A.ID = S.MID WHERE MONTH(A.PODate) = @month" +
                                                                    " AND YEAR(A.PODate) = @year AND S.Stats = 'Ongoing') [TotalOngoing]," +
                                                                 " (SELECT COUNT(*) FROM PS.AutoPO A INNER JOIN PS.POStatus S ON A.ID = S.MID WHERE MONTH(A.PODate) = @month" +
                                                                    " AND YEAR(A.PODate) = @year AND S.Stats = 'Cancelled') [TotalCancelled]," +
                                                                 " (SELECT COUNT(*) FROM PS.AutoPO A INNER JOIN PS.POStatus S ON A.ID = S.MID WHERE MONTH(A.PODate) = @month" +
                                                                    " AND YEAR(A.PODate) = @year AND S.Stats = 'Delivered') [TotalDelivered] FROM (" +
                                                                 " SELECT DISTINCT P.PONumber, A.PODate FROM PS.AutoPO A" +
                                                                 " INNER JOIN PS.POList P ON A.ID = P.MID) TB1" +
                                                                 " WHERE MONTH(PODate) = @month AND YEAR(PODate) = @year",
                                                                 new SqlParameter("@month", month),
                                                                 new SqlParameter("@year", year));
            }
            catch(Exception ex)
            {
                throw new Exception("Error in getting dashboard total PO" + Environment.NewLine + ex.Message.ToString(), ex);
            }
        }

        public static DataTable DashboardListRequest()
        {
            try
            {
                return DatabaseAccessLayer.RetrieveDataTableInfo("SELECT DISTINCT RPRID, RPRNum, RDate, RStatus FROM PS.PurchaseRequest WHERE RStatus <> 'Approved'" +
                                                                 " OR RStatus <> 'Cancelled' ORDER BY RPRID DESC");
            }
            catch(Exception ex)
            {
                throw new Exception("Error in getting list of Request" + Environment.NewLine + ex.Message.ToString(), ex);
            }
        }

        public static Boolean DashboardUpdateListRequest(string Id, string stats)
        {
            try
            {
                return DatabaseAccessLayer.UpdateInfomation("UPDATE PS.PurchaseRequest SET RStatus = @stats WHERE RPRID = @Id",
                                                            new SqlParameter("@Id", Id),
                                                            new SqlParameter("@stats", stats));
            }
            catch(Exception ex)
            {
                throw new Exception("Error in updating list of Request" + Environment.NewLine + ex.Message.ToString(), ex);
            }
        }

        public static DataTable DashboardGraphRequest(string year)
        {
            try
            {
                return DatabaseAccessLayer.RetrieveDataTableInfo("SELECT COUNT(DISTINCT RPRNum) [Jan]," +
                                                               " (SELECT COUNT(DISTINCT RPRNum) FROM PS.PurchaseRequest WHERE MONTH(RDate) = 02" +
                                                                  " AND YEAR(RDate) = @year) [Feb]," +
                                                               " (SELECT COUNT(DISTINCT RPRNum) FROM PS.PurchaseRequest WHERE MONTH(RDate) = 03" +
                                                                  " AND YEAR(RDate) = @year) [Mar]," +
                                                               " (SELECT COUNT(DISTINCT RPRNum) FROM PS.PurchaseRequest WHERE MONTH(RDate) = 04" +
                                                                  " AND YEAR(RDate) = @year) [Apr]," +
                                                               " (SELECT COUNT(DISTINCT RPRNum) FROM PS.PurchaseRequest WHERE MONTH(RDate) = 05" +
                                                                  " AND YEAR(RDate) = @year) [May]," +
                                                               " (SELECT COUNT(DISTINCT RPRNum) FROM PS.PurchaseRequest WHERE MONTH(RDate) = 06" +
                                                                  " AND YEAR(RDate) = @year) [June]," +
                                                               " (SELECT COUNT(DISTINCT RPRNum) FROM PS.PurchaseRequest WHERE MONTH(RDate) = 07" +
                                                                  " AND YEAR(RDate) = @year) [July]," +
                                                               " (SELECT COUNT(DISTINCT RPRNum) FROM PS.PurchaseRequest WHERE MONTH(RDate) = 08" +
                                                                  " AND YEAR(RDate) = @year) [Aug]," +
                                                               " (SELECT COUNT(DISTINCT RPRNum) FROM PS.PurchaseRequest WHERE MONTH(RDate) = 09" +
                                                                  " AND YEAR(RDate) = @year) [Sep]," +
                                                               " (SELECT COUNT(DISTINCT RPRNum) FROM PS.PurchaseRequest WHERE MONTH(RDate) = 10" +
                                                                  " AND YEAR(RDate) = @year) [Oct]," +
                                                               " (SELECT COUNT(DISTINCT RPRNum) FROM PS.PurchaseRequest WHERE MONTH(RDate) = 11" +
                                                                  " AND YEAR(RDate) = @year) [Nov]," +
                                                               " (SELECT COUNT(DISTINCT RPRNum) FROM PS.PurchaseRequest WHERE MONTH(RDate) = 12" +
                                                                  " AND YEAR(RDate) = @year) [Dec]" +
                                                               " FROM PS.PurchaseRequest WHERE MONTH(RDate) = 01 AND YEAR(RDate) = @year",
                                                               new SqlParameter("@year", year));
            }
            catch (Exception ex)
            {
                throw new Exception("Error in getting graph request" + Environment.NewLine + ex.Message.ToString(), ex);
            }

        }

        public static DataTable TotalPOClient(string month, string year)
        {
            try
            {
                return DatabaseAccessLayer.RetrieveDataTableInfo("SELECT RAccount, SUM(TotalPO) [TotalPO] FROM (" +
                                                                 " SELECT DISTINCT PR.RPRID, PR.RAccount, PR.RDate, PL.PDescription, PL.PUOM," +
                                                                 "  CASE WHEN PL.PUOM = 'discount/percent' OR PL.PUOM = 'discount/fixed' THEN - ABS(PTotal)" +
                                                                 "  ELSE PTotal END [TotalPO] FROM PS.PurchaseRequest PR" +
                                                                 " INNER JOIN PS.POList PL ON PR.RPRID = PL.PRFID" + 
                                                                 " WHERE MONTH(PR.RDate) = @month AND YEAR(PR.RDate) = @year) TB1" +
                                                                 " GROUP BY RAccount ORDER BY RAccount",
                                                                 new SqlParameter("@month", month),
                                                                 new SqlParameter("@year", year));

            }
            catch (Exception ex)
            {
                throw new Exception("Error in getting total PO per client" + Environment.NewLine + ex.Message.ToString(), ex);
            }
        }










        //----------------------------------------------------------------- USER CREDENTIALS ----------------------------------------------------------------------------

        public static DataTable GetUsersCredentialsList()
        {
            try
            {
                return DatabaseAccessLayer.RetrieveDataTableInfo("SELECT * FROM PS.LoginCredentials ORDER BY ID");
            }
            catch (Exception ex)
            {
                throw new Exception("Error in getting user credentials list" + Environment.NewLine + ex.Message.ToString(), ex);
            }
        }

        public static Boolean InsertUserCredentials(string username, string password, string email, string rights)
        {
            try
            {
                return DatabaseAccessLayer.UpdateInfomation("INSERT INTO PS.LoginCredentials VALUES (@username, @password, @email, @rights, @active)",
                                                            new SqlParameter("@username", username),
                                                            new SqlParameter("@password", password),
                                                            new SqlParameter("@email", email),
                                                            new SqlParameter("@rights", rights),
                                                            new SqlParameter("@active", true));
            }
            catch(Exception ex)
            {
                throw new Exception("Error in inserting User Credentials" + Environment.NewLine + ex.Message.ToString(), ex);
            }
        }

        public static Boolean UpdateUserCredentials(string Id, string username, string password, string email, string rights)
        {
            try
            {
                return DatabaseAccessLayer.UpdateInfomation("UPDATE PS.LoginCredentials SET Username = @username, Password = @password, Email = @email, Rights = @rights WHERE ID = @Id",
                                                            new SqlParameter("@username", username),
                                                            new SqlParameter("@password", password),
                                                            new SqlParameter("@email", email),
                                                            new SqlParameter("@rights", rights),
                                                            new SqlParameter("@Id", Id));
            }
            catch (Exception ex)
            {
                throw new Exception("Error in updating user credentials list" + Environment.NewLine + ex.Message.ToString(), ex);
            }
        }

        public static Boolean ActivateUserCredentials(string Id, string active)
        {
            try
            {
                return DatabaseAccessLayer.UpdateInfomation("UPDATE PS.LoginCredentials SET Active = @active WHERE ID = @Id",
                                                            new SqlParameter("@active", active),
                                                            new SqlParameter("@Id", Id));
            }
            catch(Exception ex)
            {
                throw new Exception("Error in activate account" + Environment.NewLine + ex.Message.ToString(), ex);
            }
        }

        public static Boolean DeleteCredentials(string Id)
        {
            try
            {
                return DatabaseAccessLayer.UpdateInfomation("DELETE PS.LoginCredentials WHERE ID = @Id",
                                                            new SqlParameter("@Id", Id));
            }
            catch (Exception ex)
            {
                throw new Exception("Error in deleting user credentials" + Environment.NewLine + ex.Message.ToString(), ex);
            }
        }






















    }

}
