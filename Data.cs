using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using ConsoleTables;
using System.Data;

namespace BuyAndSell;

public class Data
{
	public static string connectionString = @"Data Source = DataBase.db";

	public static void CreateCostumerMain()
	{
		using (var connection = new SqliteConnection(connectionString))
		{
			connection.Open();
			var tableCmd = connection.CreateCommand();
			tableCmd.CommandText =
				@"CREATE TABLE IF NOT EXISTS CostumerMain (
				ID INTEGER PRIMARY KEY AUTOINCREMENT,
				FNAME TEXT,
				USERNAME TEXT UNIQUE,
				PIN INTEGER UNIQUE,
				BALANCE INTEGER
				)";

			tableCmd.ExecuteNonQuery();
			connection.Close();
		}
	}

	public static void CreateProducts()
	{
		using (var connection = new SqliteConnection(connectionString))
		{
			connection.Open();
			var tableCmd = connection.CreateCommand();
			tableCmd.CommandText =
				@"CREATE TABLE IF NOT EXISTS Products (
				ID INTEGER,
				PRODUCTS TEXT UNIQUE,
				PRICE INTEGER
				)";

			tableCmd.ExecuteNonQuery();
			connection.Close();
		}
	}


	public static void CreateLogin()
	{
		using (var connection = new SqliteConnection(connectionString))
		{
			connection.Open();
			var tableCmd = connection.CreateCommand();
			tableCmd.CommandText =
				@"CREATE TABLE IF NOT EXISTS Login (
				ID INTEGER PRIMARY KEY,
				FNAME TEXT,
				LOGIN TEXT
				)";

			tableCmd.ExecuteNonQuery();
			connection.Close();
		}
	}

	// Register Account ................
	public static void Registered()
	{
		string Fname = Get.Input("Enter Full Name (First name Last name)");
		string Uname = Get.Input("Enter Username");
		int pin = int.Parse(Get.Pin("Enter PIN (4-digit only)"));
		int balance = int.Parse(Get.Input("Enter Money Deposit"));

		// {Fname} {Uname} {pin} {balance}


		using (var connection = new SqliteConnection(connectionString))
		{
			connection.Open();
			var tableCmd = connection.CreateCommand();

			tableCmd.CommandText = $"INSERT INTO CostumerMain (FNAME, USERNAME, PIN, BALANCE) VALUES('{Fname}', '{Uname}', {pin}, {balance})";

			tableCmd.ExecuteNonQuery();
			connection.Close();
		}

	}

	// Checking if theirs is a acc exist ..........
	public static string OpenAcc()
	{
		using (var connection = new SqliteConnection(connectionString))
		{
			connection.Open();
			var tableCmd = connection.CreateCommand();
			tableCmd.CommandText = $"SELECT * FROM Login";


			SqliteDataReader reader = tableCmd.ExecuteReader();

			if (reader.HasRows)
			{
				if (reader.Read())
				{
					User = reader.GetString(1);
					connection.Close();
					return User;
				}
			}

			return "No";
		}
	}

	// Value .........
	public static int Id { get; set; }
	public static string Fname { get; set; }
	public static string User { get; set; }
	public static int Pincode { get; set; }
	public static int Balance { get; set; }

	// Find Name in Main Data and return .......
	public static string Name()
	{
		string Uname = OpenAcc();

		// {Fname} {Uname} {pin} {balance}
		using (var connection = new SqliteConnection(connectionString))
		{
			connection.Open();
			var tableCmd = connection.CreateCommand();
			tableCmd.CommandText = $"SELECT * FROM CostumerMain WHERE USERNAME = '{Uname}' LIMIT 1";
			SqliteDataReader reader = tableCmd.ExecuteReader();

			if (reader.Read())
			{
				Id = reader.GetInt32(0);
				Fname = reader.GetString(1);
				Balance = reader.GetInt32(4);

			}
			connection.Close();
		}

		string name = Fname;
		return name;

	}

	// Delete Account in Login DataTable
	public static void LogoutAcc()
	{
		string Uname = OpenAcc();
		using (var connection = new SqliteConnection(connectionString))
		{
			connection.Open();
			var tableCmd = connection.CreateCommand();
			tableCmd.CommandText = $"DELETE from Login WHERE FNAME = '{Uname}'";
			int rowC = tableCmd.ExecuteNonQuery();
			connection.Close();
		}
	}

	// Login account insert account in local(Login) 
	public static void Login()
	{
		string Uname = Get.Input("Enter Username");
		int pin = int.Parse(Get.Pin("Enter PIN (4-digit only)"));

		// {Fname} {Uname} {pin} {balance}
		using (var connection = new SqliteConnection(connectionString))
		{
			connection.Open();
			var tableCmd = connection.CreateCommand();
			tableCmd.CommandText = $"SELECT * FROM CostumerMain WHERE USERNAME = '{Uname}' LIMIT 1";
			SqliteDataReader reader = tableCmd.ExecuteReader();

			if (reader.Read())
			{
				Id = reader.GetInt32(0);
				User = reader.GetString(2);
				Pincode = reader.GetInt32(3);
			}

			if (Uname == User && pin == Pincode)
			{
				var tableAdd = connection.CreateCommand();
				tableAdd.CommandText = $"INSERT INTO Login (ID, FNAME, LOGIN) VALUES({Id}, '{User}', 'true')";

				tableAdd.ExecuteNonQuery();
				connection.Close();
			}
		}

		if (Uname == User && pin == Pincode)
		{

			Shop.Shoping();
		}
	}
}

