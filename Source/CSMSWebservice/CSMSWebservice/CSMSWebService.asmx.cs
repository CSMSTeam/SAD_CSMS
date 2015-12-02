using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.Data;
using System.Configuration;

namespace CSMSWebservice
{
    /// <summary>
    /// Summary description for CSMSWebservice
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CSMSWebservice : System.Web.Services.WebService
    {
        SqlConnection conn;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand cmd;
        SqlCommandBuilder cb;
        DataTable dt;
        SqlDataReader dr;
        [WebMethod]
        public DataTable CustomerLoadProduct()
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "CustomerGetProducts";
            da = new SqlDataAdapter(cmd);
            cb = new SqlCommandBuilder(da);
            ds = new DataSet();
            da.FillSchema(ds, SchemaType.Mapped);
            da.Fill(ds, "CusProducts");
            dt = ds.Tables["CusProducts"];
            conn.Close();
            return dt;            
        }

        [WebMethod]
        public DataTable AdminViewAccount()
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AdminViewAccount";
            da = new SqlDataAdapter(cmd);
            cb = new SqlCommandBuilder(da);
            ds = new DataSet();
            da.FillSchema(ds, SchemaType.Mapped);
            da.Fill(ds, "Employees");
            dt = ds.Tables["Employees"];
            conn.Close();
            return dt;
        }
        [WebMethod]
        public void AdminAddNewAccount(string empname, string empusername, 
                                        string emppassword, string emprole, 
                                        string empsex, string empbrithdate, string emphiredate,
                                        string empaddress, string empphone, string empcity,string empcountry, 
                                        float salary, int hourswork, int mgrid, bool empstatus) 
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AdminAddNewAccount";

            SqlParameter param = new SqlParameter("@empname", SqlDbType.NVarChar);
            param.Size = 50;
            param.Value = empname;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@empusername", SqlDbType.NVarChar);
            param.Size = 20;
            param.Value = empusername;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@emppassword", SqlDbType.NVarChar);
            param.Size = 20;
            param.Value = emppassword;
            cmd.Parameters.Add(param);


            param = new SqlParameter("@emprole", SqlDbType.NVarChar);
            param.Size = 15;
            param.Value = emprole;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@empsex", SqlDbType.NVarChar);
            param.Size = 10;
            param.Value = empsex;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@empbrithdate", SqlDbType.DateTime);
            param.Value = DateTime.Parse(empbrithdate).ToShortDateString();
            cmd.Parameters.Add(param);

            param = new SqlParameter("@emphiredate", SqlDbType.DateTime);
            param.Value = DateTime.Parse(emphiredate).ToShortDateString();
            cmd.Parameters.Add(param);

            param = new SqlParameter("@empaddress", SqlDbType.NVarChar);
            param.Size = 60;
            param.Value = empaddress;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@empphone", SqlDbType.NVarChar);
            param.Size = 24;
            param.Value = empphone;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@empcity", SqlDbType.NVarChar);
            param.Size = 20;
            param.Value = empcity;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@empcountry", SqlDbType.NVarChar);
            param.Size = 15;
            param.Value = empcountry;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@empsalary", SqlDbType.Money);            
            param.Value = salary;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@emphourwork", SqlDbType.Int);          
            param.Value = hourswork;
            cmd.Parameters.Add(param);                     

            param = new SqlParameter("@empmgrid", SqlDbType.Int);
            param.Value = mgrid;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@empstatus", SqlDbType.Bit);
            param.Value = empstatus;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
        }
        [WebMethod]
        public void AdminUpdateAccount(int empid, string empname, string empusername,
                                        string emppassword, string emprole,
                                        string empsex, string empbrithdate, string emphiredate,
                                        string empaddress, string empphone, string empcity, string empcountry,
                                        float salary, int hourswork, int mgrid, bool empstatus)
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AdminUpdateAccount";

            SqlParameter param = new SqlParameter("@empid", SqlDbType.Int);
            param.Value = empid;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@empname", SqlDbType.NVarChar);
            param.Size = 50;
            param.Value = empname;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@empusername", SqlDbType.NVarChar);
            param.Size = 20;
            param.Value = empusername;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@emppassword", SqlDbType.NVarChar);
            param.Size = 20;
            param.Value = emppassword;
            cmd.Parameters.Add(param);


            param = new SqlParameter("@emprole", SqlDbType.NVarChar);
            param.Size = 15;
            param.Value = emprole;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@empsex", SqlDbType.NVarChar);
            param.Size = 10;
            param.Value = empsex;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@empbrithdate", SqlDbType.DateTime);
            param.Value = DateTime.Parse(empbrithdate).ToShortDateString();
            cmd.Parameters.Add(param);

            param = new SqlParameter("@emphiredate", SqlDbType.DateTime);
            param.Value = DateTime.Parse(emphiredate).ToShortDateString();
            cmd.Parameters.Add(param);

            param = new SqlParameter("@empaddress", SqlDbType.NVarChar);
            param.Size = 60;
            param.Value = empaddress;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@empphone", SqlDbType.NVarChar);
            param.Size = 24;
            param.Value = empphone;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@empcity", SqlDbType.NVarChar);
            param.Size = 20;
            param.Value = empcity;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@empcountry", SqlDbType.NVarChar);
            param.Size = 15;
            param.Value = empcountry;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@empsalary", SqlDbType.Money);
            param.Value = salary;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@emphourwork", SqlDbType.Int);
            param.Value = hourswork;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@empmgrid", SqlDbType.Int);
            param.Value = mgrid;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@empstatus", SqlDbType.Bit);
            param.Value = empstatus;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
        }
        [WebMethod]
        public void AdminDeleteAccount(int empid) 
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AdminDeleteAccount";

            SqlParameter param = new SqlParameter("@empid", SqlDbType.Int);
            param.Value = empid;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
        }

        [WebMethod]
        public DataTable AdminViewReport(DateTime fromDate, DateTime toDate, string status)
        {
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                conn.Open();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AdminViewReport";

                SqlParameter param = new SqlParameter("@fromdate", SqlDbType.DateTime);
                param.Value = fromDate;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@todate", SqlDbType.DateTime);
                param.Value = toDate;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@status", SqlDbType.NChar);
                param.Size = 15;
                param.Value = status;
                cmd.Parameters.Add(param);

                da = new SqlDataAdapter(cmd);
                cb = new SqlCommandBuilder(da);
                ds = new DataSet();
                da.FillSchema(ds, SchemaType.Mapped);
                da.Fill(ds, "AdminViewReport");
                dt = ds.Tables["AdminViewReport"];
            }
            catch
            {
                //Write Log file                
            }
            finally
            {
                if (cmd != null)
                    cmd.Cancel();
                if (conn != null)
                    conn.Close();
            }
            return dt;

        }

        [WebMethod]
        public DataTable ManagerViewProducts() 
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ManagerViewProduct";
            da = new SqlDataAdapter(cmd);
            cb = new SqlCommandBuilder(da);
            ds = new DataSet();
            da.FillSchema(ds, SchemaType.Mapped);
            da.Fill(ds,"Products");
            dt = ds.Tables["Products"];
            conn.Close();
            return dt;
        }
        [WebMethod]
        public void ManagerAddProduct(string productname, int categoryid, float importpirce, 
                                        float unitprice, int productquantity, bool productstatus) 
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ManagerAddProduct";

            SqlParameter param = new SqlParameter("@productname", SqlDbType.NVarChar);
            param.Size = 50;
            param.Value = productname;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@categoryid", SqlDbType.Int);
            param.Value = categoryid;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@importpirce", SqlDbType.Money);
            param.Value = importpirce;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@unitprice", SqlDbType.Money);
            param.Value = unitprice;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@productquantity", SqlDbType.Int);
            param.Value = productquantity;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@productstatus", SqlDbType.Bit);
            param.Value = productstatus;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
        }
        [WebMethod]
        public void ManagerUpdateProduct(int productid, string productname, int categoryid, float importpirce,
                                        float unitprice, int productquantity, bool productstatus) 
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ManagerUpdateProduct";

            SqlParameter param = new SqlParameter("@productid", SqlDbType.Int);
            param.Value = productid;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@productname", SqlDbType.NVarChar);
            param.Size = 50;
            param.Value = productname;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@categoryid", SqlDbType.Int);
            param.Value = categoryid;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@importpirce", SqlDbType.Money);
            param.Value = importpirce;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@unitprice", SqlDbType.Money);
            param.Value = unitprice;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@productquantity", SqlDbType.Int);
            param.Value = productquantity;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@productstatus", SqlDbType.Bit);
            param.Value = productstatus;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
        }
        [WebMethod]
        public void ManagerDeleteProduct(int productid) 
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ManagerDeleteProduct";

            SqlParameter param = new SqlParameter("@productid", SqlDbType.Int);
            param.Value = productid;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
        }
        
        [WebMethod]
        public DataTable ManagerLoadCategories()
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ManagerLoadCategory";
            da = new SqlDataAdapter(cmd);
            cb = new SqlCommandBuilder(da);
            ds = new DataSet();
            da.FillSchema(ds, SchemaType.Mapped);
            da.Fill(ds, "CategoryIdName");
            dt = ds.Tables["CategoryIdName"];
            conn.Close();
            return dt;            
        }

        [WebMethod]
        public DataTable ManagerViewCategories()
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ManagerViewCategories";
            da = new SqlDataAdapter(cmd);
            cb = new SqlCommandBuilder(da);
            ds = new DataSet();
            da.FillSchema(ds, SchemaType.Mapped);
            da.Fill(ds, "Categories");
            dt = ds.Tables["Categories"];
            conn.Close();
            return dt;            
        }

        [WebMethod]
        public void ManagerAddCategories(string categoryname, string categorydescription)
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ManagerAddCategories";

            SqlParameter param = new SqlParameter("@categoryname", SqlDbType.NVarChar);
            param.Size = 50;
            param.Value = categoryname;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@description", SqlDbType.NVarChar);
            param.Size = 200;
            param.Value = categorydescription;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
        }

        [WebMethod]
        public void ManagerUpdateCategories(int categoryid, string categoryname, string categorydescription)
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ManagerUpdateCategories";

            SqlParameter param = new SqlParameter("@categoryid", SqlDbType.Int);
            param.Value = categoryid;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@categoryname", SqlDbType.NVarChar);
            param.Size = 50;
            param.Value = categoryname;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@description", SqlDbType.NVarChar);
            param.Size = 200;
            param.Value = categorydescription;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
        }

        [WebMethod]
        public void ManagerDeleteCategories(int categoryid)
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ManagerDeleteCategories";

            SqlParameter param = new SqlParameter("@categoryid", SqlDbType.Int);
            param.Value = categoryid;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
        }

        [WebMethod]
        public bool CustomerAddOrder(string orderid, DateTime orderdate, string orderadress,
                                     float total, string cusphone)
        {
            bool isSuccess = false;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                conn.Open();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CustomerAddOrder";

                SqlParameter param = new SqlParameter("@orderid", SqlDbType.NVarChar);
                param.Size = 20;
                param.Value = orderid;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@orderdate", SqlDbType.DateTime);
                param.Value = orderdate;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@orderadress", SqlDbType.NVarChar);
                param.Size = 100;
                param.Value = orderadress;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@total", SqlDbType.Float);
                param.Value = total;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@status", SqlDbType.NVarChar);
                param.Size = 15;
                param.Value = "Pending";
                cmd.Parameters.Add(param);

                param = new SqlParameter("@cusphone", SqlDbType.NVarChar);
                param.Size = 13;
                param.Value = cusphone;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
                isSuccess = true;
            }
            catch
            {
                isSuccess = false;
                //WriteLogFile
            }
            finally
            {
                if (cmd != null)
                    cmd.Cancel();
                if (conn != null)
                    conn.Close();
            }
            return isSuccess;
        }

        [WebMethod]
        public bool CustomerInsertOrderDetail(string orderid, int productid, float unitprice, int quantity)
        {
            bool isSuccess = false;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                conn.Open();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CustomerInsertOrderDetail";

                SqlParameter param = new SqlParameter("@orderid", SqlDbType.NVarChar);
                param.Size = 20;
                param.Value = orderid;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@productid", SqlDbType.Int);
                param.Value = productid;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@unitprice", SqlDbType.Float);
                param.Value = unitprice;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@quantity", SqlDbType.Int);
                param.Value = quantity;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
                isSuccess = true;
            }
            catch
            {
                isSuccess = false;
            }
            finally
            {
                if (cmd != null)
                    cmd.Cancel();
                if (conn != null)
                    conn.Close();
            }
            return isSuccess;            
        }

        [WebMethod]
        public DataTable SalespersionViewOrders()
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SalespersionViewOrders";

            SqlParameter param = new SqlParameter("@status", SqlDbType.NVarChar);
            param.Size = 15;
            param.Value = "Pending";
            cmd.Parameters.Add(param);

            da = new SqlDataAdapter(cmd);
            cb = new SqlCommandBuilder(da);
            ds = new DataSet();
            da.FillSchema(ds, SchemaType.Mapped);
            da.Fill(ds, "SalespersionViewOrders");
            dt = ds.Tables["SalespersionViewOrders"];
            conn.Close();
            return dt;
        }

        [WebMethod]
        public DataTable SalespersionViewDeliveringOrders()
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SalespersionViewOrders";

            SqlParameter param = new SqlParameter("@status", SqlDbType.NVarChar);
            param.Size = 15;
            param.Value = "Delivering";
            cmd.Parameters.Add(param);

            da = new SqlDataAdapter(cmd);
            cb = new SqlCommandBuilder(da);
            ds = new DataSet();
            da.FillSchema(ds, SchemaType.Mapped);
            da.Fill(ds, "SalespersionViewDeliveringOrders");
            dt = ds.Tables["SalespersionViewDeliveringOrders"];
            conn.Close();
            return dt;
        }

        [WebMethod]
        public DataTable SalespersionViewOrderDetail(string orderid)
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SalespersionViewOrderDetail";

            SqlParameter param = new SqlParameter("@orderid", SqlDbType.NVarChar);
            param.Size = 20;
            param.Value = orderid;
            cmd.Parameters.Add(param);

            da = new SqlDataAdapter(cmd);
            cb = new SqlCommandBuilder(da);
            ds = new DataSet();
            da.FillSchema(ds, SchemaType.Mapped);
            da.Fill(ds, "SalespersionViewOrderDetail");
            dt = ds.Tables["SalespersionViewOrderDetail"];
            conn.Close();
            return dt;
        }

        [WebMethod]
        public DataTable SalePersonViewReport(int empid, DateTime fromDate, DateTime toDate)
        {
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                conn.Open();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SalePersonViewReport";

                SqlParameter param = new SqlParameter("@empid", SqlDbType.Int);
                param.Value = empid;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@fromdate", SqlDbType.DateTime);
                param.Value = fromDate;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@todate", SqlDbType.DateTime);
                param.Value = toDate;
                cmd.Parameters.Add(param);

                da = new SqlDataAdapter(cmd);
                cb = new SqlCommandBuilder(da);
                ds = new DataSet();
                da.FillSchema(ds, SchemaType.Mapped);
                da.Fill(ds, "SalePersonViewReport");
                dt = ds.Tables["SalePersonViewReport"];
            }
            catch
            {
                //Write Log file                
            }
            finally
            {
                if (cmd != null)
                    cmd.Cancel();
                if (conn != null)
                    conn.Close();
            }
            return dt;
           
        }

        [WebMethod]
        public void SalespersionAcceptOrders(string orderid, int empid)
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SalespersionConfrimOrders";

            SqlParameter param = new SqlParameter("@empid", SqlDbType.Int);
            param.Size = 15;
            param.Value = empid;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@orderid", SqlDbType.NVarChar);
            param.Size = 20;
            param.Value = orderid;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@status", SqlDbType.NVarChar);
            param.Size = 15;
            param.Value = "Delivering";
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
        }

        [WebMethod]
        public void SalespersionDenyOrders(string orderid, int empid)
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SalespersionConfrimOrders";

            SqlParameter param = new SqlParameter("@orderid", SqlDbType.NVarChar);
            param.Size = 20;
            param.Value = orderid;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@status", SqlDbType.NVarChar);
            param.Size = 15;
            param.Value = "Deny";
            cmd.Parameters.Add(param);

            param = new SqlParameter("@empid", SqlDbType.Int);
            param.Size = 15;
            param.Value = empid;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
        }

        [WebMethod]
        public void SalespersionConfrimSuccessOrders(string orderid, int empid)
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SalespersionConfrimOrders";

            SqlParameter param = new SqlParameter("@orderid", SqlDbType.NVarChar);
            param.Size = 20;
            param.Value = orderid;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@status", SqlDbType.NVarChar);
            param.Size = 15;
            param.Value = "Success";
            cmd.Parameters.Add(param);

            param = new SqlParameter("@empid", SqlDbType.Int);
            param.Size = 15;
            param.Value = empid;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
        }

        [WebMethod]
        public void SalespersionConfrimFailOrders(string orderid, int empid)
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SalespersionConfrimOrders";

            SqlParameter param = new SqlParameter("@orderid", SqlDbType.NVarChar);
            param.Size = 20;
            param.Value = orderid;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@status", SqlDbType.NVarChar);
            param.Size = 15;
            param.Value = "Fail";
            cmd.Parameters.Add(param);

            param = new SqlParameter("@empid", SqlDbType.Int);
            param.Size = 15;
            param.Value = empid;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
        }

        [WebMethod]
        public void SalespersonMinusProduct(int productid, int productquantity)
        {
            // After salesperson accept order - product will be minus
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SalespersionMinusProduct";

            SqlParameter param = new SqlParameter("@productid", SqlDbType.Int);
            param.Value = productid;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@productquantity", SqlDbType.Int);
            param.Value = productquantity;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
        }
        
        [WebMethod]
        public void SalespersonAddProduct(int productid, int productquantity)
        {
            // After salesperson confrim order fail - product will be add
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SalespersionAddProduct";

            SqlParameter param = new SqlParameter("@productid", SqlDbType.Int);
            param.Value = productid;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@productquantity", SqlDbType.Int);
            param.Value = productquantity;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
        }

        [WebMethod]
        public List<string> GuestLogin(string username, string password)
        {
            // After salesperson confrim order fail - product will be add
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GuestLogin";

            SqlParameter param = new SqlParameter("@username", SqlDbType.NVarChar,20);
            param.Value = username;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@password", SqlDbType.NVarChar,20);
            param.Value = password;
            cmd.Parameters.Add(param);

            da = new SqlDataAdapter(cmd);
            cb = new SqlCommandBuilder(da);
            ds = new DataSet();
            da.FillSchema(ds, SchemaType.Mapped);
            da.Fill(ds, "GuestLogin");
            dt = ds.Tables["GuestLogin"];
            List<string> info = null;
            if (dt.Rows.Count > 0)
            {
                info = new List<string>();
                info.Add(dt.Rows[0][0].ToString());
                info.Add(dt.Rows[0][1].ToString());
                info.Add(dt.Rows[0][2].ToString());
            }
            return info;
        }
    }
}
