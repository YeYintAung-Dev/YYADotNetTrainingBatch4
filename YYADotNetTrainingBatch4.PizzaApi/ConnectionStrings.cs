using System.Data.SqlClient;

namespace YYADotNetTrainingBatch4.PizzaApi;

public static class ConnectionStrings
{
    public static SqlConnectionStringBuilder SqlConnectionStringBuilder = new SqlConnectionStringBuilder()
    {
        DataSource = ".",
        InitialCatalog = "DotNetTrainingBatch4",
        UserID = "sa",
        Password = "sa@123",
        TrustServerCertificate = true
    };
}
