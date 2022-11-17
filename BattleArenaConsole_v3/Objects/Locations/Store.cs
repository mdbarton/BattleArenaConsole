using BattleArenaConsole_v3.Objects.Items;
using BattleArenaConsole_v3.Objects.Items.Shields;
using BattleArenaConsole_v3.Objects.Items.Weapons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Display = BattleArenaConsole_v3.DisplayPresentation;


namespace BattleArenaConsole_v3.Objects.Locations
{
	internal class Store : ILocation
	{
		public string Name { get; set; } = nameof(Store);

		private List<Items.IItem> Wares { get; set; } = new List<IItem>();

		public Store() {
			Display.Write("|##########################################|");
			Display.Write("| You have entered Bob's Discount Weaponry |");
			Display.Write("|##########################################|");
			this.Wares.Add(new ShortSword());
			this.Wares.Add(new BroadSword());
			this.Wares.Add(new BattleAxe());
			this.Wares.Add(new SmallShield());
			this.Wares.Add(new BarrellLid());
		}

		public void ListWares() {
			Display.DisplayText("LOOK AT MY MANY WEAPONS!!!", ConsoleColor.Green);
			foreach (Weapon item in Wares.Where(t => t.GetType().IsSubclassOf(typeof(Weapon))))
			{
				Display.Write("I have a " + item.Name + "(" + item.DamageRoll + ") on sale for " + item.Cost.ToString() + " Gold Pieces.");
			}
			Display.DisplayText("LOOK AT MY SHIELDS!", ConsoleColor.Green);
			// We changed "Shield" from an abstract class to an interface to show the differences
			//above "IsSubClassOf shows a class derived from another, here we invoke "GetInterfaces" for the class and make sure it contains IShield
			foreach (IShield item in Wares.Where(t => t.GetType().GetInterfaces().Contains(typeof(IShield))))
			{
				Display.Write("I have a " + item.Name + "(" + item.DefenseModifier + ") on sale for " + item.Cost.ToString() + " Gold Pieces.");
			}
		}

		public void Buy(string itemName, Combatants.Combatant player) {

			IItem foundItem = this.findItem(itemName, this.Wares);
			if (foundItem != null && player.GoldPieces >= foundItem.Cost) {
				player.GoldPieces -= foundItem.Cost;
				Display.Write("You have bought " + foundItem.Name);
				player.Inventory.Add((IItem)foundItem);
				this.Wares.Remove(foundItem);
			}
		}

		public void Sell(string itemName, Combatants.Combatant player) {
			IItem foundItem = this.findItem(itemName, player.Inventory);

			if (foundItem != null)
			{
				player.GoldPieces += foundItem.Cost;
				player.Inventory.Remove((IItem)foundItem);
				this.Wares.Add(foundItem);
				Display.Write("You sold " + foundItem.Name);
			}
		}

		private IItem findItem(string itemName, List<IItem> listToSearch) {
			IItem foundItem = null;
			try
			{
				//passing in "listToSearch" isn't ideal but we're using this to search Player and Store inventory
				//we'll try to find a better way soon
				foreach (var item in listToSearch)
				{
					//since we allowed Name to be nullable, we need to make sure it's not null
					//the lesson is that most choices have tradeoffs but it's ok to make a mistake we correct later
					if (item.Name != null && item.Name.ToLower() == itemName.ToLower())
					{
						foundItem = item;
					}
				}
			}
			catch (Exception e)
			{
				Display.DisplayText("ERROR: " + e.Message.ToString());
			}
			return foundItem;
		}

		public void Run(Combatants.Combatant player) {
			Display.Write("Hi, " + player.CharacterClass + " my name is Bob. How can I help?");
			Display.DisplayText("You have " + player.GoldPieces.ToString() + " Gold Pieces.", ConsoleColor.Magenta);

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
						case "show":
							this.ListWares();
							break;
						case "buy":
							this.Buy(target, player);
							//Display.Write("You have bought " + target);
							break;
						case "sell":
							this.Sell(target, player);
							break;
						case "exit":
							running = false;
							Display.DisplayText("You have left the " + this.Name + ".");
							break;
						case "?":
							Display.DisplayText("The following commands are available:");
							Display.DisplayText("show wares");
							Display.DisplayText("exit");
							Display.DisplayText("buy [ item ]");
							Display.DisplayText("sell [ item ]");
							//Display.DisplayText("quit");
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
