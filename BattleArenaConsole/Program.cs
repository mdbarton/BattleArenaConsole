
// .net code is organized into "namespaces"
// these "using ..." statements allow the below code to "see" the code in the above "BattleArenaConsole." namespaces
using BattleArenaConsole.Objects;
using BattleArenaConsole.Objects.Weapons;


//This is the code that runs immediately when the file/project is executed
	var g = new Game();
	g.Start();
	//all we do is create an instance of the "game" class below then invoke the "start" method.

//The game class that is instantiated above:
public class Game {
	private Combatant player;
	private Combatant opponent;

	public Game() {
		//this is the default constructor for the Game class. Here we're creating the player and opponent
		player = new Combatant(16, 16, 30);
		opponent = new Combatant(12, 12, 20);
		//Then we're creating a default "weapon" and calling the Arm method for that weapon.
		Weapon w = new Weapon();
		opponent.Arm(w);

		//the arms your player with a more powerful Sword
		Sword s = new Sword();
		player.Arm(s);
	}

	public void Start() {
		Console.WriteLine("Welcome to the battle. type 'quit' to exit.");
		bool running = true;
		//do/while executes the code between the do {} as long as the while (exp)ression returns true
		do
		{
			try
			// try/catch/finally is a method of handling/trapping errors
			{
				string c = getInput();
				switch (c)
				{
					case "attack":
						player.Attack(opponent);
						break;
					case "quit":
						running = false;
						break;
				}
			}
			catch (OverflowException e)
			{
				Console.WriteLine("Something went wrong." + e.Message.ToString());
			}
		} while (running);
	}

	public string getInput() {
		var typedText = Console.ReadLine();
		return typedText;
	}
}