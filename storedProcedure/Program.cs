// See https://aka.ms/new-console-template for more information
using Microsoft.Data.SqlClient;
using System.Data;

Console.WriteLine("Hello, World!");
var connectionString = "Server=desktop-3d2n79g;Database=MicroBroker;integrated security=true;Encrypt=true; TrustServerCertificate=true;";
//string procedureName = "dbo.PostList";
var Selectrequest = new storedProcedure.Models.StoredProcedure("dbo.GetList", connectionString);
//var Inputrequest= new storedProcedure.Models.StoredProcedure(procedureName,connectionString);
string data = Selectrequest.GetJsonData();

Console.WriteLine($"SqlClient: { typeof(SqlConnection).Assembly.FullName}");

Console.WriteLine(data);