public class Product : Data
{
	
	// For Buying Product ...........
	public static int Iproduct { get; set; }
	public static string Nproduct { get; set; }
	public static int Pproduct { get; set; }
	// For View List[] .............	
	public string Pname { get; set; }
	public string Price { get; set; }
	// For The Owner Logins ..............
	public static string Owner { get; set; }
	public static int OwnerMoney { get; set; }

	public static string ProductOwner()
	{
		int Uname = Iproduct;
		using (var connection = new SqliteConnection(connectionString))
		{
			connection.Open();
			var tableCmd = connection.CreateCommand();
			tableCmd.CommandText = $"SELECT * FROM CostumerMain WHERE ID = {Uname} LIMIT 1";
			SqliteDataReader reader = tableCmd.ExecuteReader();

			if (reader.Read())
			{
				Owner = reader.GetString(1);
				OwnerMoney = reader.GetInt32(4);
			}
			connection.Close();
		}

		return Owner;

	}

	// Product Id.......
	public static int GetId()
	{
		int Uname = Iproduct;
		using (var connection = new SqliteConnection(connectionString))
		{
			connection.Open();
			var tableCmd = connection.CreateCommand();
			tableCmd.CommandText = $"SELECT * FROM CostumerMain WHERE ID = {Uname} LIMIT 1";
			SqliteDataReader reader = tableCmd.ExecuteReader();

			if (reader.Read())
			{
				Id = reader.GetInt32(0);
				Fname = reader.GetString(1);
				return Id;
			}
			connection.Close();
		}

		return Id;
	}

	// Sell Product ...........
	public static void SellProduct()
	{
		string ProductName = Get.Input("\nEnter Product Name");
		int ProductPrice = int.Parse(Get.Input("\nEnter Price"));
		int Id = GetId();

		using (var connection = new SqliteConnection(connectionString))
		{
			if (Id == 0)
			{
				Get.ColorRed($"Product ID is {Id}");
			}
			else
			{
				connection.Open();
				var tableCmd = connection.CreateCommand();
				tableCmd.CommandText = $"INSERT INTO Products (ID, PRODUCTS, PRICE) VALUES({Id}, '{ProductName}', {ProductPrice})";
				tableCmd.ExecuteNonQuery();
				connection.Close();
			}
		}
	}

	// Search Product ......
	public static string Search(string inputName)
	{
		string ProductName = inputName;
		using (var connection = new SqliteConnection(connectionString))
		{
			connection.Open();
			var tableCmd = connection.CreateCommand();
			tableCmd.CommandText = $"SELECT * FROM Products WHERE PRODUCTS = '{ProductName}' LIMIT 1";
			SqliteDataReader reader = tableCmd.ExecuteReader();

			if (reader.Read())
			{
				string name = Convert.ToString(1);
				connection.Close();
				return ProductName;
			}
		}
		return "No";
	}

	// Get Product ......
	public static void GetProductData()
	{
		using (var connection = new SqliteConnection(connectionString))
		{
			connection.Open();
			var tableCmd = connection.CreateCommand();
			tableCmd.CommandText = $"SELECT * FROM Products WHERE PRODUCTS = '{Nproduct}' LIMIT 1";
			SqliteDataReader reader = tableCmd.ExecuteReader();

			if (reader.Read())
			{
				Iproduct = reader.GetInt32(0);
				Pproduct = reader.GetInt32(2);
				connection.Close();
			}
		}
	}

