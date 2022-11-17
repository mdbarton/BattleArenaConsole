
using BattleArenaConsole_v3;
using BattleArenaConsole_v3.Objects;
using BattleArenaConsole_v3.Objects.Combatants;
using BattleArenaConsole_v3.Objects.Locations;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

using Display = BattleArenaConsole_v3.DisplayPresentation;
class Program
{
	static void Main(string[] args)
	{
		var g = new Game();
		g.Start();
	}
}
public class Game
{
	private Combatant player;
	private Int16 MaxRolls { get; set; } = 5;

	public Game()
	{
		//player = new Paladin();
		//player.AttackDisplayText = "Your ";
	}

	private Combatant? PickCharacterClass(string choice) {
		var types = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.FullName.ToLower().Contains("combatants") && !t.IsAbstract);
		//this is slightly different than where we listed these, now we put the ! (is not) isAbstract as a where condition with &&
		Combatant? com = null;

		try {
			//we're looping through all implementations of Combatants to find the match to 
			foreach (var t in types)
			{
				if (t.Name.ToLower() == choice.ToLower()) {
					com = (Combatant)Activator.CreateInstance(t);
				}
			}
		}
		catch (Exception ex) {
			Console.WriteLine("Error: " + ex.Message.ToString());
		}
		return com; // if a Combatant type was found, that's returned, otherwise it'll be null
	}

	private void RollStats(Combatant newPlayer) {
		Dice die = new Dice("3d6");
		Int32 StrRoll = die.Roll();
		Int32 dexRoll = die.Roll();
		Display.Write("You rolled " + StrRoll.ToString() + " strength, " + dexRoll.ToString() + " dexterity");
		newPlayer.Strength = Convert.ToInt16(StrRoll);// this... Int16.Parse(StrRoll.ToString()); would also work but is more cumbersome
		newPlayer.Dexterity = Convert.ToInt16(dexRoll);
	}

	public void Start()
	{
		Display.DisplayText("Welcome to the battle v3(r1). type '?' to list commands.", ConsoleColor.Blue);
		bool running = true;

		Display.Write("Choose your character name...");
		string playerName = getInput().ToUpper(); // the last method enforces "capital case" on the string
		Display.Write("Choose a Character Class...");

		var types = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.FullName.ToLower().Contains("combatants"));
		foreach (var t in types) {
			if (!t.IsAbstract) {
				Display.Write(t.Name);
			}
		}

		string characterClass = getInput();
		//verify characterClass

		Combatant? selectedCharacter = PickCharacterClass(characterClass);
		if (selectedCharacter != null) 	this.player = selectedCharacter;
		player.PlayerName = playerName;
		player.AttackDisplayText = "Your ";
		//UI vs. Business Logic vs. Data

		Display.Write("Hello " + playerName + " the " + this.player.CharacterClass);

		Int16 rollsLeft = this.MaxRolls;
		Display.Write("You can roll for stats up to " + this.MaxRolls + " times.");

		do {
			RollStats(this.player);
			rollsLeft -= 1; //this is the same as rollsLeft = rollsLeft -1;
			Display.Write("Accept stats (y) or roll again (n), you have " + rollsLeft.ToString() + " rolls left");
			string done = getInput("(y/n) ");
			if (done == "y") break;
		}
		while (rollsLeft > 0);

		TownSquare thisTown = new TownSquare("Westmorrow");
		// maybe we can add in properies to the town, such as what locations are there...
		thisTown.Run(this.player);
	}

	private string getInput(string msg = "")
	{
		Console.Write(msg);
		var typedText = Console.ReadLine();
		return typedText;
	}
}
