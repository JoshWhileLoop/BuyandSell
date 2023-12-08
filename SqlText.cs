
/*

// Package needed---------------------------------------------------------
using Microsoft.Data.Sqlite;

// Name of Data in SQLite-------------------------------------------------
static string connectionString = @"Data Source=Data_Name.db";

// Creating Table---------------------------------------------------------
using (var connection = new SqliteConnection(connectionString))
{
	connection.Open();
	var tableCmd = connection.CreateCommand();
	tableCmd.CommandText =
		@"CREATE TABLE IF NOT EXISTS Data_Name (
		Column_NAME1 INTEGER PRIMARY KEY AUTOINCREMENT,
		Column_NAME2 TEXT,
		Column_NAME3 INTEGER
		)";
	tableCmd.ExecuteNonQuery();
	connection.Close();
}

// View Data -------------------------------------------------------------
public class infoView
{
	public int Id { get; set; }
	public DateTime Date { get; set; }
	public int Quantity { get; set; }
}
using (var connection = new SqliteConnection(connectionString))
{
	connection.Open();
	var tableCmd = connection.CreateCommand();
	tableCmd.CommandText = $"SELECT * FROM Data_Name";

	List<infoView> tableData = new();

	SqliteDataReader reader = tableCmd.ExecuteReader();

	if (reader.HasRows)
	{
		while (reader.Read())
		{
			tableData.Add(
			new infoView
			{
				Id = reader.GetInt32(0),
				Date = DateTime.ParseExact(reader.GetString(1), "dd-mm-yy", new CultureInfo("en-PH")),
				Quantity = reader.GetInt32(2)
			});

		}
	}
	else
	{
		Console.WriteLine("\nNo Data");
	}
	Console.WriteLine("\n_____________________________\n");
	foreach (var i in tableData)
	{
		Console.WriteLine($"ID: {i.Column_NAME1} Date: {i.Column_NAME2.ToString("dd-mm-yy")} Quantity: {i.Column_NAME3}");
	}
	Console.WriteLine("\n_____________________________");
}

// Delete Data------------------------------------------------------------
var INPUT_NAME1 = GetNumberInput("\nType ID to delete");
using (var connection = new SqliteConnection(connectionString))
{
	connection.Open();
	var tableCmd = connection.CreateCommand();

	tableCmd.CommandText = $"DELETE from Data_Name WHERE Column_NAME1 = '{INPUT_NAME1}'";

	int rowC = tableCmd.ExecuteNonQuery();
	if (rowC == 0)
	{
		Console.WriteLine($"\nNo {INPUT} in Data");
		deleteData();
	}
	connection.Close();
	Console.WriteLine($"ID {INPUT} Deleted");
}

// Add Data----------------------------------------------------------------
string INPUT_NAME2 = GetNumberInput("Comment");
int INPUT_NAME3 = GetNumberInput("Comment");
using (var connection = new SqliteConnection(connectionString))
	{
		connection.Open();
		var tableCmd = connection.CreateCommand();

		tableCmd.CommandText = $"INSERT INTO people(Column_NAME2, Column_NAME3) VALUES('{INPUT_NAME2}', {INPUT_NAME3})";

		tableCmd.ExecuteNonQuery();
		connection.Close();	
	}

// Update Data--------------------------------------------------------------	
var INPUT_NAME1 = GetNumberInput("\nType ID to Update");
using (var connection = new SqliteConnection(connectionString))
	{
		connection.Open();
		var checkCmd = connection.CreateCommand();
		checkCmd.CommandText = $"SELECT EXISTS(SELECT 1 FROM Data_Name WHERE Column_NAME1 = {Column_INPUT1})";
		int checkQuery = Convert.ToInt32(checkCmd.ExecuteScalar());
			
		if (checkQuery == 0)
		{
				Console.WriteLine($"No {Column_INPUT1} in Data!");
				connection.Close();
				updateData();
		}
			
			string Column_INPUT2 = GetDateInput();
			
			int Column_INPUT3 = GetNumberInput("\nEnter number of glasses");
			
			var tableCmd = connection.CreateCommand();
			tableCmd.CommandText = $"UPDATE Data_Name SET Column_NAME2 = '{Column_INPUT2}', Column_NAME3 = {Column_NAME3} WHERE Column_NAME1 = {Column_INPUT1}";
			
			tableCmd.ExecuteNonQuery();
			
			connection.Close();
	}

//Search DATA----------------------------------------------------------------
using (var connection = new SqliteConnection(connectionString))
	{
			string language = "C++";
			connection.Open();
			var tableCmd = connection.CreateCommand();
			tableCmd.CommandText = $"SELECT * FROM Programmer WHERE LANGUAGE = '{language}' LIMIT 1";
			SqliteDataReader reader = tableCmd.ExecuteReader();

			int age = new();
			string lang = new();
			
			if (reader.Read())
			{
				int i = reader.GetInt32(0);
				lang = reader.GetString(1);
				age = reader.GetInt32(2);				
				Console.WriteLine($"\nID: {i} Language: {lang} Age: {age}");
			}
	}
// If Add is same Catch Uniqueness---------------------------------------------	
try
{
	tableCmd.ExecuteNonQuery();
	connection.Close();
}
catch (SqliteException e)
{
	Console.WriteLine(e.SqliteErrorCode);
	if (e.SqliteErrorCode == 19)
	{
		Console.WriteLine("Error 19");
	}
	else{
		Console.WriteLine("No");
	}				
}

// View Data using Console Data.................................................

	public class TableColumn
	{
		public int Id { get; set; }
		public string Fullname { get; set; }
		public string Balance { get; set; }
	}

	public static DataTable CostumerData()
	{
		using (var connection = new SqliteConnection(connectionString))
		{
			connection.Open();
			var tableCmd = connection.CreateCommand();
			tableCmd.CommandText = $"SELECT * FROM CostumerRecords";

			List<TableColumn> tableData = new();

			SqliteDataReader reader = tableCmd.ExecuteReader();

			if (reader.HasRows)
			{
				while (reader.Read())
				{
					tableData.Add(
					new TableColumn
					{
						Id = reader.GetInt32(0),
						Fullname = reader.GetString(1),
						Balance = Convert.ToString("₱" + reader.GetInt32(4)),
					});

				}
			}
			else
			{
				Console.WriteLine("\nNo Data");
			}


			var Table = new DataTable();
			Table.Columns.Add("ID", typeof(int));
			Table.Columns.Add("  FULL NAME", typeof(string));
			Table.Columns.Add("BALANCE", typeof(string));



			foreach (var i in tableData)
			{

				Table.Rows.Add(i.Id, i.Fullname, i.Balance);
			}
			return Table;
		}

	}


	public static void ViewDataTable()
	{
		var data = CostumerData();

		string[] ColumnName = data.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();

		DataRow[] row = data.Select();

		var table = new ConsoleTable(ColumnName);

		foreach (DataRow n in row)
		{
			table.AddRow(n.ItemArray);
		}


		table.Write(Format.Default);

	}

	
*/
