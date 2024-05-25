//SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
//stringBuilder.DataSource = ".";
//stringBuilder.InitialCatalog = "DotNetTrainingBatch4";
//stringBuilder.UserID = "sa";
//stringBuilder.Password = "sa@123";

//SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);
//connection.Open();
//Console.WriteLine("Connection is opened!");

//string query = "select * from Tbl_Blog";
//SqlCommand cmd = new SqlCommand(query, connection);
//SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
//DataTable dt = new DataTable();
//sqlDataAdapter.Fill(dt);

//connection.Close();
//Console.WriteLine("Connection is closed!");

//foreach (DataRow dr in dt.Rows)
//{
//    Console.WriteLine("BlogTitle", dr["BlogTitle"]);
//    Console.WriteLine("BlogAuthor", dr["BlogAuthor"]);
//    Console.WriteLine("BlogContent", dr["BlogContent"]);
//    Console.WriteLine("============================================");
//}

using YYADotNetCore.ConsoleApp.AdoDotnetExamples;

AdoDotNetExample adoDotNetExample = new();
adoDotNetExample.Read();
//adoDotNetExample.Create("CREATE", "Author1", "Create Content");
//adoDotNetExample.Read();
//adoDotNetExample.Update(9, "Update Blog", "Update Author", "Update Content");
//adoDotNetExample.Delete(9);
//adoDotNetExample.Edit(8);
//adoDotNetExample.Read();


//DapperExample dapperExample = new DapperExample();
//dapperExample.Run();


#region EFCoreExample
//EFCoreExample eFCoreExample = new();
//eFCoreExample.Run();

#endregion

Console.ReadKey();
