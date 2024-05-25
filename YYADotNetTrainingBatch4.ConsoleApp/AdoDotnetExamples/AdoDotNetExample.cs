namespace YYADotNetCore.ConsoleApp.AdoDotnetExamples;

internal class AdoDotNetExample
{
    private readonly SqlConnectionStringBuilder _connectionStringBuilder = new()
    {
        DataSource = ".",
        InitialCatalog = "DotNetTrainingBatch4",
        UserID = "sa",
        Password = "sa@123"
    };

    public void Read()
    {
        SqlConnection connection = new SqlConnection(_connectionStringBuilder.ConnectionString);
        connection.Open();
        Console.WriteLine("Connection is opened!");

        string query = "select * from Tbl_Blog";
        SqlCommand cmd = new SqlCommand(query, connection);
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sqlDataAdapter.Fill(dt);

        connection.Close();
        Console.WriteLine("Connection is closed!");

        foreach (DataRow dr in dt.Rows)
        {
            Console.WriteLine("Blog Id\t" + dr["BlogId"]);
            Console.WriteLine("BlogTitle\t" + dr["BlogTitle"]);
            Console.WriteLine("BlogAuthor\t" + dr["BlogAuthor"]);
            Console.WriteLine("BlogContent\t" + dr["BlogContent"]);
            Console.WriteLine("============================================");
        }
    }

    public void Create(string title, string author, string content)
    {
        SqlConnection connection = new SqlConnection(_connectionStringBuilder.ConnectionString);
        connection.Open();

        string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle,
           @BlogAuthor,
		   @BlogContent)";

        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@BlogTitle", title);
        cmd.Parameters.AddWithValue("@BlogAuthor", author);
        cmd.Parameters.AddWithValue("@BlogContent", content);
        int result = cmd.ExecuteNonQuery();

        connection.Close();

        string message = result > 0 ? "Saving Successful" : "Saving Failed";
        Console.WriteLine(message);
    }

    public void Update(int id, string title, string author, string content)
    {
        SqlConnection connection = new SqlConnection(_connectionStringBuilder.ConnectionString);
        connection.Open();

        string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId";

        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@BlogId", id);
        cmd.Parameters.AddWithValue("@BlogTitle", title);
        cmd.Parameters.AddWithValue("@BlogAuthor", author);
        cmd.Parameters.AddWithValue("@BlogContent", content);
        int result = cmd.ExecuteNonQuery();

        connection.Close();

        string message = result > 0 ? "Update Successful" : "Update Failed";
        Console.WriteLine(message);
    }

    public void Delete(int id)
    {
        SqlConnection connection = new SqlConnection(_connectionStringBuilder.ConnectionString);
        connection.Open();

        string query = @"DELETE FROM [dbo].[Tbl_Blog]
      WHERE BlogId = @BlogId";

        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@BlogId", id);
        int result = cmd.ExecuteNonQuery();

        connection.Close();

        string message = result > 0 ? "Delete Successful" : "Delete Failed";
        Console.WriteLine(message);
    }

    public void Edit(int id)
    {
        SqlConnection connection = new SqlConnection(_connectionStringBuilder.ConnectionString);
        connection.Open();
        Console.WriteLine("Connection is opened!");

        string query = "select * from Tbl_Blog where BlogId = @BlogId";
        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@BlogId", id);
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sqlDataAdapter.Fill(dt);

        connection.Close();
        Console.WriteLine("Connection is closed!");

        if (dt.Rows.Count == 0)
        {
            Console.WriteLine("No Data Found");
            return;
        }

        DataRow dr = dt.Rows[0];

        Console.WriteLine("Blog Id\t" + dr["BlogId"]);
        Console.WriteLine("BlogTitle\t" + dr["BlogTitle"]);
        Console.WriteLine("BlogAuthor\t" + dr["BlogAuthor"]);
        Console.WriteLine("BlogContent\t" + dr["BlogContent"]);
        Console.WriteLine("============================================");
    }
}
