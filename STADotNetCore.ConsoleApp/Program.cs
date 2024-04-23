using STADotNetCore.ConsoleApp;
using System.Data;
using System.Data.SqlClient;

//Console.WriteLine("Hello, World!");
//nuget
//sqlConnection
/*
SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder(); // call ado.net
stringBuilder.DataSource = "."; //serverName
stringBuilder.InitialCatalog = "DotNetTrainingBatch4"; //DataBase Name
stringBuilder.UserID = "sa";
stringBuilder.Password = "sa@123";
SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);
//SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=DotNetTrainingBatch4;User ID=sa;Password=sa@123".ConnectionString);


connection.Open();
Console.WriteLine("Connection Open.");

string query = "select * from tbl_blog";
SqlCommand cmd = new SqlCommand(query, connection);
SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
DataTable dt = new DataTable();
sqlDataAdapter.Fill(dt);

connection.Close();
Console.WriteLine("Connection Close.");

// dataset => datatable
// datatable => datarow
// datarow => datacolumn

foreach (DataRow dr in dt.Rows)
{
    Console.WriteLine("Blog Id => " + dr["BlogId"]);
    Console.WriteLine("Blog Title => " + dr["BlogTitle"]);
    Console.WriteLine("Blog Content => " + dr["BlogContent"]);
    Console.WriteLine("------------------------");
}*/

//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
/*adoDotNetExample.Create("title", "author", "content");*/
/*adoDotNetExample.Update(12, "C#", "SiThu", "C#AdoDotNet");*/
//adoDotNetExample.Delete(11);
//adoDotNetExample.Edit(12);

DapperExample dapperExample = new DapperExample();
dapperExample.Run();
Console.ReadKey();
