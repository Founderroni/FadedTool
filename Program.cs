using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Memory;
using System.Diagnostics;
using System.Threading;

namespace FadedTool
{
    internal class Program
    {
		private static Process proc;

		public Program()
		{
		}

        static float toolVers = 1.1f;
        private static void Main(string[] args)
        {
			Console.Title = "FadedTool V."+toolVers+" by Founder  -  Kow#1833";
			Console.ForegroundColor = ConsoleColor.DarkMagenta;
			Mem m = new Mem();

			//Variables
			string supportsVersionsList = "1.16.40 | 1.16.100 | 1.16.201 | 1.16.210 | 1.16.221";
			string freeSpace = " ";//Because yes

			string gameVersionSelected;
			string gameVersionAddress = "";
			string chosenWritingMethod = "";

			bool isAuto = false;
			bool isAutoV2 = false;
			bool isManual = false;
			bool customUuid = false;
			string wantedUuid;
			//bool listW = false;

			string writtenSpeed = "";
			int writtenSpeedToInt = 1;


			try
			{
				Program.proc = Process.GetProcessesByName("Minecraft.Windows")[0];
			}
			catch
			{
				Console.WriteLine("Game wasn't found running");
				Console.ReadKey();
				Process.GetCurrentProcess().Kill();
			}
			if (!m.OpenProcess(Program.proc.Id))
			{
				int id = Program.proc.Id;
				Console.WriteLine(string.Concat("Failed to attach to process ", id.ToString("X"), ". \nPossible reasons:\nYou aren't running as administrator\nMinecraft is in out of focused mode"), "Cant attach");
			}
			while (true)
			{
				try
				{


					Console.WriteLine("Welcome To FadedTool V." + toolVers.ToString()+" Created by Founder");
					Console.WriteLine("Supported Minecraft Version: "+ supportsVersionsList);
					
					Thread.Sleep(1000);
					Console.Clear();

					Console.WriteLine(string.Concat("Select Game version:", "\n[1] 1.16.40", "\n[2] 1.16.100", "\n[3] 1.16.201", "\n[4] 1.16.210", "\n[5] 1.16.221"));
					gameVersionSelected = Console.ReadLine();
					Console.WriteLine($"Chosen Version: {gameVersionSelected}");
					if (gameVersionSelected == "1" || gameVersionSelected == "1.16.40")
					{
						gameVersionAddress = "0368EE98,80,0,8,290,0";//1.16.40
					}
					else if (gameVersionSelected == "2" || gameVersionSelected == "1.16.100")
					{
						gameVersionAddress = "03582140,D0,48,80,0,8,290,0";//1.16.100
					}
					else if (gameVersionSelected == "3" || gameVersionSelected == "1.16.201")
					{
						gameVersionAddress = "03A17598,10,80,0,8,290,0";//"03A17590,0,2C0,0"; 1.16.201
					}
					else if (gameVersionSelected == "4" || gameVersionSelected == "1.16.210")
					{
						gameVersionAddress = "037C7170,D0,48,218,50,2F0,0";//1.16.210
					}
					else if (gameVersionSelected == "5" || gameVersionSelected == "1.16.221")
                    {
						gameVersionAddress = "03CCB7A8,10,4D0,8,260,20,2E0,0";//1.16.221
					}
					else
					{
						Console.WriteLine("Please choose an option listed");
					}

					Console.WriteLine("");
					//Console.WriteLine(string.Concat("Select A Writing Method:", "\n[1] Automatic", "\n[2] Manual", "\n[3] Custom", "\n[4] List Weather DIDs"));
					Console.WriteLine(string.Concat("Select A Writing Method:", "\n[1] Automatic", "\n[2] Manual", "\n[3] Custom"));
					Console.WriteLine("");
					chosenWritingMethod = Console.ReadLine();
					Console.WriteLine($"Chosen Option: {chosenWritingMethod}");
					if (chosenWritingMethod == "1" || chosenWritingMethod == "Automatic")
					{
						isAuto = true;
						Console.Clear();
					}
					else if (chosenWritingMethod == "2" || chosenWritingMethod == "Manual")
					{
						isManual = true;
						Console.Clear();
					}
					else if (chosenWritingMethod == "3" || chosenWritingMethod == "Custom")
					{
						customUuid = true;
						Console.Clear();
					}
					else if (chosenWritingMethod == "DeezNutz" || chosenWritingMethod == "Weather")
					{
						Console.WriteLine("Deez Nutz in ur mouth");
						Thread.Sleep(2000);
						Console.Clear();
					}
					else if (chosenWritingMethod == "close" || chosenWritingMethod == "exit")
					{
						Console.Clear();
						Console.WriteLine("Bye bye");
						Thread.Sleep(300);
						Console.WriteLine("Exiting Application...");
						Thread.Sleep(1000);
						Environment.Exit(0);
					}
					else
					{
						Console.Clear();
						Console.Write("Please choose an option listed");
						Thread.Sleep(4000);
					}

                    if (isAuto)
                    {
						Console.Write("Enter write speed: ");
						writtenSpeed = Console.ReadLine();
						if (writtenSpeed == null)writtenSpeedToInt = 1;
						writtenSpeedToInt = Convert.ToInt32(writtenSpeed);
						Console.WriteLine($"Ok, write speed set to {writtenSpeedToInt}");
						Console.WriteLine("");
						isAutoV2 = true;
					}
                    while (isAutoV2)
                    {
						Guid newGuid = Guid.NewGuid();
						string myNewUuid = newGuid.ToString();
						m.WriteMemory("base+" + gameVersionAddress, "string", myNewUuid, "", null, true);
						Console.WriteLine(string.Concat("New DeviceID: ", myNewUuid));
						Thread.Sleep(writtenSpeedToInt);
					}

					while (isManual == true)
					{
						Guid newGuid = Guid.NewGuid();
						string myNewUuid = newGuid.ToString();
						m.WriteMemory("base+" + gameVersionAddress, "string", myNewUuid, "", null, true);
						Console.WriteLine(string.Concat("New DeviceID: ", myNewUuid));
						Console.WriteLine($"Press any key for a new DID");
						Console.ReadKey();
					}

					while (customUuid == true)
					{
						Console.WriteLine(string.Concat("\nType in the UUID you want to use: "));
						wantedUuid = Console.ReadLine();
						m.WriteMemory("base+" + gameVersionAddress, "string", wantedUuid, "", null, true);
						Console.Write("DID set to: " + wantedUuid);
						Console.Write("");
						if (wantedUuid != "close")
							Thread.Sleep(900);
						if (wantedUuid == "close" || wantedUuid == "exit")
						{
							Console.Clear();
							Console.WriteLine("Bye bye");
							Thread.Sleep(300);
							Console.WriteLine("Exiting Application...");
							Thread.Sleep(1000);
							Environment.Exit(0);
						}
					}


				}
				catch
				{
					Console.WriteLine("Something Broke D:");
					Console.ReadKey();
				}
			}
		}
    }
}
