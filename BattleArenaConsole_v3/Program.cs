
using BattleArenaConsole_v3;
using BattleArenaConsole_v3.Objects.Combatants;
using BattleArenaConsole_v3.Objects.Locations;
using System.Reflection;
using System.Text.RegularExpressions;
using Display = BattleArenaConsole_v3.DisplayPresentation;
class Program
{
	static void Main(string[] args)
	{
		//This is the code that runs immediately when the file/project is executed
		var g = new Game();
		g.Start();
	}
}
public class Game
{
	private Combatant player;

	//since we're not creating an "Arena" where fighting occurs, we don't need this property/field
	//private Combatant opponent;

	public Game()
	{
		//later we'll start the "game" by allowing the player to select a CharacterClass to play and roll for stats
		player = new Paladin();

		// "AttackDisplayText" is our quick and dirty way to handle the differing text on attacks, generally UI and "business logic" should have much beter separation
		player.AttackDisplayText = "Your ";

		// because the "Weapon" field in Combatant has no "set" accessor, it is read-only, the below won't work
		//player.Weapon = w; // you must use the Arm method to set a combatant's weapon
		//player.Arm(new Weapon());

	}

	public void Start()
	{
		Display.DisplayText("Welcome to the battle v3. type '?' to list commands.", ConsoleColor.Blue);
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
				string target = (cmd.Count>1) ? cmd[1].Value.Trim() : "";

				switch (command)
				{
					case "inventory":
						player.ListInventory();
						break;
					case "arm":
						//later, we'll add in handling around trying to arm > 2 hands (based on combatant's # of hands
						player.Arm(target);
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
								if (t.Name.ToLower() == target) {
									//"dynamic" allows us to invoke an unknown object by it's string name
									//as is, the Ilocation interface requires there to be a "Run" method, otherwise this might fail
									dynamic myObject = Activator.CreateInstance(t);
									myObject.Run(this.player);
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

	private string getInput()
	{
		var typedText = Console.ReadLine();
		return typedText;
	}
}