	// Product viewing ....
	public static void BuyProduct()
	{
		bool FindProduct = false;
		while (!FindProduct)
		{
			string inputN = Get.Input("Enter Product or E to EXIT Application");
			
			string result = Search(inputN);
			if (inputN == "e")
			{
				Get.ColorGreen("Exit Application");
				Shop.Shoping();
				FindProduct = true;
				break;
			}
			if (result != "No")
			{
				Nproduct = result;
				GetProductData();
				ProductOwner();
				Console.Write("\nID: "); Get.ColorYellow(Convert.ToString(Iproduct)); Console.Write("\nProduct: "); Get.ColorYellow(Nproduct); Console.Write("\nPrice: "); Get.ColorYellow(Convert.ToString(Pproduct)); Console.Write("\nOwner: "); Get.ColorYellow(Owner);
				BuyNow();
				FindProduct = true;
				break;
			}
			else
			{
				Console.Write("No Product Named: "); Get.ColorRed(inputN);
				FindProduct = false;
				
			}

		}

	}

	// Buy Product .........
	public static void BuyNow()
	{
		bool follow = false;
		while (!follow)
		{
			string buy = Get.Input("\n\nEnter (b) to buy or Enter any to quit:");

			if (buy == "b")
			{
				if (Pproduct > Balance)
				{
					Console.WriteLine($"Your Balance is {OwnerMoney} not enought to Purchase Product {Nproduct}");
					Get.Loading();
					Shop.BuyProduct();
					follow = false;
					break;
				}
				if (Id == Iproduct)
				{
					
					Console.WriteLine($"Your Cannot buy your Product...");
					Get.Loading();
					Shop.BuyProduct();
					follow = false;
					break;
				}
				else
				{
					Purchase(); DeleteProduct(); AmountUpdate();
					Get.Loading();
					Shop.BuyProduct();
					follow = true;
					break;
				}

			}

			else
			{
				follow = true;
				Console.Clear();
				Get.Loading();
				Shop.Shoping();
				break;
			}

		}

	}

	// Owner Balance Update .....
	public static void Purchase()
	{
		using (var connection = new SqliteConnection(connectionString))
		{
			int newBal = OwnerMoney + Pproduct;
			connection.Open();
			var tableCmd = connection.CreateCommand();
			tableCmd.CommandText = $"UPDATE CostumerMain SET BALANCE = {newBal} WHERE Id = {Iproduct}";
			tableCmd.ExecuteNonQuery();
			connection.Close();
		}
		Console.WriteLine("Succesfully Purchase....");
	}

	// Buyer Balance Update ......
	public static void AmountUpdate()
	{
		using (var connection = new SqliteConnection(connectionString))
		{
			int newBal = Balance - Pproduct;
			connection.Open();
			var tableCmd = connection.CreateCommand();
			tableCmd.CommandText = $"UPDATE CostumerMain SET BALANCE = {newBal} WHERE Id = {Id}";
			tableCmd.ExecuteNonQuery();
			connection.Close();
		}
		Console.WriteLine("Your Balance Deducted....");
	}

	// Product Delete ......
	public static void DeleteProduct()
	{
		using (var connection = new SqliteConnection(connectionString))
		{
			connection.Open();
			var tableCmd = connection.CreateCommand();
			tableCmd.CommandText = $"DELETE from Products WHERE PRODUCTS = '{Nproduct}'";
			tableCmd.ExecuteNonQuery();
			connection.Close();
		}
		Console.WriteLine("Product Deleted.....");
	}

	//Product Data View .......
	public static void ViewProduct()
	{
		var data = ProductAvailable();

		string[] ColumnName = data.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();

		DataRow[] row = data.Select();

		var table = new ConsoleTable(ColumnName);

		foreach (DataRow n in row)
		{
			table.AddRow(n.ItemArray);
		}

		Console.WriteLine();
		table.Write(Format.MarkDown);

	}

	public static DataTable ProductAvailable()
	{
		using (var connection = new SqliteConnection(connectionString))
		{
			connection.Open();
			var tableCmd = connection.CreateCommand();
			tableCmd.CommandText = $"SELECT * FROM Products";

			List<Product> tableData = new();

			SqliteDataReader reader = tableCmd.ExecuteReader();

			if (reader.HasRows)
			{
				while (reader.Read())
				{
					tableData.Add(
					new Product
					{
						Pname = reader.GetString(1),
						Price = Convert.ToString(reader.GetInt32(2))
					});

				}
			}
			else
			{
				Console.WriteLine("\nNo Data");
			}


			var Table = new DataTable();
			Table.Columns.Add("      PRODUCTS", typeof(string));
			Table.Columns.Add("      PRICE", typeof(string));



			foreach (var i in tableData)
			{

				Table.Rows.Add($"      {i.Pname}     ", $"      Php {i.Price}     ");
			}
			return Table;
		}

	}

}