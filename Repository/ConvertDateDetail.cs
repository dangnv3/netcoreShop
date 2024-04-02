using System.Data.OleDb;
using System.Data;
using Microsoft.Data.SqlClient;

namespace ImportFile_excel.Repository
{
    public class ConvertDateDetail : IConvertDate
    {
        private IConfiguration _configuration;
        private IWebHostEnvironment _environment;

        public ConvertDateDetail(IConfiguration configuration, IWebHostEnvironment environment)
        {
            _configuration = configuration;
            _environment = environment;
        }
        public DataTable ConvertDataTable(string path)
        {
            var constr = _configuration.GetConnectionString("excelconnection");
            DataTable datatable = new DataTable();

            constr = string.Format(constr, path);

            using (OleDbConnection excelconn = new OleDbConnection(constr))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    using (OleDbDataAdapter adapterexcel = new OleDbDataAdapter())
                    {

                        excelconn.Open();
                        cmd.Connection = excelconn;
                        DataTable excelschema;
                        excelschema = excelconn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                        var sheetname = excelschema.Rows[0]["Table_Name"].ToString();
                        excelconn.Close();

                        excelconn.Open();
                        cmd.CommandText = "SELECT * From [" + sheetname + "]";
                        adapterexcel.SelectCommand = cmd;
                        adapterexcel.Fill(datatable);
                        excelconn.Close();

                    }
                }

            }

            return datatable;
        }
        public string Documentupload(IFormFile fromFiles)
        {
            string uploadpath = _environment.WebRootPath;
            string dest_path = Path.Combine(uploadpath, "uploaded_doc");

            if (!Directory.Exists(dest_path))
            {
                Directory.CreateDirectory(dest_path);
            }
            string sourcefile = Path.GetFileName(fromFiles.FileName);
            string path = Path.Combine(dest_path, sourcefile);

            using (FileStream filestream = new FileStream(path, FileMode.Create))
            {
                fromFiles.CopyTo(filestream);
            }
            return path;
        }

        public void ImportConvert(DataTable Convert)
        {

            var sqlconn = _configuration.GetConnectionString("sqlconnection");
            using (SqlConnection scon = new SqlConnection(sqlconn))
            {
                using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(scon))
                {
                    sqlBulkCopy.DestinationTableName = "convertDate";


                    sqlBulkCopy.ColumnMappings.Add("ngaysinh1", "ngaysinh1");
                    sqlBulkCopy.ColumnMappings.Add("ngaysinh2", "ngaysinh2");
                    sqlBulkCopy.ColumnMappings.Add("ngaysinh3", "ngaysinh3");
                    sqlBulkCopy.ColumnMappings.Add("ngaysinh4", "ngaysinh4");
                    sqlBulkCopy.ColumnMappings.Add("ngaysinh5", "ngaysinh5");
                    sqlBulkCopy.ColumnMappings.Add("ngaysinh6", "ngaysinh6");
                    sqlBulkCopy.ColumnMappings.Add("ngaysinh7", "ngaysinh7");
                    sqlBulkCopy.ColumnMappings.Add("ngaysinh8", "ngaysinh8");
                    sqlBulkCopy.ColumnMappings.Add("ngaysinh9", "ngaysinh9");
                    sqlBulkCopy.ColumnMappings.Add("ngaysinh10", "ngaysinh10");
                    sqlBulkCopy.ColumnMappings.Add("ngaysinh11", "ngaysinh11");
                    sqlBulkCopy.ColumnMappings.Add("ngaysinh12", "ngaysinh12");
                    sqlBulkCopy.ColumnMappings.Add("ngaysinh13", "ngaysinh13");
                    sqlBulkCopy.ColumnMappings.Add("ngaysinh14", "ngaysinh14");
                    sqlBulkCopy.ColumnMappings.Add("ngaysinh15", "ngaysinh15");

                    scon.Open();
                    sqlBulkCopy.WriteToServer(Convert);
                    scon.Close();
                }

            }
        }
        public DataTable ExportCustomer()
        {
            DataTable Custdatatable = ExportCustomerDataTable().Tables[0];
            return Custdatatable;

        }
        public DataSet ExportCustomerDataTable()
        {
            DataSet ds = new DataSet();
            var sqlconn = _configuration.GetConnectionString("sqlconnection");

            string getcustomer = "SELECT * FROM ConvertDate";
            using (SqlConnection scon = new SqlConnection(sqlconn))
            {
                using (SqlCommand cmd = new SqlCommand(getcustomer))
                {
                    cmd.Connection = scon;
                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);

                    }
                }
            }
            return ds;
        }
    }
}
