using System;

namespace BuyAndSell;

public class Get
{
	public static void ColorYellow(string message)
	{
		Console.Write(message, Console.ForegroundColor = ConsoleColor.Yellow);
		Console.ResetColor();
	}
	public static void ColorCyan(string message)
	{
		Console.WriteLine(message, Console.ForegroundColor = ConsoleColor.Cyan);
		Console.ResetColor();
	}

	public static void ColorRed(string message)
	{
		Console.WriteLine(message, Console.ForegroundColor = ConsoleColor.Red);
		Console.ResetColor();
	}

	public static void ColorGreen(string message)
	{
		Console.Clear();
		Console.WriteLine(message, Console.ForegroundColor = ConsoleColor.Green);
		Console.ResetColor();
	}

	public static string Pin(string message)
	{
		bool Correct = false;
		while (!Correct)
		{
			string pin = Input(message);
			if (int.TryParse(pin, out int num) && pin.Length == 4)
			{
				Correct = true;
				return Convert.ToString(num);
			}
			else
			{
				ColorRed("Wrong Input!");
				Correct = false;
			}
		}
		return "Error";
	}

	public static string Input(string message)
	{
		Console.WriteLine(message);
		Console.Write("Enter: ");
		string text = Console.ReadLine();

		return text;
	}


	public static void Loading()
	{
		while (true)
		{


			Console.Write("Loading");		
			for (int i = 0; i < 5; i++)
			{
				Console.Write(".", Console.ForegroundColor = ConsoleColor.Green);
				System.Threading.Thread.Sleep(400);
			}
			Console.ResetColor();
			break;
		}
	}

}