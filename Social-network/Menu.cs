using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social_network
{
    public class Menu
    {
		private Command command = new Command();

		public void showMenu()
		{
			char userInput = 'n';
			bool authRes;
			do
			{
				Console.Clear();
				authRes = doAuthentication();
				if (authRes)
                {
					showMainMenu();
                }
                else
                {
					Console.Write("\nWrong username or password! Want to try again? (y/n): ");
					userInput = Console.ReadLine()[0];
				}
			} while (userInput == 'y');
		}
		private bool doAuthentication()
        {
			Console.Write("Enter username: ");
			string username = Console.ReadLine();
			
			Console.Write("Enter password: ");
			var pass = string.Empty;
			ConsoleKey key;
			do
			{
				var keyInfo = Console.ReadKey(intercept: true);
				key = keyInfo.Key;

				if (key == ConsoleKey.Backspace && pass.Length > 0)
				{
					Console.Write("\b \b");
					pass = pass.Substring(0, pass.Length - 1);
				}
				else if (!char.IsControl(keyInfo.KeyChar))
				{
					Console.Write("*");
					pass += keyInfo.KeyChar;
				}
			} while (key != ConsoleKey.Enter);

			return command.Authtentificate(username, pass);
		}
		private void showMainMenu()
		{

			Console.Clear();

			Console.WriteLine("\nPlease select an option:\n");
			Console.Write("Your choice >> ");

			Console.ReadLine();
		}
		private void handleMainMenuInput(char userInput)
		{
			switch (userInput)
			{
				default:
					Console.WriteLine("Wrong command selected");
					break;
			}
		}
		private void safeHandleMainMenuInput(char userInput)
		{
			try
			{
				handleMainMenuInput(userInput);
			}
			catch (Exception ex)
			{
				// there can be ErrorLogger

				Console.WriteLine($"Error occurs: {ex.Message}");
			}
		}
	}
}
