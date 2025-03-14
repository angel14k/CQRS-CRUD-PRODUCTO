using Microsoft.Data.SqlClient;

namespace CQRSCrud.Context
{
    public class ConexionDB
    {
        private readonly IConfiguration _config;
        private readonly string _sqlString;
        public ConexionDB(IConfiguration config)
        {
            _config = config;
            _sqlString = _config.GetConnectionString("SqlString");
        }

        public SqlConnection ObtenerSql()
        {
            return new SqlConnection(_sqlString);
        }


    }
}
