using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Display = BattleArenaConsole_v3.DisplayPresentation;

namespace BattleArenaConsole_v3.Objects.Locations
{
	internal class TownSquare : ILocation
	{
		public string Name { get; set; } = nameof(TownSquare);

		public TownSquare() {
			Display.Write("|##########################################|");
			Display.Write("| ###     Welcome to Town Square      #### |");
			Display.Write("|##########################################|");

		}
		public TownSquare(string name) : this()  //this calls the above parameterless constructor first
		{
			this.Name = name;
			Display.Write("You are in the Town Square of " + this.Name);
		}

		public void Run(Combatants.Combatant player) {
			//we're now doing something similar in the combatant class, we'll address this along with other UI concerns
			Display.Write("Welcome " + player.PlayerName + " the " + player.CharacterClass + ", Level:" + player.Level.ToString() + " (xp:" + player.ExperiencePoints.ToString() + "/" + (player.XPtoLevelNeeded * player.Level).ToString() + ")");
			Display.Write("You have " + player.GoldPieces.ToString() + " Gold Pieces.");

			bool running = true;
			//do/while executes the code between the do {} as long as the while (exp)ression returns true
			do
			{
				try
				// try/catch/finally is a method of handling/trapping errors
				{
					//don't worry about understanding how regex works yet, just understand we're parsing user input for words
					//principally for the first and seconf words, the "command" and "target"
					string c = getInput();
					MatchCollection cmd = Regex.Matches(c, @"([\w]+|\?)+", RegexOptions.IgnoreCase);
					string command = cmd[0].Value.Trim();
					string target = (cmd.Count > 1) ? cmd[1].Value.Trim() : "";

					switch (command)
					{
						case "inventory":
							player.ListInventory();
							break;
						case "arm":
							//later, we'll add in handling around trying to arm > 2 hands (based on combatant's # of hands
							player.Arm(target);
							break;
						case "stats":
							player.ShowCharacterStats();
							break;
						case "goto":
							try
							{
								// "target" is the second word captured, we're looking to see if a Location class exists with that name
								// if it does we're invoking the "Run" method on it. We've required all classes derived from "ILocation" to implmenet that method
								//.Where(i => ...) this is lambda, it says only return Types that containt "locations" ie, what's in that namespace
								// we'll explore much more lamda layer but it's a way to filter/query in a fairly simple way
								foreach (Type t in Assembly.GetExecutingAssembly().GetTypes().Where(i => i.FullName.ToLower().Contains("locations.")))
								{
									if (t.Name.ToLower() == target)
									{
										//"dynamic" allows us to invoke an unknown object by it's string name
										//as is, the Ilocation interface requires there to be a "Run" method, otherwise this might fail
										dynamic myObject = Activator.CreateInstance(t);
										myObject.Run(player);
									}
								}
								//we'll build this out more soon and make it a little more elegant and foolproof
							}
							catch (Exception e)
							{
								Display.DisplayText("ERROR: " + e.Message.ToString());
							}
							break;
						case "?":
							Display.DisplayText("The following commands are available:");
							Display.DisplayText("arm [ weapon ]");
							Display.DisplayText("goto [ arena | store ]");
							Display.DisplayText("inventory");
							Display.DisplayText("quit");
							break;
						case "quit":
							running = false; // this causes the while(running) condition to return false, stopping the loop
							break;
					}
				}
				catch (OverflowException e)
				{
					Display.DisplayText("Something went wrong." + e.Message.ToString(), ConsoleColor.Red);
				}
			} while (running);
		}

	}
}
