// See https://aka.ms/new-console-template for more information
using BattleArenaConsole_v2.Objects.Combatants;
using BattleArenaConsole_v2.Objects.Weapons;
using System.Text.RegularExpressions;
using Display = BattleArenaConsole_v2.PresentationUtility;

//Previously we just left code inline, below is better practice, Program.Main will be automatically invoked upon running the code
class Program {
	static void Main(string[] args) {
		//This is the code that runs immediately when the file/project is executed
		var g = new Game();
		g.Start();
	}
}


public class Game
{
	private Combatant player;
	private Combatant opponent;

	public Game()
	{
		//player = new Fighter();
		player = new Paladin();
		opponent = new Fighter();

		// "AttackDisplayText" is our quick and dirty way to handle the differing text on attacks, generally UI and "business logic" should have much beter separation
		player.AttackDisplayText = "Your ";
		opponent.AttackDisplayText = "Your opponent's ";

		// because the "Weapon" field in Combatant has no "set" accessor, it is read-only, the below won't work
		//player.Weapon = w; // you must use the Arm method to set a combatant's weapon
		//player.Arm(new Weapon());
	}

	public void Start()
	{
		Display.DisplayText("Welcome to the battle v2. type '?' to list commands.", ConsoleColor.Red);
		bool running = true;
		//do/while executes the code between the do {} as long as the while (exp)ression returns true
		do
		{
			try
			// try/catch/finally is a method of handling/trapping errors
			{
				string c = getInput();

				//only get first word from input...
				var spacePosition = c.IndexOf(" "); // finds where the first space is...
				var command = c;
				if (spacePosition > 0) {
					command = c.Substring(0, spacePosition);
				}
				//regular expressions allow this to be done "more easily"
				//var command = Regex.Match(c, @"^([\w\-]+)");
				//we'll use this on the next iteration

				switch (command)
				{
					case "attack":
						player.Attack(opponent);
						if (opponent.Hitpoints < 1)
						{
							Display.DisplayText("Your enemy is dead.", ConsoleColor.DarkRed);
						}
						else
						{
							// We'll consider this "end of turn" and the opponent gets to attack now.
							opponent.Attack(player);
							player.EndTurnActions();
							if (player.Hitpoints < 1)
							{
								Display.DisplayText("You are dead.", ConsoleColor.DarkRed);
							}
							Display.DisplayText("You have " + player.Hitpoints + " hitpoints left.", ConsoleColor.DarkBlue);
							Display.DisplayText("You opponent has " + opponent.Hitpoints + " hitpoints left.", ConsoleColor.DarkBlue);
						}
						break;
					case "inventory":
						player.ListInventory();
						break;
					case "arm":
						if (c.Length > spacePosition) {
							string weaponToArm = c.Substring(spacePosition +1); //gets the rest of input
							player.Arm(weaponToArm);
						}
						break;
					case "?":
						Display.DisplayText("The following commands are available:");
						Display.DisplayText("arm");
						Display.DisplayText("attack");
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

	private string getInput()
	{
		var typedText = Console.ReadLine();
		return typedText;
	}
}