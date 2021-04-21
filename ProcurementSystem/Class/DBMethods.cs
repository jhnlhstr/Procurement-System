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
        public static DataTable GetSupplierMasterList()
        {
            try
            {
                return DatabaseAccessLayer.RetrieveDataTableInfo("SELECT * FROM PS.MasterList");
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
    }

}
