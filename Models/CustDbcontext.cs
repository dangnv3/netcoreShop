using Microsoft.EntityFrameworkCore;

namespace ImportFile_excel.Models
{
    public class CustDbcontext: DbContext
    {
        public CustDbcontext(DbContextOptions<CustDbcontext> options) : base(options)
        {

        }

        public virtual DbSet<ConvertDate> ConvertDates { get; set; }
    }
}
