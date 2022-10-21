using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BattleArenaConsole_v3.Objects.Combatants;
using Display = BattleArenaConsole_v3.DisplayPresentation;


namespace BattleArenaConsole_v3.Objects.Locations
{
	internal class Arena : ILocation
	{

		private Combatant Player { get; set; }

		//this is a list of Combatants for the player to fight, a list<> is one of several types of "collections"
		//the default we're setting it to below is somewhat academic, the list/collection is still empyu
		//if we didn't set it to "new List<>" however, it would still be null which would throw an error when calling "Add"
		private List<Combatant> Challengers { get; set; } = new List<Combatant>();

		public string Name { get; set; } = nameof(Arena);

		public Arena() {
			Display.DisplayText("|###################################|", ConsoleColor.Yellow);
			Display.DisplayText("| You have entered the Battle Arena |", ConsoleColor.Yellow);
			Display.DisplayText("|###################################|", ConsoleColor.Yellow);

			//we don't need the below line because we set it as the default value, otherwise the below "Add" would fail
			//Challengers = new List<Combatant>();
			this.Challengers.Add(new Paladin());
			this.Challengers.Add(new Fighter());
			this.Challengers.Add(new Bard());
			this.Challengers.Add(new Rogue());
		}

		public void Run(Combatant p) {
			this.Player = p;

			//the below is a hack, it is not ideal, we're instantiatin "opponent" and assigning Rogue just to hijack an error
			//left null, "Combatant opponent;" the code wouldn't compile
			Combatant opponent = new Rogue();
			//we'll address this in a later iteration

			Display.Write("The door opens and " + this.Challengers.Count.ToString() + " challengers appear.");
			foreach (Combatant c in this.Challengers) {
				Display.Write(c.CharacterClass.ToString());
			}
			bool running = true;
			//do/while executes the code between the do {} as long as the while (exp)ression returns true
			do
			{
				try
				// try/catch/finally is a method of handling/trapping errors
				{
					string c = getInput();
					MatchCollection cmd = Regex.Matches(c, @"([\w]+|\?)+", RegexOptions.IgnoreCase);
					string cm = cmd[0].Value.Trim();
					string target = (cmd.Count > 1) ? cmd[1].Value.Trim() : "";

					switch (cm)
					{
						case "attack":
							//this cycles through all "Combatants" we added to the "Challengers" list
							//being anle to cycle through like this is one value of orhanizing our code this way
							if (target.Length > 0) {
								foreach (Combatant challenger in Challengers) {
									if (challenger.CharacterClass.ToLower() == target.ToLower()) {
										opponent = challenger; break;  //"break" exits to the loop since we found the Challenger
									}
								}
							}
							this.Player.Attack(opponent);
							if (opponent.Hitpoints < 1)
							{
								Display.DisplayText("Your enemy is dead...", ConsoleColor.DarkRed);
								//we're putting the placeholder for levels/exp points but we'll add logic in a later branch
								Display.DisplayText("You've gained X Experience Points.");

								p.GoldPieces += opponent.GoldPieces;
								Display.DisplayText("You've gained " + opponent.GoldPieces.ToString() + " Gold Pieces.");

								this.Challengers.Remove(opponent);
								//since Player killed the guy. remove him from the list
								if (this.Challengers.Count > 0) {
									Display.Write("You have " + this.Challengers.Count.ToString() + " challengers remaining");
								} else {
									Display.DisplayText("You have defeated all challengers!", ConsoleColor.Yellow);
									Display.Write("You win the trophy and 50 Gold Pieces.");
									this.Player.GoldPieces += 50;
								}
								//we'll add more tournament logic later
							}
							else
							{
								// We'll consider this "end of turn" and the opponent gets to attack now.
								opponent.Attack(this.Player);
								this.Player.EndTurnActions();
								if (this.Player.Hitpoints < 1)
								{
									Display.DisplayText("You are dead.", ConsoleColor.DarkRed);
									break;
								}
								Display.DisplayText("You have " + this.Player.Hitpoints + " hitpoints left.", ConsoleColor.DarkBlue);
								Display.DisplayText("Your opponent has " + opponent.Hitpoints + " hitpoints left.", ConsoleColor.DarkBlue);
							}
							break;
						case "exit":
							running = false;
							Display.DisplayText("You have left the " + this.Name + ".");
							break;
						case "?":
							Display.DisplayText("The following commands are available:");
							Display.DisplayText("attack [ target ]");
							Display.DisplayText("exit");
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
