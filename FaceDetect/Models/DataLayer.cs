using System.Data.SqlClient;

namespace FaceDetect.Models
{
    public class DataLayer
    {
        public SqlConnection con;
        public string constr { get; set; }
        public IConfiguration configuration { get; set; }
        public DataLayer(IConfiguration _configuration) {
        configuration= _configuration;
            constr = _configuration.GetConnectionString("DBConn");
        }
        public void s()
        {


        }

    }
}
