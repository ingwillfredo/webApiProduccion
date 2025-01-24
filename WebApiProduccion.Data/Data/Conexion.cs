namespace WebApiProduccion.Data.Data
{
    public class Conexion
    {
        public string ConexionString()
        {
            string _CadenaConexion = string.Empty;

            _CadenaConexion = "Server=INGWILLFREDO\\SQLEXPRESS;Database=DBBookReview;Trusted_Connection=True;TrustServerCertificate=True";
            //_CadenaConexion = "Data Source=INGWILLFREDO\\SQLEXPRESS;Initial Catalog=DBBookReview;User ID=Will;Password=Will0811";
            //_CadenaConexion = "workstation id=DB_Recargas.mssql.somee.com;packet size=4096;user id=wimafra_SQLLogin_1;pwd=jf72mjkrek;data source=DB_Recargas.mssql.somee.com;persist security info=False;initial catalog=DB_Recargas;TrustServerCertificate=True";

            return _CadenaConexion;
        }
     }
}
