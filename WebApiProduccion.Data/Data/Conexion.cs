namespace WebApiProduccion.Data.Data
{
    public class Conexion
    {
        public string ConexionString()
        {
            string _CadenaConexion = string.Empty;

            //_CadenaConexion = _configuration.GetConnectionString("DefaultConnectionDev");

            //_CadenaConexion = "Server=INGWILLFREDO\\SQLEXPRESS;Database=DBBookReview;Trusted_Connection=True;TrustServerCertificate=True";
            //_CadenaConexion = "Data Source=INGWILLFREDO\\SQLEXPRESS;Initial Catalog=DBBookReview;User ID=Will;Password=Will0811";
            _CadenaConexion = "workstation id=DBBookReview.mssql.somee.com;packet size=4096;user id=ingwillfredo_SQLLogin_1;pwd=lms5c47513;data source=DBBookReview.mssql.somee.com;persist security info=False;initial catalog=DBBookReview;TrustServerCertificate=True";

            return _CadenaConexion;
        }
     }
}
