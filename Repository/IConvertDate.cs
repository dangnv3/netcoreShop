using System.Data;

namespace ImportFile_excel.Repository
{
    public interface IConvertDate
    {
        string Documentupload(IFormFile formFile);
        DataTable ConvertDataTable(string path);
        void ImportConvert(DataTable Convert);

        DataSet ExportCustomerDataTable();
        DataTable ExportCustomer();

    }
}
