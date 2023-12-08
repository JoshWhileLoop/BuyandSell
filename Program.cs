using System;
using System.Linq;
using CSharpShellCore;
using BuyAndSell;
using Microsoft.Data.Sqlite;

namespace BuyAndSell;

public class Program
{
	public void Main()
	{		
		Exist.Acc();
		//Shop.Shoping();
		//Costumer.Logins();
		//Data.CreateLogin();
		
	}
}

public class Exist
{
	public static void Acc()
	{
		string costumers = Data.OpenAcc();
		//Console.WriteLine(costumers);
		if (costumers != "No")
		{
			Shop.Shoping();
		}
		else{	
			Costumer.Logins();
		}
	}
}

public class Shop
{
	public static void Shoping()
	{
		string name = Data.Name();
		//int bal = Data.Balance();
		Console.Clear();
		Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t_________________________________");
		Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\tB == BUY PRODUCT");
		Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\tS == SELL PRODUCT");
		Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\tE == EXIT APPLICATION");
		Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\tL == LOGOUT");
		Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t_________________________________");
		Get.ColorCyan("\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t == SHOPPING ==");		
		Get.ColorCyan($"\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t== {name} ==");
		
		bool login = true;
		while (login)
		{
			string c = Get.Input("\nWhat do want?");

			switch (c)
			{
				case "b":
					login = false;
					BuyProduct();
					break;	
				case "s":
					login = false;
					SellProduct();
					break;	
				case "l":
					login = false;
					Data.LogoutAcc();
					Costumer.Logins();
					break;
				case "e":
					Get.ColorGreen("EXIT Application....");
					login = false;
					break;
				default:
					Get.ColorRed("Wrong Input!");
					break;
			}
		}
	}
	public static void BuyProduct()
	{
		Console.Clear();
		Get.ColorCyan("\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t == BUY PRODUCT ==");
		Product.ViewProduct();
		Product.BuyProduct();
	}
	
	public static void SellProduct()
	{
		Console.Clear();
		Get.ColorCyan("\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t == SELL PRODUCT ==");
		Product.SellProduct();
		Get.ColorGreen("\nYour Product is Set...");
		Get.Loading();
		Shop.Shoping();
	}

}

public class Costumer
{
	public static void Logins()
	{
		Console.Clear();
		Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t_________________________________");
		Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\tL == LOGIN");
		Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\tR == REGISTER");
		Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\tE == EXIT APPLICATION");
		Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t_________________________________");

		bool login = true;
		while (login)
		{
			string c = Get.Input("\nWhat do want?");

			switch (c)
			{
				case "l":
					login = false;
					Console.Clear();
					Login();
					break;
				case "r":
					login = false;
					Register();
					break;
				case "e":
					login = false;
					Get.ColorGreen("EXIT Application!");
					break;
				default:
					Get.ColorRed("Wrong Input!");
					break;
			}
		}

	}

	public static void Login()
	{
		Get.ColorCyan("\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t == LOGIN ==");
		Data.Login();
	}
	public static void Register()
	{
		Get.ColorCyan("\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t == REGISTER ==");
		Data.Registered();
		Logins();
	}
}